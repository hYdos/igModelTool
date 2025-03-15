using System.Runtime.InteropServices;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.igCompoundMetaField;

[StructLayout(3)]
public struct CTransformMetaField
{
	public igVec3f _position;

	public igVec3f _rotation;

	public float _scale;
}
