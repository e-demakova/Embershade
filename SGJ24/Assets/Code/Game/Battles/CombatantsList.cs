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

    public static CombatantData Witch => new()
    {
      Stats = new CombatantStats { Atk = 1, Hp = 3 },
      Reactions = new List<IReaction> { new DropSoulsOnDeath() },
      Tags = new Dictionary<Type, ICombatantTag> { },
      SpritePath = Assets.Witch,
      Souls = 2
    };

    public static CombatantData CatEnemy => new()
    {
      Stats = new CombatantStats { Atk = 2, Hp = 5 },
      Reactions = new List<IReaction> { new DropSoulsOnDeath() },
      Tags = new Dictionary<Type, ICombatantTag> { },
      SpritePath = Assets.CatEnemy,
      Souls = 2
    };

    public static CombatantData Goat => new()
    {
      Stats = new CombatantStats { Atk = 4, Hp = 5 },
      Reactions = new List<IReaction> { new DropSoulsOnDeath() },
      Tags = new Dictionary<Type, ICombatantTag> { },
      SpritePath = Assets.Goat,
      Souls = 2
    }; 
    
    public static CombatantData Heads => new()
    {
      Stats = new CombatantStats { Atk = 4, Hp = 5 },
      Reactions = new List<IReaction> { new DropSoulsOnDeath() },
      Tags = new Dictionary<Type, ICombatantTag> { },
      SpritePath = Assets.Heads,
      Souls = 2
    };
    
    public static CombatantData Scarecrow => new()
    {
      Stats = new CombatantStats { Atk = 4, Hp = 5 },
      Reactions = new List<IReaction> { new DropSoulsOnDeath() },
      Tags = new Dictionary<Type, ICombatantTag> { },
      SpritePath = Assets.Scarecrow,
      Souls = 2
    };
  }
}