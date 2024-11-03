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
      SpritePath = Assets.HeroDefault
    };

    public static CombatantData CatHero => new()
    {
      Stats = new CombatantStats { Atk = 1, Hp = 2 },
      Reactions = new List<IReaction>
      {
        new DialogueOnTurnStarted(DialoguesList.First)
      },
      Tags = new Dictionary<Type, ICombatantTag> { { typeof(MainHeroTag), new MainHeroTag() } },
      SpritePath = Assets.HeroCat
    };

    public static CombatantData ElfHero => new()
    {
      Stats = new CombatantStats { Atk = 1, Hp = 2 },
      Reactions = new List<IReaction>
      {
        new DialogueOnTurnStarted(DialoguesList.First)
      },
      Tags = new Dictionary<Type, ICombatantTag> { { typeof(MainHeroTag), new MainHeroTag() } },
      SpritePath = Assets.HeroElf
    };

    public static CombatantData KnightHero => new()
    {
      Stats = new CombatantStats { Atk = 1, Hp = 2 },
      Reactions = new List<IReaction>
      {
        new DialogueOnTurnStarted(DialoguesList.First)
      },
      Tags = new Dictionary<Type, ICombatantTag> { { typeof(MainHeroTag), new MainHeroTag() } },
      SpritePath = Assets.HeroKnight
    };

    public static CombatantData DefaultEnemy => new()
    {
      Stats = new CombatantStats { Atk = 1, Hp = 5 },
      Reactions = new List<IReaction>(),
      Tags = new Dictionary<Type, ICombatantTag> { }
    };
  }
}