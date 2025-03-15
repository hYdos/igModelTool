using igLibrary.Core;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class ActorInputCommand : igObject
{
	public int _buttonStates;

	public int _buttonClicks;

	public int _buttonReleases;

	public float _speed;

	public igVec3f _direction;

	public igVec2f _initialTouchLocation;

	public igVec2f _lastTouchLocation;

	public igVec2f _lastMoveInput;

	public igHandle _touchedEntity;

	public igVec2f[] _analogStickDeflection;
}
