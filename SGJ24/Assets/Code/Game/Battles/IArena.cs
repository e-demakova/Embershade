using System.Collections.Generic;
using System.Linq;
using Game.Infrastructure.Data;
using Utils.PostponedTasks;

namespace Game.Battles
{
  public interface IArena
  {
    void RunTurn();
  }

  public class Arena : IArena
  {
    private readonly IGameData _data;
    private List<Combatant> Combatants => _data.Get<ArenaData>().Combatants;

    public Arena(IGameData data)
    {
      _data = data;
    }

    public void RunTurn()
    {
      PostponedSequence sequence = Postponer.Sequence();
      
      foreach (Combatant combatant in Combatants)
      foreach (Combatant target in Combatants.Where(x => combatant.TargetMatch(x)))
        sequence.Wait(() => combatant.MoveToTarget(target))
                .Wait(combatant.MoveToHome);
    }
  }
}