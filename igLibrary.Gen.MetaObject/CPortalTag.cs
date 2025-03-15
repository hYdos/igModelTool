using CauldronModels.igLibrary.Gen.MetaEnum;
using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class CPortalTag : igObject
{
	public bool _headerDataReady;

	public bool _headerDataStored;

	public uint _serialNumber;

	public uint _virtualTagUid;

	public kTfbSpyroTag_ToyType _toyType;

	public kTfbSpyroTag_HatType _hatType;

	public sbyte[] _secretCode;

	public kTfbSpyroTag_DecoID _decoId;

	public bool _lightCore;

	public bool _fullAltDeco;

	public bool _wowPow;

	public ESkylandersGame _yearCode;

	public bool _magicMomentDataReady;

	public bool _magicMomentDataStored;

	public EPlayerId _magicMomentDataStoredForPlayer;

	public EVehicleId _magicMomentDataStoredForVehicle;

	public ERacingPackId _magicMomentDataStoredForRacingPack;

	public byte _platformUse;

	public byte _platformUse2;

	public char[] _name;

	public uint _cumulativeTime;

	public int _elementCollectionCount1;

	public int _elementCollectionCount2;

	public int _accoladeRank2;

	public kTfbSpyroTag_VillainType _trapVillain;

	public bool _remainingDataReady;

	public bool _remainingDataStored;

	public EPlayerId _remainingDataStoredForPlayer;

	public EVehicleId _remainingDataStoredForVehicle;

	public ERacingPackId _remainingDataStoredForRacingPack;

	public bool _ownerIdReady;

	public bool _ownerIdStored;

	public EPortalTagState _state;

	public EPortalTagState _nextState;

	public EPortalTagState _errorState;

	public ulong _spyroTag;

	public byte[] _spyroTagHeader;

	public byte[] _spyroTagData;

	public byte[] _spyroTagDataTrap;

	public byte[] _spyroTagDataMagicMoment;

	public byte[] _spyroTagDataRemaining;

	public byte[] _spyroTagDataMagicMomentTrap;

	public byte[] _spyroTagDataRemainingTrap;

	public byte[] _spyroTagOwnerId;

	public byte[] _workBuffer;

	public bool _pendingWrite;

	public bool _pendingReset;

	public bool _pendingRecover;

	public bool _pendingReRead;

	public bool _pendingOwnerIdWrite;

	public igHandle _player;

	public EVehicleId _vehicleId;

	public ERacingPackId _racingPackId;

	public bool _mainTag;

	public int _errorCount;

	public bool _toyAddedToPortal;

	public bool _pendingRemoveToy;

	public CTimer _activeTimer;

	public CTimer _saveTimer;

	public igTimeOfDay _tagFirstOnPortalTime;

	public bool _blockWrite;

	public bool _disableWrite;

	public bool _forceHighPriorityNextWrite;

	public bool _forceInstantNextWrite;

	public bool _nextSaveAsIs;

	public bool _forceWriteOnIdle;

	public bool _isWriting;

	public bool _isDebug;

	public bool _isVirtual;

	public bool _isLockedByDefault;

	public bool _canBeRemoved;

	public bool _assignedForRace;

	public bool _pendingDepart;

	public bool _hasError;

	public CToyUsageOnPlatform _platformToyUsage;

	public uint _cachedVehicleExperience;

	public uint _cachedVehicleUpgradeFlags;

	public uint _cachedMods;

	public bool _modsStored;

	public bool _modsReceived;

	public bool _updateRemotePlayerValues;

	public bool _vehicleLoadedAtEndOfLevel;

	public ushort _cachedPersonalizationColorScheme;

	public bool _personalizationColorSchemeStored;

	public bool _personalizationColorSchemeReceived;

	public ushort _cachedPersonalizationTopper;

	public bool _personalizationTopperStored;

	public bool _personalizationTopperReceived;

	public ushort _cachedPersonalizationNeon;

	public bool _personalizationNeonStored;

	public bool _personalizationNeonReceived;

	public ushort _cachedPersonalizationTaunt;

	public bool _personalizationTauntStored;

	public bool _personalizationTauntReceived;
}
