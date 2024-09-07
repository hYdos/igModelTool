namespace igLibrary.Gen.MetaEnum;

public enum EVehicleDockingState
{
	eVDS_Inactive,
	eVDS_AwaitingPlayer,
	eVDS_TransitionQueued,
	eVDS_VerifyingVehicleType,
	eVDS_DriverEnterSequence,
	eVDS_WaitingForPlayersToDock,
	eVDS_WaitingForPlayersToExitAndDock,
	eVDS_VehicleChangingFormParked,
	eVDS_VehicleChangingFormDriving,
	eVDS_VehicleChangingFormInvisible,
	eVDS_VehicleDocked,
	eVDS_VehicleDockedWaitingForRemoteTransition,
	eVDS_TransitionCooldown,
	eVDS_VehicleDocking,
	eVDS_VehicleDockingEnd,
	eVDS_DriverExitSequence
}
