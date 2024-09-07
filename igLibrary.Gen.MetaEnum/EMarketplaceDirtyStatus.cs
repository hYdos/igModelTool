namespace igLibrary.Gen.MetaEnum;

public enum EMarketplaceDirtyStatus
{
	eMDS_None = 0,
	eMDS_InventoryChanged = 1,
	eMDS_BalancesChanged = 2,
	eMDS_StoreProductsChanged = 4,
	eMDS_StorePurchasesChanged = 8,
	eMDS_AllChanged = 15
}
