using igLibrary.Core;
using igLibrary.Math;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class ActorInput : igObject
{
	public ActorInputCommand _input;

	public float _delta;

	public float _deltaScaled;

	public int _previousButtonStates;

	public CTimer _touchDuration;

	public igVec3f _lastPressedDirection;

	public float _stickSpeedWithDeadzone;

	public bool _inputProcessed;

	public COnProcessInputEventList _onProcessInputEventList;

	public COnProcessInputDelegate _onProcessInput;

	public CEnableRequestManager _lockControls;

	public bool _playerInput;
}
