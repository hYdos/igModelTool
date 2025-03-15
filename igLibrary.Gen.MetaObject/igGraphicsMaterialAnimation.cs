using System.Runtime.InteropServices;
using CauldronModels.igLibrary.Gen.MetaEnum;
using igLibrary.Core;
using igLibrary.Sg;

namespace CauldronModels.igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class igGraphicsMaterialAnimation : igObject
{
	public igAnimatedTransformSource _transform;

	public igGraphicsMaterialAnimationConstantType _constantType;

	public string _constantName;

	public ulong _resource;
}
