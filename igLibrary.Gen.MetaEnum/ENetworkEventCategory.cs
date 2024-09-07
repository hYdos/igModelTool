namespace igLibrary.Gen.MetaEnum;

public enum ENetworkEventCategory
{
	eNEC_Invalid = -1,
	eNEC_Reserved = 0,
	eNEC_GameStart = 10000,
	eNEC_LevelEnd = 10001,
	eNEC_LevelStart = 10002,
	eNEC_MatchEnd = 10003,
	eNEC_StorePurchase = 10004,
	eNEC_TabletPurchase = 10005,
	eNEC_StoreEntry = 10006,
	eNEC_MessageClick = 10007,
	eNEC_MessageView = 10008,
	eNEC_ToyChange = 10009,
	eNEC_Skystones = 10010,
	eNEC_LockPuzzle = 10011,
	eNEC_MiniGame = 10012,
	eNEC_SoulGem = 10013,
	eNEC_ToyDeath = 10014,
	eNEC_ToyLevelUp = 10015,
	eNEC_NPCInteraction = 10016,
	eNEC_ModeSelected = 10017,
	eNEC_MenuClosed = 10018,
	eNEC_DriverChallenge = 10019,
	eNEC_ElementalZone = 10020,
	eNEC_ComscoreStart = 10000,
	eNEC_ComscoreEnd = 10019
}
