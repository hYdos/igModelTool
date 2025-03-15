using System.Runtime.InteropServices;
using CauldronModels.igLibrary.Gen.MetaObject;

namespace CauldronModels.igLibrary.Gen.igMetaField;

[StructLayout(3)]
public struct CBoltedModelMetaField
{
	public CModelInstance _model;

	public string _boltName;
}
