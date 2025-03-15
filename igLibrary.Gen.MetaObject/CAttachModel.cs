using igLibrary;
using igLibrary.Core;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CAttachModel : igObject
{
	public CModelInstance _model;

	public CFxMaterialRedirectTable _dynamicMaterialOverride;

	public CFxMaterialRedirectTable _materialOverrides;

	public CBoltPoint _bolt;

	public static bool _peachesCallbackRegistered;

	public igHandle _parent;

	public string _modelName;

	public igVec3f _position;

	public igVec3f _rotation;

	public igVec3f _scale;
}
