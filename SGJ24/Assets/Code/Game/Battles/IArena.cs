using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Game.Battles.Reactions;
using Game.Battles.Triggers;
using Game.Cards;
using Game.Infrastructure.Core;
using Game.Infrastructure.Data;
using Game.Shop;
using Utils.PostponedTasks;

namespace Game.Battles
{
  public interface IArena
  {
    void Run();
    void RunTurn();
  }

  public class Arena : IArena
  {
    private readonly IGameData _data;
    private readonly IGameStateMachine _stateMachine;
    private readonly IReactionsInvoker _invoker;
    private readonly ISpellApplier _spellApplier;

    private List<CombatantData> Combatants => _data.Get<ArenaData>().Combatants.Values.ToList();
    private BattleUI BattleUI => _data.Get<SceneData>().Get<BattleUI>();
    private MainCamera MainCamera => _data.Get<SceneData>().Get<MainCamera>();

    public Arena(IGameData data, IGameStateMachine stateMachine, IReactionsInvoker invoker, ISpellApplier spellApplier)
    {
      _data = data;
      _stateMachine = stateMachine;
      _invoker = invoker;
      _spellApplier = spellApplier;
    }

    public void Run() =>
      Postponer.Do(BattleUI.Hide)
               .Wait(() => React(new BattleStartedTrigger()))
               .Wait(ApplyCards)
               .Do(BattleUI.Show);

    public void RunTurn()
    {
      PostponedSequence sequence = Postponer.Sequence();

      sequence.Do(BattleUI.Hide)
              .Wait(MainCamera.ZoomIn)
              .Wait(() => React(new TurnStartedTrigger()));

      foreach (CombatantData actor in Combatants)
      foreach (CombatantData target in Combatants.Where(x => actor.TargetMatch(x)))
        sequence.Wait(() => Attack(actor, target));

      sequence.Wait(EndTurn);
    }

    private async UniTask Attack(CombatantData actor, CombatantData target)
    {
      if (actor.IsDead)
        return;

      await actor.Instance.MoveToTarget(target.Instance);

      MainCamera.Shake().Forget();
      target.Stats.Hp -= actor.Stats.Atk;
      await target.Instance.GetHit();

      if (target.IsDead)
      {
        await target.Instance.Dead();
        await React(new DeathTrigger { Corpse = target, Killer = actor });
      }
      else
      {
        await actor.Instance.MoveToHome();
      }
    }

    private async UniTask React(ITrigger trigger)
    {
      foreach (CombatantData owner in Combatants)
      foreach (IReaction reaction in owner.Reactions)
        await _invoker.React(reaction, trigger, owner);
    }

    private async UniTask EndTurn()
    {
      if (Combatants.Any(x => x.IsDead))
      {
        _stateMachine.Enter<LoadShopState>();
        await React(new BattleEndTrigger());
        RevertCards();
      }
      else
      {
        await MainCamera.ZoomOut();
        BattleUI.Show();
      }
    }

    private async UniTask ApplyCards()
    {
      foreach (CardData card in _data.Get<InventoryData>().Cards)
      foreach (ICardSpell spell in card.Spells)
        await _spellApplier.ApplySpell(spell);
    }

    private void RevertCards()
    {
      foreach (CardData card in _data.Get<InventoryData>().Cards)
      foreach (ICardSpell spell in card.Spells)
        _spellApplier.RevertSpell(spell);
    }
  }
}