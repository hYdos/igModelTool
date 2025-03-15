using igLibrary.Core;
using igLibrary.Entity;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class igEntity : igObject
{
	public igEntityData _entityData;

	public igEntityBolt _bolt;

	public igComponentList _components;

	public igVec3f _parentSpacePosition;

	public igEntityTransform _transform;

	public uint _bitfield;

	public bool _canSpawn;

	public bool _isArchetype;

	public bool _spawned;

	public uint _disableStack;

	public bool _enabledByVisualScript;

	public bool _enabled;

	public bool _isFading;

	public bool _isPositionDirty;

	public bool _isRotationDirty;

	public bool _isScaleDirty;

	public bool _isMoving;

	public bool _isVisible;

	public bool _isHidden;

	public bool _isVolumeCulled;

	public bool _canVolumeCull;

	public uint _disableVolumeCullStack;

	public bool _disableVolumeCullByScript;

	public int _userFlags;
}
