using CauldronModels.igLibrary.Gen.igMetaField;
using CauldronModels.igLibrary.Gen.MetaEnum;
using igLibrary;
using igLibrary.Core;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CEntity : igEntity
{
	public igHandle _owner;

	public igVec3f _min;

	public igVec3f _max;

	public igVec3f _velocity;

	public igVec3f _angularVelocity;

	public byte[] _flags;

	public string _name;

	public CEntityID _id;

	public ushort _properties;

	public short _turningLockedCounter;

	public static bool _peachesCallbackRegistered;

	public bool _startHidden;

	public bool _haveComponentsToStart;

	public bool _haveComponentsToRemove;

	public bool _actEnabled;

	public bool _actToggleOn;

	public EScaleSource _scaleSource;

	public bool netReplicate;

	public bool hasTimeComponent;

	public bool hasScaledTimeComponent;
}
