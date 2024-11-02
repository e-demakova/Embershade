using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Game.Infrastructure.Core;
using Game.Infrastructure.Data;
using UnityEngine;
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
    private readonly IGameStateMachine _stateMachine;
    
    private List<CombatantData> Combatants => _data.Get<ArenaData>().Combatants.Values.ToList();
    private BattleUI BattleUI => _data.Get<SceneData>().Get<BattleUI>();
    private MainCamera MainCamera => _data.Get<SceneData>().Get<MainCamera>();

    public Arena(IGameData data, IGameStateMachine stateMachine)
    {
      _data = data;
      _stateMachine = stateMachine;
    }

    public void RunTurn()
    {
      PostponedSequence sequence = Postponer.Sequence();

      sequence.Do(BattleUI.Hide)
              .Wait(() => MainCamera.Zoom(-6, 0.4f));

      foreach (CombatantData actor in Combatants)
      foreach (CombatantData target in Combatants.Where(x => actor.TargetMatch(x)))
        sequence.Wait(() => Attack(actor, target));

      sequence.Wait(EndTurn);
    }

    private async UniTask Attack(CombatantData actor, CombatantData target)
    {
      if(actor.IsDead)
        return;
      
      await actor.Instance.MoveToTarget(target.Instance);

      MainCamera.Shake().Forget();
      target.Stats.Hp -= actor.Stats.Attack;
      await target.Instance.GetHit();

      if (target.IsDead)
      {
        Vector3 position = target.Instance.transform.position;
        position.z = -5;
        position.y += 2;
        position.x *= 0.7f;
        MainCamera.Move(position, 0.1f).Forget();
        await target.Instance.Dead();
      }
      else
      {
        await actor.Instance.MoveToHome();
      }
    }

    private async UniTask EndTurn()
    {
      if (Combatants.Any(x => x.IsDead))
      {
        _stateMachine.Enter<LoadArenaState>();
      }
      else
      {
        await MainCamera.Zoom(-10, 0.2f);
        BattleUI.Show();
      }
    }
  }
}