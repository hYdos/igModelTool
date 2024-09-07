using System.Numerics;
using igLibrary;
using igLibrary.Core;
using igLibrary.Gfx;

namespace CauldronModels.api;

/// <summary>
/// High Level abstraction of VV Alchemy Vertex Format related logic
/// </summary>
public class AutomatedVertexFormat {
    private readonly List<(IG_VERTEX_USAGE, IG_VERTEX_TYPE)> _elements = [];

    public void AddElements(params (IG_VERTEX_USAGE usage, IG_VERTEX_TYPE type)[] elements) {
        _elements.AddRange(elements);
    }

    public igVertexFormat BuildAlchemyObject() {
        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        var elementSize = GetElementsSize();
        
        var vertexFormat = new igVertexFormat {
            internalMemoryPool = defaultPool,
            _vertexSize = elementSize,
            _elements = new igMemory<igVertexElement>(defaultPool, (uint)_elements.Count) {
                _alignmentMultiple = 2
            },
            _platformData = new igMemory<byte>(defaultPool, 1) {
                _alignmentMultiple = 4
            },
            _platform = IG_GFX_PLATFORM.IG_GFX_PLATFORM_DEFAULT,
            _platformFormat = new igHandle(new igHandleName {
                _ns = new igName("vertexformat"),
                _name = new igName("igVertexFormatCafe")
            }).GetObjectAlias<igVertexFormatPlatform>() ?? throw new MissingFieldException("Cannot find vertexformat.igVertexFormatCafe"),
            _streams = new igMemory<igVertexStream>(),
            _enableSoftwareBlending = false
        };

        ushort offset = 0;
        for (var i = 0; i < _elements.Count; i++) {
            var (usage, type) = _elements[i];
            vertexFormat._elements[i] = new igVertexElement {
                _offset = offset,
                _type = (byte)type,
                _usage = (byte)usage
            };
            offset += GetVertexTypeSize((byte)type);
        }
        
        vertexFormat._elements[^1] = new igVertexElement {
            _type = (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_UNUSED
        };

        vertexFormat._platformData.Realloc((vertexFormat._elements.Length - 1) * 32);
        using var newPlatformDataStream = new MemoryStream();
        using (var writer = new StreamHelper(newPlatformDataStream)) {
            writer._endianness = StreamHelper.Endianness.Big;
            offset = 0;

            foreach (var element in vertexFormat._elements) {
                if (element._type == (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_UNUSED) break;

                writer.WriteUInt32(0);
                writer.WriteUInt32(0);
                writer.WriteUInt32(offset);
                writer.WriteUInt16(0);
                writer.WriteUInt16(GetElementFormat(element._type));
                writer.WriteUInt32(0);
                writer.WriteUInt32(0);
                writer.WriteUInt16(1); // unk0. 32 on wallop
                writer.WriteUInt16(GetElementFormat2(element._type));
                writer.WriteUInt16(0);
                writer.WriteUInt16(3); // usageIndex

                offset += GetVertexTypeSize(element._type);
            }
        }

        newPlatformDataStream.Flush();
        var newPlatformData = newPlatformDataStream.ToArray();
        for (var i = 0; i < newPlatformData.Length; i++) vertexFormat._platformData[i] = newPlatformData[i];

        return vertexFormat;
    }

    private uint GetElementsSize() {
        uint size = 0;
        
        foreach (var (_, type) in _elements) {
            size += GetVertexTypeSize((byte)type);
        }

        return size;
    }

    // TODO: fix
    private static void WriteDEC3N(StreamHelper writer, Vector3 values) {
        writer.WriteByte(0);
        writer.WriteByte(1);
        writer.WriteByte(0);
        writer.WriteByte(0);
    }
    
    private static void WriteFloat3(StreamHelper writer, Vector3 values) {
        writer.WriteSingle(values.X);
        writer.WriteSingle(values.Y);
        writer.WriteSingle(values.Z);
    }
    
    private static void WriteFloat2(StreamHelper writer, Vector2 values) {
        writer.WriteSingle(values.X);
        writer.WriteSingle(values.Y);
    }
    
    private static void WriteHalf2(StreamHelper writer, Vector2 values) {
        writer.WriteHalf((Half)values.X);
        writer.WriteHalf((Half)values.Y);
    }

    private static void WriteShort4N(StreamHelper writer, Vector3 values) {
        var sscPosData = Utils.ScaleToShortBounds(values.X, values.Y, values.Z);
        writer.WriteInt16(sscPosData.scaledX);
        writer.WriteInt16(sscPosData.scaledY);
        writer.WriteInt16(sscPosData.scaledZ);
        writer.WriteInt16(sscPosData.scaleFactor);
    }

    public igMemory<byte> BuildVertexBuffer(CompiledMesh mesh) {
        var vertexPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Vertex")!;
        var elementSize = GetElementsSize();
        
        using var newVertexStream = new MemoryStream();
        using (var writer = new StreamHelper(newVertexStream)) {
            writer._endianness = StreamHelper.Endianness.Big;

            foreach (var vert in mesh.vertices) {
                foreach (var (usage, type) in _elements) {
                    switch (usage) {
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_POSITION: {
                            switch (type) {
                                case IG_VERTEX_TYPE.IG_VERTEX_TYPE_FLOAT3: {
                                    WriteFloat3(writer, vert.pos);
                                    break;
                                }
                                case IG_VERTEX_TYPE.IG_VERTEX_TYPE_SHORT4N: {
                                    WriteShort4N(writer, vert.pos);
                                    break;
                                }
                                default:
                                    throw new ArgumentOutOfRangeException(Enum.ToObject(typeof(IG_VERTEX_TYPE), type).ToString());
                            }
                            break;
                        }
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_NORMAL:
                            switch (type) {
                                case IG_VERTEX_TYPE.IG_VERTEX_TYPE_DEC3N: {
                                    WriteDEC3N(writer, vert.normal);
                                    break;
                                }
                                
                                default:
                                    throw new ArgumentOutOfRangeException(Enum.ToObject(typeof(IG_VERTEX_TYPE), type).ToString());
                            }
                            
                            break;
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_TANGENT:
                            switch (type) {
                                case IG_VERTEX_TYPE.IG_VERTEX_TYPE_DEC3N: {
                                    WriteDEC3N(writer, vert.normal);
                                    break;
                                }
                                
                                default:
                                    throw new ArgumentOutOfRangeException(Enum.ToObject(typeof(IG_VERTEX_TYPE), type).ToString());
                            }
                            break;
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_BINORMAL:
                            break;
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_COLOR:
                            break;
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_TEXCOORD:
                            switch (type) {
                                case IG_VERTEX_TYPE.IG_VERTEX_TYPE_FLOAT2: {
                                    WriteFloat2(writer, vert.uv);
                                    break;
                                }
                                case IG_VERTEX_TYPE.IG_VERTEX_TYPE_HALF2: {
                                    WriteHalf2(writer, vert.uv);
                                    break;
                                }
                                
                                default:
                                    throw new ArgumentOutOfRangeException(Enum.ToObject(typeof(IG_VERTEX_TYPE), type).ToString());
                            }
                            break;
                        
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_BLENDWEIGHTS:
                            break;
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_UNUSED_0:
                            break;
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_BLENDINDICES:
                            break;
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_FOGCOORD:
                            break;
                        case IG_VERTEX_USAGE.IG_VERTEX_USAGE_PSIZE:
                            break;
                    }
                }
            }
        }

        newVertexStream.Flush();
        if (newVertexStream.ToArray().Length % (float)elementSize != 0) throw new Exception("Bad vertex data");
        var newVertexBytes = Utils.PadToMultipleOf16(newVertexStream.ToArray());
        var igVertexData = new igMemory<byte>(vertexPool, (uint)newVertexBytes.Length);
        for (var i = 0; i < newVertexBytes.Length; i++) igVertexData[i] = newVertexBytes[i];
        return igVertexData;
    }
    
    /// format2. 02 03 == funky ssc. 02 05 = funky tangents/normals. 04 05 = half float uv's
    private static ushort GetElementFormat2(byte elementType) {
        return elementType switch {
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_SHORT4N => 0x02_03,
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_DEC3N => 0x02_05,
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_HALF2 => 0x04_05,
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_FLOAT3 => 0x02_05,
            _ => throw new ArgumentOutOfRangeException(Enum.ToObject(typeof(IG_VERTEX_TYPE), elementType).ToString(), elementType, null)
        };
    }

    /// format. 02 0E == funky ssc. 02 0B = funky tangents/normals. 08 08 = half float uv's
    private static ushort GetElementFormat(byte elementType) {
        return elementType switch {
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_FLOAT3 => 0x0811,
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_SHORT4N => 0x020E,
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_DEC3N => 0x020B,
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_HALF2 => 0x0808, // GX2_ATTRIB_TYPE_16_16_FLOAT GX2_ATTRIB_TYPE_16_16_FLOAT
            _ => throw new ArgumentOutOfRangeException(Enum.ToObject(typeof(IG_VERTEX_TYPE), elementType).ToString(), elementType, null)
        };
    }

    private static ushort GetVertexTypeSize(byte elementType) {
        return elementType switch {
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_FLOAT3 => 0xC,
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_SHORT4N => 0x8,
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_DEC3N => 0x4,
            (byte)IG_VERTEX_TYPE.IG_VERTEX_TYPE_HALF2 => 0x4,
            _ => throw new ArgumentOutOfRangeException(Enum.ToObject(typeof(IG_VERTEX_TYPE), elementType).ToString(), elementType, null)
        };
    }
}