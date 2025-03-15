using igLibrary.Core;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CCombatTargetData : igObject
{
	public static igObjectPool _pool;

	public static CCombatTargetDataList _sharedTemporaryList;

	public igHandle _targetEntity;

	public igVec3f _aimedPosition;

	public igVec3f _targetNormal;

	public igHandle _registeredDelegatesOwner;
}
