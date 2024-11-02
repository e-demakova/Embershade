using System.Collections.Generic;
using UnityEngine;
using Utils.Observing.SubjectProperties;

namespace Game.Battles
{
  public static class Combatants
  {
    public static readonly Vector3 HeroPosition = new(-2.5f, -2.5f, 8f);
    public static readonly Vector3 EnemyPosition = new(2.5f, -2.5f, 8f);

    public static CombatantData FirstHero => new()
    {
      Stats = new CombatantStats { Attack = 1, Hp = new SubjectInt(3, min: 0, max: 3) },
      Reactions = new List<IReaction> { new SummonOnDeathReaction() }
    };

    public static CombatantData DefaultEnemy => new() 
      { Stats = new CombatantStats { Attack = 2, Hp = new SubjectInt(5, 0, 5) }, Reactions = new List<IReaction>() };
  }
}