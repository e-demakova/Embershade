using System.Collections.Generic;
using Game.Infrastructure.Data;
using Utils.Observing.SubjectProperties;

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
      { CombatantType.Hero, Battles.Combatants.FirstHero },
      { CombatantType.Enemy, Battles.Combatants.DefaultEnemy },
    };

    public bool SupportArrived { get; set; }
  }
}