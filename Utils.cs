using igLibrary;
using igLibrary.Core;

namespace CauldronModels;

public static class Utils {
    public static void WriteHalf(this StreamHelper streamHelper, Half data) => streamHelper.WriteHalf(data, streamHelper._endianness);

    public static void WriteHalf(this StreamHelper streamHelper, Half data, StreamHelper.Endianness endianness) {
        streamHelper.WriteForEndianness(BitConverter.GetBytes(data), endianness);
    }

    public static void WriteForEndianness(this StreamHelper streamHelper, byte[] bytes, StreamHelper.Endianness endianness) {
        switch (endianness) {
            case StreamHelper.Endianness.Little:
                if (!BitConverter.IsLittleEndian) {
                    Array.Reverse(bytes);
                }

                break;
            case StreamHelper.Endianness.Big:
                if (BitConverter.IsLittleEndian) {
                    Array.Reverse(bytes);
                }

                break;
        }

        streamHelper.BaseStream.Write((ReadOnlySpan<byte>)bytes);
    }

    public static igNamedObject? FindObjectByName(this igObjectList obj, string targetName) {
        foreach (var targetIgObj in obj) {
            var nameField = targetIgObj.GetMeta().GetFieldByName("_name");
            if (nameField == null) continue;
            var name = nameField._fieldHandle!.GetValue(targetIgObj);
            if (name == null || !name.Equals(targetName)) continue;
            return (igNamedObject?)targetIgObj;
        }

        return null;
    }

    public static igObject? FindObjectByType(this igObjectList obj, Type targetType) {
        return obj.FirstOrDefault(targetIgObj => targetIgObj.GetType() == targetType);
    }

    public static igObjectDirectory NewIgz(string name) {
        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        var igz = new igObjectDirectory(name + ".igz") {
            internalMemoryPool = defaultPool,
            _useNameList = true,
            _nameList = new igNameList { internalMemoryPool = defaultPool },
            _type = igObjectDirectory.FileType.kIGZ,
            _objectList = {
                internalMemoryPool = defaultPool
            }
        };
        return igz;
    }

    public static igArchive NewArchive(this igArchiveManager archiveManager, string path) {
        if (archiveManager.TryGetArchive(path, out var archive))
            return archive;
        var igArchive = new igArchive {
            _path = $"{path}",
            _archiveHeader = new igArchive.Header {
                _magicNumber = 0,
                _version = 11U,
                _tocSize = 0,
                _numFiles = 0,
                _sectorSize = 0x512,
                _hashSearchDivider = 0xFFFFFFFF,
                _hashSearchSlop = 0,
                _numLargeFileBlocks = 0,
                _numMediumFileBlocks = 0,
                _numSmallFileBlocks = 0,
                _nameTableOffset = 0,
                _nameTableSize = 0,
                _flags = 0
            }
        };
        archiveManager._archiveList.Append(igArchive);
        return igArchive;
    }

    public static (short scaledX, short scaledY, short scaledZ, short scaleFactor) ScaleToShortBounds(float x, float y, float z) {
        // Find the maximum absolute value among the coordinates
        var maxCoord = Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Abs(z));

        // If the maxCoord is zero, avoid division by zero by setting the scale factor to 1
        var scaleFactor = maxCoord == 0 ? 1 : short.MaxValue / maxCoord;

        // Scale the coordinates to fit within the range of a signed short
        var scaledX = x * scaleFactor;
        var scaledY = y * scaleFactor;
        var scaledZ = z * scaleFactor;

        return ((short scaledX, short scaledY, short scaledZ, short scaleFactor))(scaledX, scaledY, scaledZ, scaleFactor);
    }

    public static byte[] PadToMultipleOf16(byte[] inputArray) {
        var length = inputArray.Length;
        var newLength = (length + 15) / 16 * 16;

        var paddedArray = new byte[newLength];
        Array.Copy(inputArray, paddedArray, length);
        return paddedArray;
    }

    public static igStringStringHashTable NewStringHashTable(params (string key, string value)[] values) {
        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        var table = new igStringStringHashTable {
            internalMemoryPool = defaultPool,
            _keys = new igMemory<string>(),
            _values = new igMemory<string>()
        };
        
        foreach (var (key, value) in values) table.Add(key, value);
        return table;
    }
}