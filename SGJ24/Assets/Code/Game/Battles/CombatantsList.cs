using System;
using System.Collections.Generic;
using Game.Battles.Reactions;
using Game.Dialogues;
using Utils.Observing.SubjectProperties;

namespace Game.Battles
{
  public static class CombatantsList
  {
    public static CombatantData FirstHero => new()
    {
      Stats = new CombatantStats { Attack = 1, Hp = new SubjectInt(2, min: 0, max: 3) },
      Reactions = new List<IReaction>
      {
        new SummonOnDeath(),
        new RecoverHealthOnBattleEnded(1),
        new DialogueOnTurnStarted(DialoguesList.First)
      },
      Tags = new Dictionary<Type, ICombatantTag> { { typeof(MainHeroTag), new MainHeroTag() } }
    };

    public static CombatantData DefaultEnemy => new()
    {
      Stats = new CombatantStats { Attack = 1, Hp = new SubjectInt(5, 0, 5) },
      Reactions = new List<IReaction>(),
      Tags = new Dictionary<Type, ICombatantTag> { }
    };
  }
}