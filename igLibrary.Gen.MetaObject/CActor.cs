using CauldronModels.igLibrary.Gen.igMetaField;
using igLibrary;
using igLibrary.Core;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CActor : CPhysicalEntity
{
	public uint mAttackNumber;

	public igHandle _player;

	public uint _nonPersistentBitfield;

	public bool mIsPlayerFastFlagHack;

	public bool mInitialized;

	public bool _inFreezeFrame;

	public igVec3f _linearVelocityBeforeFreezeFrame;

	public igVec3f _angularVelocityBeforeFreezeFrame;

	public igVec2f _currentMoveStickDirection;

	public CTransform _cameraRelativeMovementTransform;

	public float _heroShadowFade;

	public float mPainSoundTimer;

	public igHandle _lastGroundMaterialTouched;

	public uint mDeathTime;

	public CEntityID mLastHitEnt;

	public float mLastHitEntTime;

	public float mLastAttackedTime;

	public CEntityID mLastAttackedBy;

	public CCombatTargetDataListList _combatTargets;

	public igHandle _combatTargetProxy;

	public CCollectibleFilterList _collectiblesFilters;

	public igHandle _enabledBaseVehicleController;

	public bool _canCollectCollectibles;

	public bool _debugMove;

	public ActorInput _actorInput;

	public CCharacterPortalData _portalData;

	public bool _isMagicMomentDummy;

	public igHandle _spawnedLowHealthEffect;

	public CEnableRequestManager _ignoreHitReacts;

	public CEnableRequestManager _ignorePartialHitReacts;

	public CEnableRequestManager _ignoreHitPushBack;

	public CTargetableFlagEnableStack _targetableFlag;

	public CSpawnedActorVfxList _spawnedVfx;

	public CActorTimeScaleNonRefcountedList _timeScaleList;

	public CTimeScaleEnableStack _allowTimeScaling;

	public CActorTimeScale _freezeFrameTimeScale;

	public CEnableRequestManager _muted;

	public CChangeRequestList _changeRequests;

	public string _skinName;

	public static bool _usedNoClip;

	public bool _followingOther;

	public CActor _followHero;

	public igHandle _behaviorComponentHandle;

	public igHandle _progressionComponentHandle;

	public static bool mAllowFriendlyFire;

	public static bool mHealthDisplay;

	public static bool mHeroUndying;

	public static bool mGodMode;

	public static bool mDisplayFlash;

	public static bool mDisplayPos;

	public static bool mTouchOfDeath;

	public static bool _debugEnemiesUndying;

	public static bool mAnimClipDisplayHero;

	public static bool mAnimClipDisplayVehicle;

	public static bool mAnimClipDisplayAI;

	public static bool mTimelineDisplayHero;

	public static bool mTimelineDisplayVehicle;

	public static bool mTimelineDisplayAI;

	public static bool mShowCombatTargets;

	public static bool mDisplayMovementSpeed;

	public static bool mResetBehaviorOnNoClip;

	public static bool _disableButtonAliases;

	public static bool _drawGroundMaterial;

	public static bool _drawEnemyEntityTags;

	public static CDebugCombatTargetCountTable _debugCombatTargetCounts;

	public bool _forceMovementForward;

	public bool _isHoldingMove;

	public bool _resetCameraRelativeMovement;

	public bool _hasBaseVehicleControllerComponent;

	public bool _manualThinkControl;

	public bool _animClipDisplayHero;

	public bool _timelineDisplayHero;
}
