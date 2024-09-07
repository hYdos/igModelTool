namespace igLibrary.Gen.MetaEnum;

public enum EGameEntityDataFlags
{
	eGEDF_None = 0,
	eGEDF_AnimActive = 0x80,
	eGEDF_AnimInReverse = 0x100,
	eGEDF_ActTogglesAnim = 0x200,
	eGEDF_NoKillZ = 0x800,
	eGEDF_KillOnRemoval = 0x8000,
	eGEDF_ScaleMovementSpeed = 0x20000,
	eGEDF_ReceiveOcclusionBoxMessages = 0x80000
}
