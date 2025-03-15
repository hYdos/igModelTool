using CauldronModels.igLibrary.Gen.igMetaField;
using igLibrary.Core;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class igEntityTransform : igObject
{
	public igQuaternionf _parentSpaceOrientation;

	public igMatrix44f _parentSpaceTransform;

	public igVec3f _parentSpaceRotation;

	public float _runtimeParentSpaceScale;

	public igVec3f _nonUniformPersistentParentSpaceScale;

	public bool _isDirty;

	public static igSpinLockMetaField _lock;
}
