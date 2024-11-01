using System.Collections.Generic;
using Game.Infrastructure.Data;

namespace Game.Battles
{
  public class ArenaData : IData
  {
    public List<Combatant> Combatants = new();
  }
}