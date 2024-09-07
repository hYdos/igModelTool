using CauldronModels.api;
using igLibrary;
using igLibrary.Core;
using igLibrary.Gen.MetaEnum;
using igLibrary.Gfx;
using igLibrary.Graphics;
using igLibrary.Math;
using igLibrary.Render;
using ESkylanderType = igLibrary.Gen.MetaEnum.ESkylanderType;

namespace CauldronModels;

internal static class Program {
    /// <summary>
    /// Removes and replaces existing meshes on any igz containing a igModelInfo. This will NOT work on actors for now.
    /// </summary>
    /// <param name="gameContentDir">Path to the game's assets</param>
    /// <param name="updatePakFile">Which flavor to use</param>
    /// <param name="platform">Platform the game is on. Example: IG_CORE_PLATFORM_CAFE</param>
    /// <param name="targetPak">The pak or iga archive you wish to open</param>
    /// <param name="targetModel">The path to the model you want to replace inside the pak or iga</param>
    /// <param name="replacementModelPath">The path pointing to the new model to overwrite the existing model with</param>
    /// <param name="printPlatformData">You don't want this probably</param>
    /// <param name="scale">the amount of scale the model should have. Default is 10</param>
    /// <param name="useFloat3Pos">This is hacky but 4 shorts sucks so... Option to turn it off is there though. I have an implementation it is just not perfect</param>
    // ReSharper disable once UnusedMember.Local
    private static void Main(string gameContentDir, string updatePakFile, IG_CORE_PLATFORM platform, string targetPak, string targetModel,
        string replacementModelPath, bool printPlatformData = false, float scale = 10, bool useFloat3Pos = true) {
        Console.WriteLine("Loading IgLibrary");
        IgLibraryInit(
            gameContentDir,
            updatePakFile,
            platform
        );

        CreateSkylander("funkykong", new CFullCharacterToyData {
            _toyId = kTfbSpyroTag_ToyType.kTfbSpyroTag_ToyType_Character_FunkyKong,
            _elementType = EElementType.eET_Water,
            _toyName = "Funky Kong",
            _seriesName = "hydos",
            _variants = new CVariantIdentifierList {
                internalMemoryPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!,
                _data = new igMemory<CVariantIdentifier>()
            },
            _faceOffPortraitMaterial = new igHandle(new igHandleName {
                _name = new igName("Zook_FullScreen_materials.FaceOff")
            }),
            _characterName = "Funky Kong",
            _allowSmokeTestSwapAllHeroes = true,
            _allowSmokeTestSwapAllHeroesPS3 = true,
            _allowSmokeTestSwapAllHeroesXenon = true,
            _skylanderType = ESkylanderType.eST_Core
        });

        Console.WriteLine("Opening Archives");
        igSingleton<igFileContext>.Singleton.LoadArchive(targetPak);
        var srcModel = igSingleton<igObjectStreamManager>.Singleton.Load(targetModel)!;

        var modelInfo = (igModelInfo)srcModel._objectList.FindObjectByType(typeof(igModelInfo))!;
        var modelData = modelInfo._modelData;
        var materialHandle = modelData._drawCalls[0]._materialHandle;

        var replacementModel = new Model(replacementModelPath);
        if (printPlatformData) {
            var i = 0;
            foreach (var unused in modelData._drawCalls) {
                File.WriteAllBytes("platformData." + i + "}.bin", unused._graphicsVertexBuffer._vertexBuffer._format._platformData.Buffer);
                i++;
            }
        }

        Console.WriteLine("Building Model");
        modelData._drawCalls = BuildMeshes(replacementModel, materialHandle, scale, useFloat3Pos);
        modelData._drawCallTransformIndices = new igVector<int>();
        foreach (var unused in replacementModel.Meshes) {
            modelData._drawCallTransformIndices.Append(0);
        }

        Console.WriteLine("Saving to update.pak & model.igz");
        SaveToFile(srcModel, "model.igz");
        SaveUpdatePak(srcModel);
        Console.WriteLine("Done, Have Fun.");
        // return 0;

        // var imgFs = new FileStream(@"C:\Users\hydos\Desktop\custommodels\funkykong\DrvChr06_Alb_swizzled.dds", FileMode.Open, FileAccess.Read);
        // var tmpSpan = new byte[4];
        //
        //
        // imgFs.Seek(0x0C, SeekOrigin.Begin);
        // imgFs.Read(tmpSpan, 0, 4);
        // var height = BitConverter.ToInt32(tmpSpan);
        // imgFs.Read(tmpSpan, 0, 4);
        // var width = BitConverter.ToInt32(tmpSpan);
        // imgFs.Seek(0x80, SeekOrigin.Begin);
        // var compressedDataSize = imgFs.Length - imgFs.Position;
        // var compressedData = new byte[compressedDataSize];
        // imgFs.Read(compressedData, 0, (int)compressedDataSize);
        //
        // var material = element0._materialHandle.GetObjectAlias<igGraphicsMaterial>();
        // var textureObj = (igGraphicsTexture)material!._graphicsObjects._objects[0];
        // var (image, imgDir) = textureObj._imageHandle.GetObjectAlias2<igImage2>();
        // Console.WriteLine($"Texture type: {image!._format._name}");
        // image._width = (ushort)width;
        // image._height = (ushort)height;
        // var size = width * height * image._format._bitsPerPixel / 8;
        // image._data.Realloc(size);
        // for (var i = 0; i < size; i++) image._data[i] = compressedData[i];
        // SaveToFile(imgDir!, "test_img.igz");
        // SaveUpdatePak(imgDir!);
    }

    private static void CreateSkylander(string name, CFullCharacterToyData fullToyData) {
        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        var toydataPath = "toydata/" + name;

        var toydata = new igObjectDirectory(toydataPath + ".igz") {
            internalMemoryPool = defaultPool,
            _useNameList = true,
            _nameList = new igNameList { internalMemoryPool = defaultPool },
            _type = igObjectDirectory.FileType.kIGZ
        };

        fullToyData.internalMemoryPool = defaultPool;
        toydata.AddObject(fullToyData, default, new igName(name + "_ToyData"));
        toydata._objectList.internalMemoryPool = defaultPool;
        
        var pkg = igSingleton<igObjectStreamManager>.Singleton.Load("packages/generated/packagexmls/permanent_pkg.igz")!;
        var objectDir = (igStringRefList)pkg._objectList[0];
        objectDir.Append("igx_file");
        objectDir.Append(toydataPath + ".igz");
        SaveUpdatePak(pkg);
        
        var permanent = igSingleton<igFileContext>.Singleton.LoadArchive("app:/archives/permanent.pak");
        var memoryStream = new MemoryStream();
        toydata.WriteFile(memoryStream, igRegistry.GetRegistry()._platform);
        memoryStream.Seek(0L, SeekOrigin.Begin);
        var fp = new igFilePath();
        fp.Set(toydata._path);
        permanent.GetAddFile(fp._path);
        permanent.Compress(fp._path, memoryStream);
        memoryStream.Close();
        
        if (permanent._path[1] == ':')
            permanent.Save(permanent._path);
        else
            permanent.Save(igSingleton<igFileContext>.Singleton._root + "/archives/" + Path.GetFileName(permanent._path));
    }

    private static igVector<igModelDrawCallData> BuildMeshes(Model model, igHandle defaultMaterial, float scale, bool useFloat3Pos) {
        var drawCalls = new igVector<igModelDrawCallData>();

        foreach (var compiledMesh in model.Meshes) {
            drawCalls.Append(BuildMesh(compiledMesh, defaultMaterial, scale, useFloat3Pos));
        }

        return drawCalls;
    }

    private static igModelDrawCallData BuildMesh(CompiledMesh mesh, igHandle defaultMaterial, float scale, bool useBadDumbStupidBadIdiotSimpleFormat = true) {
        const IG_GFX_DRAW primitive = IG_GFX_DRAW.IG_GFX_DRAW_TRIANGLES;
        var vertexFmtBuilder = new AutomatedVertexFormat();
        vertexFmtBuilder.AddElements(
            (IG_VERTEX_USAGE.IG_VERTEX_USAGE_POSITION, IG_VERTEX_TYPE.IG_VERTEX_TYPE_FLOAT3),
            (IG_VERTEX_USAGE.IG_VERTEX_USAGE_NORMAL, IG_VERTEX_TYPE.IG_VERTEX_TYPE_DEC3N),
            (IG_VERTEX_USAGE.IG_VERTEX_USAGE_TEXCOORD, IG_VERTEX_TYPE.IG_VERTEX_TYPE_HALF2)
        );

        foreach (var meshVertex in mesh.vertices) {
            meshVertex.pos.X *= scale;
            meshVertex.pos.Y *= scale;
            meshVertex.pos.Z *= scale;
        }

        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        var vertexPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Vertex")!;

        using var newIndexStream = new MemoryStream();
        using (var writer = new StreamHelper(newIndexStream)) {
            writer._endianness = StreamHelper.Endianness.Big;
            foreach (var idx in mesh.indices) writer.WriteUInt16((ushort)idx);
        }

        newIndexStream.Flush();
        var newIndexBytes = Utils.PadToMultipleOf16(newIndexStream.ToArray());
        var igIndexData = new igMemory<byte>(vertexPool, (uint)newIndexBytes.Length);
        igIndexData.Alloc(newIndexBytes.Length);
        for (var i = 0; i < newIndexBytes.Length; i++) igIndexData[i] = newIndexBytes[i];

        var vertexFormat = vertexFmtBuilder.BuildAlchemyObject();

        var idxFormat = igIndexFormat.GetFormatName(IG_INDEX_TYPE.IG_INDEX_TYPE_INT16, IG_GFX_PLATFORM.IG_GFX_PLATFORM_CAFE, false);

        return new igModelDrawCallData {
            internalMemoryPool = defaultPool,
            _min = new igVec4f(-1, -1, -1, 0),
            _max = new igVec4f(1, 1, 1, 1),
            _materialHandle = defaultMaterial,
            _graphicsVertexBuffer = new igGraphicsVertexBuffer {
                internalMemoryPool = defaultPool,
                _usage = igResourceUsage.kUsageStatic,
                _vertexBuffer = new igVertexBuffer {
                    internalMemoryPool = defaultPool,
                    _vertexCount = (uint)mesh.vertices.Count,
                    _vertexCountArray = SingleValueIgMemory((uint)mesh.vertices.Count),
                    _format = vertexFormat,
                    _primitiveType = primitive,
                    _packData = new igMemory<byte>(),
                    _data = vertexFmtBuilder.BuildVertexBuffer(mesh)
                }
            },
            _graphicsIndexBuffer = new igGraphicsIndexBuffer {
                internalMemoryPool = defaultPool,
                _usage = igResourceUsage.kUsageStatic,
                _indexBuffer = new igIndexBuffer {
                    internalMemoryPool = defaultPool,
                    _indexCount = (uint)mesh.indices.Count,
                    _indexCountArray = SingleValueIgMemory((uint)mesh.indices.Count),
                    _vertexFormat = vertexFormat,
                    _primitiveType = primitive,
                    _format = new igHandle(new igHandleName {
                        _ns = new igName("indexformats"),
                        _name = new igName(idxFormat)
                    }).GetObjectAlias<igIndexFormat>() ?? throw new MissingFieldException("Cannot find " + idxFormat),
                    _data = igIndexData
                }
            },
            _propertiesBitField = 0b100000001011100,
            _bakedBufferOffset = -1,
            _indexBufferType = IG_INDEX_TYPE.IG_INDEX_TYPE_INT32,
            _primitiveType = primitive,
            _lod = 1,
            _enabled = true
        };
    }

    private static igMemory<T> SingleValueIgMemory<T>(T obj) {
        var igMemory = new igMemory<T>();
        igMemory.Alloc(1);
        igMemory[0] = obj;
        return igMemory;
    }

    private static void IgLibraryInit(string gameDir, string updatePakPath, IG_CORE_PLATFORM platform) {
        igAlchemyCore.InitializeSystems();
        igSingleton<igFileContext>.Singleton.Initialize(gameDir);
        igSingleton<igFileContext>.Singleton.InitializeUpdate(updatePakPath);
        igRegistry.GetRegistry()._platform = platform;
        igRegistry.GetRegistry()._gfxPlatform = igGfx.GetGfxPlatformFromCore(platform);
        igArkCore.ReadFromFile(igArkCore.EGame.EV_SkylandersSuperchargers);
        var platform2 = igRegistry.GetRegistry()._platform;

        igSingleton<igFileContext>.Singleton.LoadArchive("app:/archives/loosefiles.pak");
        CPrecacheManager._Instance.PrecachePackage("generated/shaders/shaders_" + igAlchemyCore.GetPlatformString(platform2), EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/permanent_" + igAlchemyCore.GetPlatformString(platform2), EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/essentialui", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/UI/legal", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/gamestartup", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/permanentdeveloper", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/SoundBankData", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/permanent", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/maps/zoneinfos", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/permanent_2015", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/UI/Domains/JuiceDomain_Mobile", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/UI/Domains/JuiceDomain_FrontEnd", EMemoryPoolID.MP_DEFAULT);
    }

    private static void SaveToFile(igObjectDirectory directory, string name) {
        var memoryStream = new MemoryStream();
        directory.WriteFile(memoryStream, igRegistry.GetRegistry()._platform);
        memoryStream.Seek(0L, SeekOrigin.Begin);

        var fs = File.Create(name);
        memoryStream.CopyTo(fs);
        fs.Close();
        memoryStream.Seek(0, SeekOrigin.Begin);
    }

    private static void SaveUpdatePak(igObjectDirectory currentDir) {
        var memoryStream = new MemoryStream();
        currentDir.WriteFile(memoryStream, igRegistry.GetRegistry()._platform);
        memoryStream.Seek(0L, SeekOrigin.Begin);
        var igFilePath = new igFilePath();
        igFilePath.Set(currentDir._path);
        var igArchive = igSingleton<igFileContext>.Singleton._archiveManager._patchArchives._count > 0
            ? igSingleton<igFileContext>.Singleton._archiveManager._patchArchives[0]
            : (igArchive)currentDir._fd._device;
        igArchive.GetAddFile(igFilePath._path);
        igArchive.Compress(igFilePath._path, memoryStream);
        memoryStream.Close();
        if (igArchive._path[1] == ':')
            igArchive.Save(igArchive._path);
        else
            igArchive.Save(igSingleton<igFileContext>.Singleton._root + "/archives/" + Path.GetFileName(igArchive._path));
    }
}