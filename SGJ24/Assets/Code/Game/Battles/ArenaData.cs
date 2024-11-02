using System.Collections.Generic;
using Game.Infrastructure.Data;

namespace Game.Battles
{
  public enum CombatantType
  {
    Hero = 0,
    Enemy = 1
  }

  public class ArenaData : IData
  {
    public readonly Dictionary<CombatantType, CombatantData> Combatants = new()
    {
      { CombatantType.Hero, Battles.CombatantsList.FirstHero },
      { CombatantType.Enemy, Battles.CombatantsList.DefaultEnemy },
    };

    public bool SupportArrived { get; set; }
  }
}