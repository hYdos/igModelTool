namespace igLibrary.Gen.MetaEnum;

public enum EEntityAttachmentFlags
{
	eEAF_None = 0,
	eEAF_PreserveOffset = 1,
	eEAF_EnableCollision = 2,
	eEAF_MatchBolterScale = 4,
	eEAF_SingleFrame = 8,
	eEAF_KeepAngles = 0x10,
	eEAF_MatchBolterOverriddenScale = 0x20,
	eEAF_NoCollide = 0x40,
	eEAF_ForceNetReplicateDisable = 0x80,
	eEAF_UseBolterOverrideMatrix = 0x100,
	eEAF_RefBoltPoint = 0x200
}
