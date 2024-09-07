using System.Runtime.InteropServices;
using igLibrary.Core;
using igLibrary.Gen.MetaEnum;

namespace igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class igGraphicsMaterial : igMaterial
{
	public ulong _globalTechniqueMask;

	public uint _materialBitField;

	public float _sortDepthOffset;

	public igHandle _effectHandle;

	public igMemoryCommandStream _commonState;

	public igVector<igMemoryCommandStream> _techniques;

	public igGraphicsMaterialAnimationList _animations;

	public igGraphicsObjectSet _graphicsObjects;

	public byte _sortKey;

	public igDrawType _drawType;

	public igGraphicsMaterialAnimationTimeSource _timeSource;
}
