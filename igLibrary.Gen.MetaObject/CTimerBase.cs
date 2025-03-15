using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CTimerBase : igObject
{
	public uint _startTime;

	public uint _stopTime;

	public bool _isRunning;

	public bool _isPaused;
}
