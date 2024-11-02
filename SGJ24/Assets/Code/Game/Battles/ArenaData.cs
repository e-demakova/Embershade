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
      { CombatantType.Hero, Battles.Combatants.FirstHero },
      { CombatantType.Enemy, new CombatantData { Stats = new CombatantStats { Attack = 1, Hp = 1 }, Reactions = new List<IReaction>() } },
    };

    public bool SupportArrived { get; set; }
  }
}