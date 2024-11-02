using System.Collections.Generic;
using Game.Infrastructure.Data;

namespace Game.Battles
{
  public enum CombatantType
  {
    Hero = 0,
    Enemy = 1
  }

  public class CombatantData : IData
  {
    public Combatant Instance;
    public CombatantStats Stats;

    public bool IsDead => Stats.Hp <= 0;

    public bool TargetMatch(CombatantData target) =>
      target != this;
  }

  public class ArenaData : IData
  {
    public Dictionary<CombatantType, CombatantData> Combatants = new()
    {
      { CombatantType.Hero, new CombatantData { Stats = new CombatantStats { Attack = 0, Hp = 3 } } },
      { CombatantType.Enemy, new CombatantData { Stats = new CombatantStats { Attack = 1, Hp = 1 } } },
    };
  }
}