using System.Runtime.InteropServices;
using igLibrary.Core;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.igMetaField;

[igStruct]
public struct CTransform
{
	public igVec3f _position;

	public igVec3f _rotation;

	public float _scale;
}
