using CauldronModels.igLibrary.Gen.MetaEnum;
using igLibrary.Core;
using Object = igLibrary.DotNet.Object;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CEnableStack : Object
{
	
	public int _stackCounter;

	public EEnableStackMode _mode;

	public int _allowNegativeStackRequests;

	public bool _enableMismatchedCallChecks;

	public string _enableErrorMessage;

	public string _disableErrorMessage;
}
