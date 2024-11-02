using System.Collections.Generic;
using UnityEngine;

namespace Game.Battles
{
  public static class Combatants
  {
    public static readonly Vector3 HeroPosition = new(-2.5f, -2.5f, 8f);
    public static readonly Vector3 EnemyPosition = new(2.5f, -2.5f, 8f);

    public static CombatantData FirstHero => new()
    {
      Stats = new CombatantStats { Attack = 0, Hp = 1 },
      Reactions = new List<IReaction> { new SummonOnDeathReaction() }
    };
  }
}