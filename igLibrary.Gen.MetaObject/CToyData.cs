using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject
{
	public class CToyData : igObject
	{
		public global::CauldronModels.igLibrary.Gen.MetaEnum.kTfbSpyroTag_ToyType _toyId;
		public global::CauldronModels.igLibrary.Gen.MetaEnum.EElementType _elementType;
		public System.String _toyName;
		public System.String _hudToyName;
		public System.String _seriesName;
		public CVariantIdentifierList _variants;
		public global::igLibrary.Core.igHandle _toyCollectionMaterial;
		public global::igLibrary.Core.igHandle _faceOffPortraitMaterial;
		public System.Boolean _availableInE3Demo;
	}
}