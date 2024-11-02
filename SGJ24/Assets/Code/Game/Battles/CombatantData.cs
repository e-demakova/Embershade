using System.Collections.Generic;
using Game.Infrastructure.Data;

namespace Game.Battles
{
  public class CombatantData : IData
  {
    public CombatantView Instance;
    public CombatantStats Stats;
    public List<IReaction> Reactions;
    
    public bool IsDead => Stats.Hp.Value <= 0;

    public bool TargetMatch(CombatantData target) =>
      target != this;
  }
}