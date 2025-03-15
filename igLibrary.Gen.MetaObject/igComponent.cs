using igLibrary.Core;
using igLibrary.Entity;
using Object = igLibrary.DotNet.Object;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class igComponent : Object {
	
	public igComponentData _data;

	public igEntity _entity;

	public uint _bitfield;

	public bool _isStarted;

	public bool _hasEverStarted;

	public bool _isThreadSafe;

	public bool _isCrashed;

	public bool _isPendingRemove;

	public bool _hasReceivedCreateMessage;

	public bool _enabled;

	public int _enableCount;

	public bool _enabledByVisualScript;

	public int _userFlags;
}
