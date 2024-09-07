namespace igLibrary.Gen.MetaEnum;

public enum EOptionsSaveVersion
{
	eOSV_INVALID = -1,
	eOSV_initialVersion = 0,
	eOSV_AddedToyAccoladesToGlobalSave = 1,
	eOSV_AllToyCollectiblesToGlobalSave = 2,
	eOGV_GameStateToGlobalSave = 3,
	eOGV_AddedLocksAndSkystonesToSave = 4,
	eOSV_SoulGemDropRate = 5,
	eOSV_AddedPortalMasterStats = 6,
	eOGV_AddedCollectibleTrackerGroupsAndMiscGameStates = 7,
	eOGV_AnalyticsFunnelsAddedToGameState = 8,
	eOGV_AnalyticsElementalZoneEnteredAddedToGameState = 9,
	eOGV_AnalyticsAddNewLeaderboard = 10,
	eOGV_AnalyticsAddTimePlayedWithHeroTracking = 11,
	eOGV_AnalyticsAddMoreLeaderboardTracking = 12,
	eOGV_AnalyticsAddGearbitsSpent = 13,
	eOGV_AnalyticsAddElementalGateAndDriverChallengeFunnels = 14,
	eOGV_AnalyticsMoreElementalGateAndDriverChallengeStats = 15,
	eOGV_AddedLicenseAgreement = 16,
	eOGV_AddedPurchaseAnalytics = 17,
	eOSV_NEXT_VERSION = 18,
	LATEST_GLOBAL_SAVE_VERSION = 17,
	INITIAL_GLOBAL_SUBMISSION_VERSION = 6
}
