using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CChangeRequest : igObject
{
	public igHandle _manager;

	public bool _requestEnabled;

	public CScopedScheduledFunction _scheduledChange;
}
