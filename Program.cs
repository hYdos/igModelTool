using System.Reflection;
using CauldronModels.api;
using CauldronModels.api.model;
using CauldronModels.igLibrary.Gen.igMetaField;
using CauldronModels.igLibrary.Gen.MetaEnum;
using CauldronModels.igLibrary.Gen.MetaObject;
using igLibrary;
using igLibrary.Core;
using igLibrary.Entity;
using igLibrary.Gfx;
using igLibrary.Graphics;
using igLibrary.Math;
using igLibrary.Render;
using IG_GFX_DRAW = igLibrary.Gfx.IG_GFX_DRAW;
using IG_INDEX_TYPE = igLibrary.Gfx.IG_INDEX_TYPE;
using igAnimatedMorphWeightsTransform = igLibrary.Sg.igAnimatedMorphWeightsTransform;
using igAnimatedTransform = igLibrary.Sg.igAnimatedTransform;
using igGraphicsIndexBuffer = igLibrary.Graphics.igGraphicsIndexBuffer;
using igGraphicsVertexBuffer = igLibrary.Graphics.igGraphicsVertexBuffer;
using igIndexBuffer = igLibrary.Gfx.igIndexBuffer;
using igIndexFormat = igLibrary.Gfx.igIndexFormat;
using igVertexBuffer = igLibrary.Gfx.igVertexBuffer;
using Type = CauldronModels.igLibrary.Gen.MetaEnum.Type;

namespace CauldronModels;

internal static class Program {
    /// <summary>
    /// Removes and replaces existing meshes on any igz containing a igModelInfo. This will NOT work on actors for now.
    /// </summary>
    /// <param name="gameContentDir">Path to the game's assets</param>
    /// <param name="updatePakFile">Which flavor to use</param>
    /// <param name="platform">Platform the game is on. Example: IG_CORE_PLATFORM_CAFE</param>
    /// <param name="targetPak">The pak or iga archive you wish to open</param>
    /// <param name="targetModel">The path to the model you want to replace inside the pak or iga</param>
    /// <param name="replacementModelPath">The path pointing to the new model to overwrite the existing model with</param>
    /// <param name="printPlatformData">You don't want this probably</param>
    /// <param name="scale">the amount of scale the model should have. Default is 10</param>
    // ReSharper disable once UnusedMember.Local
    private static void Main(string gameContentDir, string updatePakFile, IG_CORE_PLATFORM platform, string targetPak, string targetModel,
        string replacementModelPath, bool printPlatformData = false, float scale = 10) {
        Console.WriteLine("Loading IgLibrary");
        IgLibraryInit(
            gameContentDir,
            updatePakFile,
            platform
        );

        // var CEntityIDMetaField = System.Type.GetType("igLibrary.Gen.CompoundField.CEntityIDMetaField", "ArkGeneratedTypes");

        Console.WriteLine("Loading Model");
        // Assembly.GetAssembly()
        var replacementModel = new Model(replacementModelPath);

        Console.WriteLine("Adding Skylander");
        CreateToyData("funkykong", new CFullCharacterToyData {
            _toyId = kTfbSpyroTag_ToyType.kTfbSpyroTag_ToyType_Character_FunkyKong,
            _elementType = EElementType.eET_Water,
            _toyName = "Funky Kong",
            _seriesName = "hydos",
            _variants = new CVariantIdentifierList {
                internalMemoryPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!,
                _data = new igMemory<CVariantIdentifier>()
            },
            _faceOffPortraitMaterial = new igHandle(new igHandleName {
                _ns = new igName("Zook_FullScreen_materials"),
                _name = new igName("FaceOff")
            }),
            _characterName = "funkykong",
            _allowSmokeTestSwapAllHeroes = true,
            _allowSmokeTestSwapAllHeroesPS3 = true,
            _allowSmokeTestSwapAllHeroesXenon = true,
            _skylanderType = ESkylanderType.eST_Core
        });

        CreateSkylander("funkykong", replacementModel);

        // TODO: split these into different commands
        // Console.WriteLine("Opening Archives");
        // igSingleton<igFileContext>.Singleton.LoadArchive(targetPak);
        // var srcModel = igSingleton<igObjectStreamManager>.Singleton.Load(targetModel)!;
        //
        // var modelInfo = (igModelInfo)srcModel._objectList.FindObjectByType(typeof(igModelInfo))!;
        // var modelData = modelInfo._modelData;
        // var materialHandle = modelData._drawCalls[0]._materialHandle;
        //
        // if (printPlatformData) {
        //     var i = 0;
        //     foreach (var unused in modelData._drawCalls) {
        //         File.WriteAllBytes("platformData." + i + "}.bin", unused._graphicsVertexBuffer._vertexBuffer._format._platformData.Buffer);
        //         i++;
        //     }
        // }
        //
        // Console.WriteLine("Building Model");
        // modelData._drawCalls = BuildMeshes(replacementModel, materialHandle, scale);
        // modelData._drawCallTransformIndices = new igVector<int>();
        // foreach (var unused in replacementModel.Meshes) {
        //     modelData._drawCallTransformIndices.Append(0);
        // }
        //
        // Console.WriteLine("Saving to update.pak & model.igz");
        // SaveToFile(srcModel, "model.igz");
        // SaveUpdatePak(srcModel);
        // Console.WriteLine("Done, Have Fun.");
        // return 0;

        // var imgFs = new FileStream(@"C:\Users\hydos\Desktop\custommodels\funkykong\DrvChr06_Alb_swizzled.dds", FileMode.Open, FileAccess.Read);
        // var tmpSpan = new byte[4];
        //
        //
        // imgFs.Seek(0x0C, SeekOrigin.Begin);
        // imgFs.Read(tmpSpan, 0, 4);
        // var height = BitConverter.ToInt32(tmpSpan);
        // imgFs.Read(tmpSpan, 0, 4);
        // var width = BitConverter.ToInt32(tmpSpan);
        // imgFs.Seek(0x80, SeekOrigin.Begin);
        // var compressedDataSize = imgFs.Length - imgFs.Position;
        // var compressedData = new byte[compressedDataSize];
        // imgFs.Read(compressedData, 0, (int)compressedDataSize);
        //
        // var material = element0._materialHandle.GetObjectAlias<igGraphicsMaterial>();
        // var textureObj = (igGraphicsTexture)material!._graphicsObjects._objects[0];
        // var (image, imgDir) = textureObj._imageHandle.GetObjectAlias2<igImage2>();
        // Console.WriteLine($"Texture type: {image!._format._name}");
        // image._width = (ushort)width;
        // image._height = (ushort)height;
        // var size = width * height * image._format._bitsPerPixel / 8;
        // image._data.Realloc(size);
        // for (var i = 0; i < size; i++) image._data[i] = compressedData[i];
        // SaveToFile(imgDir!, "test_img.igz");
        // SaveUpdatePak(imgDir!);
    }

    private static void CreateSkylander(string name, Model model) {
        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        var skylanderPkg = new AlchemyPkg($"characters/{name}");

        var portrait = skylanderPkg.NewIgz(AlchemyPkg.ObjectType.actorskin, $"actors/skylanders/driver_hudportraits/{name}_hudportrait");
        WriteSkin(portrait, model);
        var skin = skylanderPkg.NewIgz(AlchemyPkg.ObjectType.actorskin, $"actors/{name}");
        WriteSkin(skin, model);
        
        igSingleton<igFileContext>.Singleton.LoadArchive("app:/archives/BallChain.pak");
        CPrecacheManager._Instance.PrecachePackage("generated/characters/ballchain", EMemoryPoolID.MP_DEFAULT);
        var baseCharData = igSingleton<igObjectStreamManager>.Singleton.Load("characters/skylanders/ballchain_characterdata.igz")!;
        CActorData? oldActorData = null;
        
        for (var i = 0; i < baseCharData._nameList!._count; i++) {
            var test = baseCharData._nameList[i];
            if (test._string.Equals("BallChain")) {
                oldActorData = (CActorData)baseCharData._objectList[i];
            }
        }

        var deepCopyComponentData = new igComponentDataTable
        {
            internalMemoryPool = defaultPool
        };
        foreach (var (key, value) in (igComponentDataTable)oldActorData._componentData)
        {
            deepCopyComponentData.Add(key,value);
        }
        
        var behaviours = skylanderPkg.NewIgz(AlchemyPkg.ObjectType.graphdata_behavior, $"behaviors/skylanders/{name}/{name}");
        var combat = skylanderPkg.NewIgz(AlchemyPkg.ObjectType.graphdata_behavior, $"behavior_events/skylanders/{name}_combat");
        var characterData = skylanderPkg.NewIgz(AlchemyPkg.ObjectType.character_data, $"characters/skylanders/{name}_characterdata");
        var actorTags = new CEntityTagSet {
            internalMemoryPool = defaultPool,
            _keys = new igMemory<igObject>(),
            _values = new igMemory<bool>()
        };
        actorTags.Add(new CEntityTag {
            internalMemoryPool = defaultPool,
            _name = "EntityType_PlayableCharacter"
        }, true);
        var cActorData = new CActorData {
            internalMemoryPool = defaultPool,
            _componentData = deepCopyComponentData,
            _scale = 1,
            _entityFlags = oldActorData._entityFlags,
            _actionEntityFlags = oldActorData._actionEntityFlags,
            _team = EEntityTeam.eET_Hero,
            _teamFaction = EEntityTeamFaction.eETF_None,
            _tags = actorTags,
            _gameEntityFlags = oldActorData._gameEntityFlags,
            _distanceCullImportance = DistanceCullImportance.kMedium,
            _collisionLayer = ETeamFilterLayers.eTFL_Entity,
            _collisionPriority = ECharacterCollisionPriority.eCCP_Normal,
            _castsShadows = true,
            _mobileShadowState = EMobileShadowState.eMSS_LetGameDecide,
            _cachedAssetPool = EMemoryPoolID.MP_MAX_POOL,
            _health = 500, // possibly overriden by BaseAttributes
            _healthMax = 500,
            _vulnerability = EVulnerability.eV_CanBeDamaged,
            _actorDataFlags = 0b10000,
            _character = name,
            _skin = name,
            _magicMomentSpawnBackgroundVfxOverrideTime = -1,
            _magicMomentSpawnOutroVfxOverrideTime = 3.15f,
            _magicMomentStartEndVfxOverrideTime = 3.15f,
            _magicMomentPauseIntroAnimationOverrideTime = 3.05f,
            _magicMomentJumpOutTimeFromEndOverride = -1,
            _soundBankHandleList = new CAudioArchiveHandleList { internalMemoryPool = defaultPool },
            _takeHitReactDirections = EAllowedHitReactDirections.eAHRD_FrontBackLeftRight,
            _partialHitReactDirections = EAllowedHitReactDirections.eAHRD_NoReaction,
            _knockawayReactDirections = EAllowedHitReactDirections.eAHRD_NoReaction,
            _deathReactDirections = EAllowedHitReactDirections.eAHRD_Front,
            _knockawayDeathReactDirections = EAllowedHitReactDirections.eAHRD_NoReaction,
            _hudPortrait = new igHandle(new igHandleName {
                _ns = new igName(0x18ac14d8),
                _name = new igName(0xae062793)
            })
        };
        characterData.AddObject(cActorData, default, new igName(name));
        
        characterData.AddObject(new CCharacterAttributes {
            internalMemoryPool = defaultPool,
            _maximumHealth = 69420,
            _baseResistance = 30,
            _strengthSuperchargeBoost = 10,
            _speed = 43,
            _criticalHitChance = 100
        }, default, new igName("BaseAttributes"));
        
        characterData.AddObject(new CActor {
            internalMemoryPool = defaultPool,
            _entityData = cActorData,
            _transform = new igEntityTransform {
                internalMemoryPool = defaultPool,
                _parentSpaceOrientation = new igQuaternionf(0, 0, 0, 1), // identity quat
                _parentSpaceTransform = new igMatrix44f([
                        1, 0, 0, 0,
                        0, 1, 0, 0,
                        0, 0, 1, 0,
                        0, 0, 0, 1
                ]), // identity mtx
                _runtimeParentSpaceScale = 1,
                _nonUniformPersistentParentSpaceScale = new igVec3f(1, 1, 1),
                _isDirty = true
            },
            _bitfield = 0b110000000010000011,
            _canSpawn = true,
            _isArchetype = true,
            _enabledByVisualScript = true, // TODO: Might be an issue without scripts...
            _enabled = false, // TODO: try make this true instead if needed
            _isVolumeCulled = true,
            _canVolumeCull = true,
            _min = new igVec3f(-15, -15, -15),
            _max = new igVec3f(15, 15, 15),
            _flags = new byte[1],
            _id = new CEntityID(),
            _properties = 0b10000,
            _actToggleOn = true,
            _scaleSource = EScaleSource.eSS_Entity,
            _castsShadows = ECastsShadows.ECS_Archetype,
            _mobileShadowStateOverride = EMobileShadowStateOverride.eMSSO_Archetype,
            _healthMax = -1,
            _unadjustedMaxHealth = -1,
            _vulnerability = EVulnerability.eV_Invalid,
            _invulnerable = new CEnableRequestManager { internalMemoryPool = defaultPool },
            _recentAttackNumberTimestampTable = new CAttackNumberTimestampTable {
                internalMemoryPool = defaultPool,
                _keys = new igMemory<uint>(),
                _values = new igMemory<uint>()
            },
            _recentAttackImmunityTimestampTable = new CAttackImmunityTimestampTable {
                internalMemoryPool = defaultPool,
                _keys = new igMemory<string>(),
                _values = new igMemory<uint>()
            },
            _runtimeFlags = 0b1,
            _removeOnDeath = true,
            _nonPersistentBitfield = 0b1000,
            _cameraRelativeMovementTransform = new CTransform(),
            _heroShadowFade = 1,
            mLastHitEnt = new CEntityID {  },
            mLastAttackedBy = new CEntityID {  },
            _combatTargets = new CCombatTargetDataListList {
                internalMemoryPool = defaultPool,
                _data = new igMemory<CCombatTargetDataList>()
            },
            _collectiblesFilters = new CCollectibleFilterList {
                internalMemoryPool = defaultPool,
                _data = new igMemory<CCollectibleFilter>()
            },
            _canCollectCollectibles = true,
            _actorInput = new ActorInput {
                internalMemoryPool = defaultPool,
                _input = new ActorInputCommand { internalMemoryPool = defaultPool },
                _touchDuration = new CTimer {
                    internalMemoryPool = defaultPool,
                    _timerType = ETimerType.eTT_Game
                },
            },
            _ignoreHitReacts = new CEnableRequestManager { internalMemoryPool = defaultPool },
            _ignorePartialHitReacts = new CEnableRequestManager { internalMemoryPool = defaultPool },
            _ignoreHitPushBack = new CEnableRequestManager { internalMemoryPool = defaultPool },
            _targetableFlag = new CTargetableFlagEnableStack {
                internalMemoryPool = defaultPool,
                _mode = EEnableStackMode.eESM_StartEnabled,
                _allowNegativeStackRequests = 1,
                _enableErrorMessage = "RequestEnable() has been called more times than RequestDisable()",
                _disableErrorMessage = "RequestDisable() has been called more times than RequestEnable()"
            },
            _spawnedVfx = new CSpawnedActorVfxList {
                internalMemoryPool = defaultPool,
                _data = new igMemory<CSpawnedActorVfx>()
            },
            _timeScaleList = new CActorTimeScaleNonRefcountedList {
                internalMemoryPool = defaultPool,
                _data = new igMemory<CActorTimeScale>()
            },
            _allowTimeScaling = new CTimeScaleEnableStack {
                internalMemoryPool = defaultPool,
                _mode = EEnableStackMode.eESM_StartEnabled,
                _allowNegativeStackRequests = 0,
                _enableMismatchedCallChecks = true,
                _enableErrorMessage = "RequestEnable() has been called more times than RequestDisable()",
                _disableErrorMessage = "RequestDisable() has been called more times than RequestEnable()"
            },
            _freezeFrameTimeScale = new CActorTimeScale { internalMemoryPool = defaultPool, _timeScale = 1 },
            _muted = new CEnableRequestManager { internalMemoryPool = defaultPool },
            _changeRequests = new CChangeRequestList {
                internalMemoryPool = defaultPool,
                _data = new igMemory<CChangeRequest>()
            },
            _hasBaseVehicleControllerComponent = true
        }, default, new igName($"{name}_Character"));

        var componentTable = new igComponentDataTable {
            internalMemoryPool = defaultPool,
            _keys = new igMemory<string>(),
            _values = new igMemory<igObject>()
        };
        // FillDefaultSkylanderComponentTable(componentTable, name); FIXME: waiting on IgLibrary fixes. for now maybe copy with IgCauldron?
        characterData.AddObject(componentTable, default, new igName($"{name}_componentData"));

        skylanderPkg.Save();
    }

    private static void FillDefaultSkylanderComponentTable(igComponentDataTable table, string skylanderName) {
        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        
        igSingleton<igFileContext>.Singleton.LoadArchive("app:/archives/BallChain.pak");
        CPrecacheManager._Instance.PrecachePackage("generated/characters/ballchain", EMemoryPoolID.MP_DEFAULT);
        var baseCharData = igSingleton<igObjectStreamManager>.Singleton.Load("characters/skylanders/ballchain_characterdata.igz")!;
        igComponentDataTable? baseComponentTable = null;
        
        for (int i = 0; i < baseCharData._nameList!._count; i++) {
            var name = baseCharData._nameList[i];
            if (name._string.Equals("BallChain_componentData")) {
                baseComponentTable = (igComponentDataTable)baseCharData._objectList[i];
            }
        }
        
        var behaviourLogic = new CBehaviorLogicDataTable {
            internalMemoryPool = defaultPool,
            _keys = new igMemory<string>(),
            _values = new igMemory<igObject>()
        };
        behaviourLogic.Add("CGroundLocomotionHandler", new CGroundLocomotionHandler {
            internalMemoryPool = defaultPool,
            _activators = Utils.NewStringHashTable(("state_sharedgroundlocomotion", "GroundLocomotion")),
            _excludeActivators = Utils.NewStringHashTable(),
            _transitionTimeToWalkState = 0.05f,
            _transitionTimeToIdleState = 0.05f,
            _runTimeForStop = 9000
        });
        // behaviourLogic.Add(); TODO: the rest
        
        table.Add("archetype_CHatBoltComponentData", new CHatBoltComponentData { internalMemoryPool = defaultPool, _isEnabled = true, _bitfield = 1 });
        table.Add("archetype_CMaterialOverrideCombinerComponentData", new CMaterialOverrideCombinerComponentData { internalMemoryPool = defaultPool, _isEnabled = true, _bitfield = 1 });
        table.Add("archetype_CProxyComponentData", new CProxyComponentData { internalMemoryPool = defaultPool, _isEnabled = true, _bitfield = 1 });
        // table.Add("archetype_Scripts.SpawnOnEventsComponentData", new Scripts_SpawnOnEventsComponentData {
        //     internalMemoryPool = defaultPool,
        //     
        // });
        // table.Add("archetype_CBasePhysicsComponentData", new CBehaviorPhysicsPencilComponentData { });
        // table.Add("archetype_Scripts.Graph.PortalMasterPerkLogicMiscData", new Scripts.Graph.PortalMasterPerkLogicSkylandersData { });
        // table.Add("archetype_CWaypointMoverComponentData", new CWaypointMoverComponentData { });
        // // table.Add("archetype_CGiantComponentData", new CGiantComponentData {}); // Giants Only
        // table.Add("archetype_CPlayerHudComponentData", new CPlayerHudComponentData { });
        // table.Add("archetype_CNetworkPlayerMovingPlatformComponentData", new CNetworkPlayerMovingPlatformComponentData { });
        // table.Add("archetype_CScreenspaceCharacterSettingsComponentData", new CScreenspaceCharacterSettingsComponentData { });
        // table.Add("archetype_CPlayerRespawnComponentData", new CPlayerRespawnComponentData { });
        // table.Add("archetype_Scripts.DamageDampeningComponentData", new Scripts.DamageDampeningComponentData { });
        // table.Add("archetype_CNetworkDisablePreTeleportActorReplicationComponentData", new CNetworkDisablePreTeleportActorReplicationComponentData { });
        // table.Add("archetype_CCameraTargetComponentData", new CCameraTargetComponentData { });
        // table.Add("archetype_CSkillsUpgradeComponentData", new CSkillsUpgradeComponentData { });
        // table.Add("archetype_CMovementControllerComponentData", new CMovementControllerComponentData { });
        // table.Add("archetype_Scripts.CancelAttackComponentData", new Scripts.CancelAttackComponentData { });
        // table.Add("archetype_Scripts.BoltOnComponentData", new Scripts.BoltOnComponentData { });
        // table.Add("archetype_CCarriedEntitiesComponentData", new CCarriedEntitiesComponentData { });
        // table.Add("archetype_CNavMoverComponentData", new CNavMoverComponentData { });
        // table.Add("archetype_Scripts.CelebrateLevelUpComponentData", new Scripts.CelebrateLevelUpComponentData { });
        // table.Add("archetype_CInElementalZoneComponentData", new CInElementalZoneComponentData { });
        // table.Add("archetype_CRailSlideTimeSettingComponentData", new CRailSlideTimeSettingComponentData { });
        // table.Add("archetype_CPointOfInterestComponentData", new CPointOfInterestComponentData { });
        // table.Add("archetype_Scripts.CelebrateAbilityUpgradeComponentData", new Scripts.CelebrateAbilityUpgradeComponentData { });
        // table.Add("archetype_CHeroicChallengeBoostComponentData", new CHeroicChallengeBoostComponentData { });
        // table.Add("archetype_CPlayer3dHudPortraitComponentData", new CPlayer3dHudPortraitComponentData { });
        table.Add("archetype_CBehaviorComponentData", new CBehaviorComponentData {
            internalMemoryPool = defaultPool,
            _isEnabled = false, // TODO: Waiting on HAVOK. hurry up, me 
            _bitfield = 1,
            _behaviorFile = $@"behaviors:\Skylanders\{skylanderName}\{skylanderName}.hkp",
            _behaviorEventsFile = $@"behavior_events:\Skylanders\{skylanderName}_combat.igx", // TODO: this is invalid & probably from SwapForce... But SSC still has this?
            _eventFilterData = new CBehaviorEventFilterData {
                internalMemoryPool = defaultPool,
                _filterItems = new  CBehaviorEventFilterTable {
                    internalMemoryPool = defaultPool,
                    _keys = new igMemory<int>(),
                    _values = new igMemory<igObject>()
                }
            },
            _handlers = behaviourLogic
        });
        // table.Add("archetype_CCharacterProgressionComponentData", new CCharacterProgressionComponentData { });
        // table.Add("archetype_CAccoladeComponentData", new CAccoladeComponentData { });
        // table.Add("archetype_CPlayerRingComponentData", new CPlayerRingComponentData { });
        // table.Add("archetype_CPlayerRingComponentData", new CPlayerRingComponentData { });
        // table.Add("archetype_CInterruptManagerComponentData", new CInterruptManagerComponentData { });
        // table.Add("archetype_CPVPStrengthComponentData", new CPVPStrengthComponentData { });
        // // table.Add("archetype_CNetworkAnimationReplicaComponentData", new CHatBoltComponentData {}); // TODO: anims
        // table.Add("archetype_CPlayerAttackComponentData", new CPlayerAttackComponentData { });
    }

    private static void WriteSkin(igObjectDirectory skin, Model model) {
        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        var materialInfo = new CMaterialHandleTableInfo {
            internalMemoryPool = defaultPool,
            _handleTable = new igStringInsensitiveStringHashTable {
                internalMemoryPool = defaultPool,
                _keys = new igMemory<string>(),
                _values = new igMemory<string>()
            },
            _resolveState = true
        };

        materialInfo._handleTable.Add("Maggs_Staff_materials.metal", "Maggs_Staff_materials,Maggs_Staff,1.metal");

        skin.AddObject(materialInfo, default, default);

        var modelData = new igModelData {
            internalMemoryPool = defaultPool,
            _min = new igVec4f(-1, -1, -1, 0),
            _max = new igVec4f(0, 0, 0, 1),
            _transforms = new igVector<igAnimatedTransform>(),
            _transformHierarchy = new igVector<int>(),
            _drawCalls = BuildMeshes(model, new igHandle(new igHandleName {
                _ns = new igName("Maggs_Staff_materials,Maggs_Staff,1"),
                _name = new igName("metal"),
            }), 10),
            _drawCallTransformIndices = new igVector<int>(),
            _morphWeightTransforms = new igVector<igAnimatedMorphWeightsTransform>(),
            _blendMatrixIndices = new igVector<int>(),
        };
        foreach (var unused in model.Meshes) {
            modelData._drawCallTransformIndices.Append(0);
        }

        skin.AddObject(new CGraphicsSkinInfo {
            internalMemoryPool = defaultPool,
            _resolveState = true,
            _skeleton = new igSkeleton2 {
                internalMemoryPool = defaultPool,
                _name = "DefaultSkeleton_0",
                _boneList = new igSkeletonBoneList { internalMemoryPool = defaultPool },
                _inverseJointArray = new igMemory<igMatrix44f>()
            },
            _skin = modelData,
            _boltPointIndexArray = new igStringIntHashTable {
                internalMemoryPool = defaultPool,
                _keys = new igMemory<string>(),
                _values = new igMemory<int>()
            },
            _boundsMin = new igVec3f(-100, -100, -100),
            _boundsMax = new igVec3f(100, 100, 100)
        }, default, default);
    }

    private static void CreateToyData(string name, CFullCharacterToyData fullToyData) {
        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        fullToyData.internalMemoryPool = defaultPool;

        var toydataPath = "toydata/" + name;
        var toydata = Utils.NewIgz(toydataPath);
        toydata.AddObject(fullToyData, default, new igName(name + "_ToyData"));

        var pkg = igSingleton<igObjectStreamManager>.Singleton.Load("packages/generated/packagexmls/permanent_pkg.igz")!;
        var objectDir = (igStringRefList)pkg._objectList[0];
        objectDir.Append("igx_file");
        objectDir.Append(toydataPath + ".igz");
        SaveUpdatePak(pkg);

        var permanent = igSingleton<igFileContext>.Singleton.LoadArchive("app:/archives/permanent.pak");
        var memoryStream = new MemoryStream();
        toydata.WriteFile(memoryStream, igRegistry.GetRegistry()._platform);
        memoryStream.Seek(0L, SeekOrigin.Begin);
        var fp = new igFilePath();
        fp.Set(toydata._path);
        permanent.GetAddFile(fp._path);
        permanent.Compress(fp._path, memoryStream);
        memoryStream.Close();

        if (permanent._path[1] == ':')
            permanent.Save(permanent._path);
        else
            permanent.Save(igSingleton<igFileContext>.Singleton._root + "/archives/" + Path.GetFileName(permanent._path));
    }

    private static igVector<igModelDrawCallData> BuildMeshes(Model model, igHandle defaultMaterial, float scale) {
        var drawCalls = new igVector<igModelDrawCallData>();

        foreach (var compiledMesh in model.Meshes) {
            drawCalls.Append(BuildMesh(compiledMesh, defaultMaterial, scale));
        }

        return drawCalls;
    }

    private static igModelDrawCallData BuildMesh(CompiledMesh mesh, igHandle defaultMaterial, float scale) {
        const IG_GFX_DRAW primitive = IG_GFX_DRAW.IG_GFX_DRAW_TRIANGLES;
        var vertexFmtBuilder = new AutomatedVertexFormat();
        vertexFmtBuilder.AddElements(
            (IG_VERTEX_USAGE.IG_VERTEX_USAGE_POSITION, IG_VERTEX_TYPE.IG_VERTEX_TYPE_FLOAT3),
            (IG_VERTEX_USAGE.IG_VERTEX_USAGE_NORMAL, IG_VERTEX_TYPE.IG_VERTEX_TYPE_DEC3N),
            (IG_VERTEX_USAGE.IG_VERTEX_USAGE_TEXCOORD, IG_VERTEX_TYPE.IG_VERTEX_TYPE_HALF2)
        );

        foreach (var meshVertex in mesh.vertices) {
            meshVertex.pos.X *= scale;
            meshVertex.pos.Y *= scale;
            meshVertex.pos.Z *= scale;
        }

        var defaultPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Default")!;
        var vertexPool = igSingleton<igMemoryContext>.Singleton.GetMemoryPoolByName("Vertex")!;

        using var newIndexStream = new MemoryStream();
        using (var writer = new StreamHelper(newIndexStream)) {
            writer._endianness = StreamHelper.Endianness.Big;
            foreach (var idx in mesh.indices) writer.WriteUInt16((ushort)idx);
        }

        newIndexStream.Flush();
        var newIndexBytes = Utils.PadToMultipleOf16(newIndexStream.ToArray());
        var igIndexData = new igMemory<byte>(vertexPool, (uint)newIndexBytes.Length);
        igIndexData.Alloc(newIndexBytes.Length);
        for (var i = 0; i < newIndexBytes.Length; i++) igIndexData[i] = newIndexBytes[i];

        var vertexFormat = vertexFmtBuilder.BuildAlchemyObject();

        var idxFormat = igIndexFormat.GetFormatName(IG_INDEX_TYPE.IG_INDEX_TYPE_INT16, IG_GFX_PLATFORM.IG_GFX_PLATFORM_CAFE, false);

        return new igModelDrawCallData {
            internalMemoryPool = defaultPool,
            _min = new igVec4f(-1, -1, -1, 0),
            _max = new igVec4f(1, 1, 1, 1),
            _materialHandle = defaultMaterial,
            _graphicsVertexBuffer = new igGraphicsVertexBuffer {
                internalMemoryPool = defaultPool,
                _usage = igResourceUsage.kUsageStatic,
                _vertexBuffer = new igVertexBuffer {
                    internalMemoryPool = defaultPool,
                    _vertexCount = (uint)mesh.vertices.Count,
                    _vertexCountArray = SingleValueIgMemory((uint)mesh.vertices.Count),
                    _format = vertexFormat,
                    _primitiveType = primitive,
                    _packData = new igMemory<byte>(),
                    _data = vertexFmtBuilder.BuildVertexBuffer(mesh)
                }
            },
            _graphicsIndexBuffer = new igGraphicsIndexBuffer {
                internalMemoryPool = defaultPool,
                _usage = igResourceUsage.kUsageStatic,
                _indexBuffer = new igIndexBuffer {
                    internalMemoryPool = defaultPool,
                    _indexCount = (uint)mesh.indices.Count,
                    _indexCountArray = SingleValueIgMemory((uint)mesh.indices.Count),
                    _vertexFormat = vertexFormat,
                    _primitiveType = primitive,
                    _format = new igHandle(new igHandleName {
                        _ns = new igName("indexformats"),
                        _name = new igName(idxFormat)
                    }).GetObjectAlias<igIndexFormat>() ?? throw new MissingFieldException("Cannot find " + idxFormat),
                    _data = igIndexData
                }
            },
            _propertiesBitField = 0b100000001011100,
            _bakedBufferOffset = -1,
            _indexBufferType = IG_INDEX_TYPE.IG_INDEX_TYPE_INT32,
            _primitiveType = primitive,
            _lod = 1,
            _enabled = true
        };
    }

    private static igMemory<T> SingleValueIgMemory<T>(T obj) {
        var igMemory = new igMemory<T>();
        igMemory.Alloc(1);
        igMemory[0] = obj;
        return igMemory;
    }

    private static void IgLibraryInit(string gameDir, string updatePakPath, IG_CORE_PLATFORM platform) {
        igAlchemyCore.InitializeSystems();
        igSingleton<igFileContext>.Singleton.Initialize(gameDir);
        igSingleton<igFileContext>.Singleton.InitializeUpdate(updatePakPath);
        igRegistry.GetRegistry()._platform = platform;
        igRegistry.GetRegistry()._gfxPlatform = igGfx.GetGfxPlatformFromCore(platform);
        igArkCore.ReadFromFile(igArkCore.EGame.EV_SkylandersSuperchargers);
        var platform2 = igRegistry.GetRegistry()._platform;

        igSingleton<igFileContext>.Singleton.LoadArchive("app:/archives/loosefiles.pak");
        CPrecacheManager._Instance.PrecachePackage("generated/shaders/shaders_" + igAlchemyCore.GetPlatformString(platform2), EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/permanent_" + igAlchemyCore.GetPlatformString(platform2), EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/essentialui", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/UI/legal", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/gamestartup", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/permanentdeveloper", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/SoundBankData", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/permanent", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/maps/zoneinfos", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/packageXmls/permanent_2015", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/UI/Domains/JuiceDomain_Mobile", EMemoryPoolID.MP_DEFAULT);
        CPrecacheManager._Instance.PrecachePackage("generated/UI/Domains/JuiceDomain_FrontEnd", EMemoryPoolID.MP_DEFAULT);
    }

    private static void SaveToFile(igObjectDirectory directory, string name) {
        var memoryStream = new MemoryStream();
        directory.WriteFile(memoryStream, igRegistry.GetRegistry()._platform);
        memoryStream.Seek(0L, SeekOrigin.Begin);

        var fs = File.Create(name);
        memoryStream.CopyTo(fs);
        fs.Close();
        memoryStream.Seek(0, SeekOrigin.Begin);
    }

    private static void SaveUpdatePak(igObjectDirectory currentDir) {
        var memoryStream = new MemoryStream();
        currentDir.WriteFile(memoryStream, igRegistry.GetRegistry()._platform);
        memoryStream.Seek(0L, SeekOrigin.Begin);
        var igFilePath = new igFilePath();
        igFilePath.Set(currentDir._path);
        var igArchive = igSingleton<igFileContext>.Singleton._archiveManager._patchArchives._count > 0
            ? igSingleton<igFileContext>.Singleton._archiveManager._patchArchives[0]
            : (igArchive)currentDir._fd._device;
        igArchive.GetAddFile(igFilePath._path);
        igArchive.Compress(igFilePath._path, memoryStream);
        memoryStream.Close();
        if (igArchive._path[1] == ':')
            igArchive.Save(igArchive._path);
        else
            igArchive.Save(igSingleton<igFileContext>.Singleton._root + "/archives/" + Path.GetFileName(igArchive._path));
    }
}