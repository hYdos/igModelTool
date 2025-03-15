using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CModelInstance : igObject
{
	public bool mIsLinked;

	public CGameEntity mEntity;

	public igModelInstance mIgModel;

	public CModelInstance mBoltTargetModel;

	public CBoltedModelList mBoltedModels;
}
