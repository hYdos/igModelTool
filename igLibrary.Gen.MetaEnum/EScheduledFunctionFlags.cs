namespace igLibrary.Gen.MetaEnum;

public enum EScheduledFunctionFlags
{
	eSSF_None = 0,
	eSSF_Loop = 1,
	eSSF_TimeAsFrames = 2,
	eSSF_IgnoreGamePause = 4,
	eSSF_IgnoreGameSlomo = 8,
	eSSF_Paused = 0x10,
	eSSF_Stopped = 0x20,
	eSSF_Running = 0x40,
	eSSF_RunOnCleanup = 0x80
}
