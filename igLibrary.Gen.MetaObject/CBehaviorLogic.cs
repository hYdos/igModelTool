namespace igLibrary
{
	public class CBehaviorLogic : CBaseBehaviorLogic
	{
		public igLibrary.Core.igStringStringHashTable _activators;
		public igLibrary.Core.igStringStringHashTable _excludeActivators;
		public CBaseUpgradeFilter _skillUpgradeFilter;
		public CBaseVehicleModeFilter _vehicleModeFilter;
		public System.Boolean _playerOnly;
		public System.Boolean _useProxy;
		public System.Boolean _useProxyInputOnly;
		public System.Boolean _useProxyPassengerOnly;
		public System.Boolean _disable;
		public igLibrary.Core.igMetaObject _meta;
	}
}