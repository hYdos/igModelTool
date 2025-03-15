using igLibrary;
using igLibrary.Core;
using igLibrary.Graphics;
using igLibrary.Math;
using igLibrary.Render;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class igModelInstance : igObject
{
	public static igStringUnsignedIntHashTable _globalModelClassTable;

	public static uint _globalModelClassIndexCounter;

	public igModelInstance _parent;

	public byte _forceCullFlags;

	public byte _forceViewportDisableFlags;

	public byte _visibleDebug;

	public byte _classIndex;

	public short _stencilRef;

	public igMatrix44f _transform;

	public igVec4f _min;

	public igVec4f _max;

	public uint _parentTransformIndex;

	public uint _parentBoneIndex;

	public igTimeTransform2 _timeTransform;

	public ulong _blendMatrices;

	public uint _blendMatrixCount;

	public ulong _boneMatrices;

	public uint _boneMatrixCount;

	public igModelData _data;

	public uint _bitfield;

	public uint _filterId;

	public string _class;

	public igModelMaterialRedirectTable _materialRedirectTable;

	public igShaderConstantBundleList _shaderConstantBundles;

	public int _dynamicConstantBundleCount;

	public ulong _bakedVertexBufferResource;

	public ulong _bakedVertexFormatResource;

	public int _bakedVertexDataBaseOffset;

	public static float _GlobalFade;

	public uint _flags;

	public bool _allowFrustumCulling;

	public DistanceCullImportance _distanceCullImportance;

	public bool _allowGlobalFade;
}
