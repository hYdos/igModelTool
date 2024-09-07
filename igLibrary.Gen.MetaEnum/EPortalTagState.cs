namespace igLibrary.Gen.MetaEnum;

public enum EPortalTagState
{
	ePTS_NotOnPortal,
	ePTS_IoWait,
	ePTS_HeaderLoad,
	ePTS_HeaderReady,
	ePTS_WaitForShapeshifterPair,
	ePTS_MagicMomentLoad,
	ePTS_MagicMomentReady,
	ePTS_RemainingLoad,
	ePTS_RemainingReady,
	ePTS_OwnerIdLoad,
	ePTS_OwnerIdReady,
	ePTS_VerifySecurity,
	ePTS_SecurityVerified,
	ePTS_Write,
	ePTS_Reset,
	ePTS_OwnerIdReset,
	ePTS_Recover,
	ePTS_WriteOwnerId,
	ePTS_Idle,
	ePTS_SoftError,
	ePTS_HardError
}
