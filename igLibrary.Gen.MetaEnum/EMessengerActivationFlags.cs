namespace igLibrary.Gen.MetaEnum;

public enum EMessengerActivationFlags
{
	eMAF_None = 0,
	eMAF_OnAct = 1,
	eMAF_OnDamage = 2,
	eMAF_OnDeath = 4,
	eMAF_OnEnter = 8,
	eMAF_OnExit = 0x10,
	eMAF_OnRemove = 0x40,
	eMAF_OnStart = 0x80,
	eMAF_OnTouch = 0x100
}
