using System.Runtime.InteropServices;
using igLibrary.Core;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class igSkeletonBone : igNamedObject
{
	public int _parentIndex;

	public int _blendMatrixIndex;

	public igVec3f _translation;
}
