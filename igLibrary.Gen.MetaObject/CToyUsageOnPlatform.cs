using CauldronModels.igLibrary.Gen.MetaEnum;
using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CToyUsageOnPlatform : igObject
{
	public EToyUsagePlatformType[] _platform;

	public int[] _isFirstUsedServerTime;

	public uint[] _firstUsed;

	public uint[] _totalTimeUsed;

	public uint[] _lastTimeUsed;

	public int _yearCode;

	public uint[] _currentUsageTime;
}
