namespace igLibrary.Gen.MetaEnum;

public enum EAcquireTargetType
{
	eATT_None = 0,
	eATT_All = 1,
	eATT_EnemyActors = 2,
	eATT_DynamicRigidBodies = 4,
	eATT_HeroActors = 8,
	eATT_Self = 0x20,
	eATT_CurrentCombatTargets = 0x40,
	eATT_CurrentVictim = 0x400,
	eATT_PlayableHero = 0x800
}
