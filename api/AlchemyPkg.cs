using System.Diagnostics.CodeAnalysis;
using igLibrary.Core;
using static CauldronModels.Utils;

namespace CauldronModels.api;

/// <summary>
/// Wrapper around Alchemy's pkg format
/// </summary>
public class AlchemyPkg {
    private readonly igObjectDirectory _pkgInfo;
    private readonly igStringRefList _pkgLoadList;
    private readonly List<igObjectDirectory> _igzs = [];
    private readonly string _path;

    public AlchemyPkg(string path) {
        _path = path;
        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        
        _pkgInfo = Utils.NewIgz($"packages/generated/{path}_pkg");
        _pkgLoadList = new igStringRefList {
            internalMemoryPool = defaultPool
        };
        _pkgInfo.AddObject(_pkgLoadList, default, new igName("list"));
        _igzs.Add(_pkgInfo);
    }

    public igObjectDirectory NewIgz(ObjectType type, string path) {
        var igz = Utils.NewIgz(path);
        _pkgLoadList.Append(Enum.GetName(type)!);
        _pkgLoadList.Append(path + ".igz");
        _igzs.Add(igz);
        return igz;
    }

    public void Save() {
        var newArchive = igSingleton<igFileContext>.Singleton._archiveManager.NewArchive($"app:/archives/{_path}.pak");
        
        foreach (var igz in _igzs) {
            var memoryStream = new MemoryStream();
            igz.WriteFile(memoryStream, igRegistry.GetRegistry()._platform);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            var fp = new igFilePath();
            fp.Set(igz._path);
            newArchive.GetAddFile(fp._path);
            newArchive.Compress(fp._path, memoryStream);
            memoryStream.Close();
        }
        
        if (newArchive._path[1] == ':')
            newArchive.Save(newArchive._path);
        else
            newArchive.Save(igSingleton<igFileContext>.Singleton._root + "/archives/" + Path.GetFileName(newArchive._path));
    }
    
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum ObjectType {
        character_data,
        actorskin,
        texture,
        effect,
        igx_file,
        material_instances,
        lang_file,
        model,
        graphdata_behavior,
        events_behavior
    }
}