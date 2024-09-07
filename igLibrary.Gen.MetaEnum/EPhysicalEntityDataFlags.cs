namespace igLibrary.Gen.MetaEnum;

public enum EPhysicalEntityDataFlags
{
	ePEDF_None = 0,
	ePEDF_NoDamageNumbers = 4,
	ePEDF_Undying = 0x10,
	ePEDF_RemoveOnDeath = 0x80,
	ePEDF_DespawnOnKill = 0x100,
	ePEDF_IDealMoveDamage = 0x200,
	ePEDF_NoDifficultyHealthAdjust = 0x400
}
