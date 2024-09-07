namespace igLibrary.Gen.MetaEnum;

public enum EScriptTriggerFlags
{
	eSTF_None = 0,
	eSTF_OnlyPlayersCanTrigger = 0x80,
	eSTF_SingleFire = 0x100,
	eSTF_ProcessMagicMoment = 0x200,
	eSTF_AllowKeyframedEntities = 0x400,
	eSTF_IsDirectional = 0x800
}
