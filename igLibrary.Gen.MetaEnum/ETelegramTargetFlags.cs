namespace igLibrary.Gen.MetaEnum;

public enum ETelegramTargetFlags
{
	eTTF_None = 0,
	eTTF_SendMessageToSelf = 1,
	eTTF_SendMessageToActivator = 2,
	eTTF_SendMessageToWorldEntity = 4,
	eTTF_SendMessageToPlayers = 8,
	eTTF_SendMessageToClosestPlayer = 0x10,
	eTTF_SendMessageToFarthestPlayer = 0x20,
	eTTF_SendMessageToParent = 0x40,
	eTTF_SendMessageToVehicle = 0x80
}
