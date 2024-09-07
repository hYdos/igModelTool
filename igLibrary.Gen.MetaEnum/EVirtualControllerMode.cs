namespace igLibrary.Gen.MetaEnum;

public enum EVirtualControllerMode
{
	eVCM_Default = 1,
	eVCM_CoopSwap = 2,
	eVCM_ShrinkRay = 4,
	eVCM_Magnet = 8,
	eVCM_Interact = 16,
	eVCM_Teleport = 32,
	eVCM_VehicleMods = 64,
	eVCM_LegendaryTreasurePlace = 128,
	eVCM_LegendaryTreasurePickup = 256,
	eVCM_LockPick = 512,
	eVCM_All = 1023,
	eVCM_Max = 1024
}
