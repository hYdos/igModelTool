using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CScopedScheduledFunction : igObject
{
	public igHandle _handle;

	public ulong _scheduledCallback;

	public igHandle _callbackOwner;

	public igObject _userData;
}
