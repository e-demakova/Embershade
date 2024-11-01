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
    private BattleUI BattleUI => _data.Get<SceneData>().Get<BattleUI>();
    private MainCamera MainCamera => _data.Get<SceneData>().Get<MainCamera>();

    public Arena(IGameData data)
    {
      _data = data;
    }

    public void RunTurn()
    {
      PostponedSequence sequence = Postponer.Sequence();

      sequence.Do(BattleUI.Hide)
              .Wait(() => MainCamera.Zoom(-6, 0.4f));

      foreach (Combatant combatant in Combatants)
      foreach (Combatant target in Combatants.Where(x => combatant.TargetMatch(x)))
        sequence.Wait(() => combatant.MoveToTarget(target))
                .Wait(combatant.MoveToHome);

      sequence.Wait(() => MainCamera.Zoom(-10, 0.2f))
              .Do(BattleUI.Show);
    }
  }
}