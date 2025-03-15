using CauldronModels.igLibrary.Gen.MetaEnum;
using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CCharacterPortalData : igObject
{
	public string _characterName;

	public EElementType _elementType;

	public ESkylanderType _skylanderType;

	public CUniqueToyList _requiredToyIds;

	public EPlayerId _playerId;
}
