using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CChangeRequestManager : igObject
{
	public int _requestCounter;

	public COnChangeDelegate _onChange;

	public COnChangeEventList _onChangeEventList;

	public igHandle _owner;

	public uint _nonScopedRequests;
}
