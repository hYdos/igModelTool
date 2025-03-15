using CauldronModels.igLibrary.Gen.MetaEnum;
using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CGameEntity : CEntity
{
	public uint _gameEntityPersistentProperties;

	public bool _ignoreOcclusionBoxes;

	public uint _gameEntityProperties;

	public float _lifetimeCache;

	public CAttachModelList _attachModelList;

	public CScopedScheduledFunction _animationCompleted;

	public igCallbackDelegate _onAnimationCompleteDelegate;

	public igHandle _overrideRenderMatrixComponent;

	public float _fadeStartTime;

	public float _fadeEndTime;

	public CModelInstance mModel;

	public bool mBelowKillZ;

	public bool _IsValidModel;

	public CFxMaterialRedirectTable _dynamicModelMaterialOverrides;

	public igHandle _spawnedRenderVfx;

	public CCloudBundle _cloudBundle;

	public uint _lastNetUpdateTime;

	public static bool sbDisplayPhysicsProperties;

	public new static bool _peachesCallbackRegistered;

	public ECastsShadows _castsShadows;

	public EMobileShadowStateOverride _mobileShadowStateOverride;

	public byte _viewportForceDisableFlags;

	public bool _animActive;

	public bool _animInReverse;

	public bool _noKillZ;

	public bool _hasDestination;

	public bool _fadeIn;

	public bool _scaleMovementSpeed;
}
