using igLibrary;
using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CPhysicalEntity : CGameEntity
{
	public igVector<CHealthObject> _healthObjects;

	public int _healthMax;

	public int _unadjustedMaxHealth;

	public float _lastBeamAttackedTime;

	public EVulnerability _vulnerability;

	public CEnableRequestManager _invulnerable;

	public CAttackNumberTimestampTable _recentAttackNumberTimestampTable;

	public CAttackImmunityTimestampTable _recentAttackImmunityTimestampTable;

	public byte _runtimeFlags;

	public static igUnsignedIntList _expiredAttackNumbers;

	public static igStringRefList _expiredImmunities;

	public bool _removeOnDeath;

	public bool _netDeath;

	public bool _hasDied;

	public bool _immunityCallbackRegistered;
}
