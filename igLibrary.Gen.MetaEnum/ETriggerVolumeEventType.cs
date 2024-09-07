namespace igLibrary.Gen.MetaEnum;

public enum ETriggerVolumeEventType
{
	eTVET_None = 0,
	eTVET_Enter = 1,
	eTVET_Exit = 2,
	eTVET_Touch = 4,
	eTVET_Act = 8,
	eTVET_DeAct = 0x10,
	eTVET_SendEntityEvent = 0x20,
	eTVET_NetworkEnabled = 0x40
}
