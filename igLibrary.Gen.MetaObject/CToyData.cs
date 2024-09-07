namespace igLibrary
{
	public class CToyData : Core.igObject
	{
		public igLibrary.Gen.MetaEnum.kTfbSpyroTag_ToyType _toyId;
		public igLibrary.Gen.MetaEnum.EElementType _elementType;
		public System.String _toyName;
		public System.String _hudToyName;
		public System.String _seriesName;
		public CVariantIdentifierList _variants;
		public igLibrary.Core.igHandle _toyCollectionMaterial;
		public igLibrary.Core.igHandle _faceOffPortraitMaterial;
		public System.Boolean _availableInE3Demo;
	}
}