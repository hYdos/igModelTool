namespace igLibrary.Gen.MetaEnum;

public enum EEntityDataFlags
{
	eEDF_None = 0,
	eEDF_NoGravity = 4,
	eEDF_IsWorld = 8,
	eEDF_NoCollision = 0x10,
	eEDF_NoPush = 0x20,
	eEDF_NoDifficultyAdjust = 0x80,
	eEDF_NoClip = 0x200,
	eEDF_RemoveOnCutscene = 0x400,
	eEDF_StopTeamHero = 0x1000,
	eEDF_StopNPCNeutral = 0x2000,
	eEDF_StopNPCEnemy = 0x4000,
	eEDF_StopNPCAltEnemy = 0x8000,
	eEDF_StopProjectile = 0x10000,
	eEDF_StopDebris = 0x20000,
	eEDF_StopWorld = 0x80000,
	eEDF_Targetable = 0x200000,
	eEDF_NetReplicate = 0x400000,
	eEDF_NetAuthorityCanMigrate = 0x800000,
	eEDF_NetLowPriority = 0x1000000,
	eEDF_NetAlwaysOfInterest = 0x2000000,
	eEDF_IsLevelBorder = 0x4000000,
	eEDF_StopPlayers = 0x8000000,
	eEDF_StopLevelBorder = 0x10000000
}
