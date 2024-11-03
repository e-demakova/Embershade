using System;
using System.Collections.Generic;
using Game.Battles.Reactions;
using Game.Dialogues;
using Game.Infrastructure.AssetsManagement;

namespace Game.Battles
{
  public static class CombatantsList
  {
    public static CombatantData FirstHero => new()
    {
      Stats = new CombatantStats { Atk = 1, Hp = 1 },
      Reactions = new List<IReaction>
      {
        new SummonOnDeath(),
        new RecoverHealthOnBattleEnded(1),
        new DialogueOnTurnStarted(DialoguesList.First)
      },
      Tags = new Dictionary<Type, ICombatantTag> { { typeof(MainHeroTag), new MainHeroTag() } },
      SpritePath = Assets.HeroDefault,
      Souls = 4
    };

    public static CombatantData CatHero => new()
    {
      Stats = new CombatantStats { Atk = 1, Hp = 2 },
      Reactions = new List<IReaction>
      {
        new DialogueOnTurnStarted(DialoguesList.First)
      },
      Tags = new Dictionary<Type, ICombatantTag> { { typeof(MainHeroTag), new MainHeroTag() } },
      SpritePath = Assets.HeroCat,
      Souls = 4
    };

    public static CombatantData ElfHero => new()
    {
      Stats = new CombatantStats { Atk = 1, Hp = 2 },
      Reactions = new List<IReaction>
      {
        new DialogueOnTurnStarted(DialoguesList.First)
      },
      Tags = new Dictionary<Type, ICombatantTag> { { typeof(MainHeroTag), new MainHeroTag() } },
      SpritePath = Assets.HeroElf,
      Souls = 4
    };

    public static CombatantData KnightHero => new()
    {
      Stats = new CombatantStats { Atk = 1, Hp = 2 },
      Reactions = new List<IReaction>
      {
        new DialogueOnTurnStarted(DialoguesList.First)
      },
      Tags = new Dictionary<Type, ICombatantTag> { { typeof(MainHeroTag), new MainHeroTag() } },
      SpritePath = Assets.HeroKnight,
      Souls = 4
    };

    public static CombatantData DefaultEnemy => new()
    {
      Stats = new CombatantStats { Atk = 1, Hp = 5 },
      Reactions = new List<IReaction> { new DropSoulsOnDeath() },
      Tags = new Dictionary<Type, ICombatantTag> { },
      SpritePath = Assets.Enemy,
      Souls = 2
    };

    public static CombatantData EnemyOne => new()
    {
      Stats = new CombatantStats { Atk = 2, Hp = 7 },
      Reactions = new List<IReaction> { new DropSoulsOnDeath() },
      Tags = new Dictionary<Type, ICombatantTag> { },
      SpritePath = Assets.EnemyOne,
      Souls = 2
    };

    public static CombatantData EnemyTwo => new()
    {
      Stats = new CombatantStats { Atk = 4, Hp = 25 },
      Reactions = new List<IReaction> { new DropSoulsOnDeath() },
      Tags = new Dictionary<Type, ICombatantTag> { },
      SpritePath = Assets.EnemyTwo,
      Souls = 2
    };
  }
}