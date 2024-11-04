using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Game.Battles.Reactions;
using Game.Battles.Triggers;
using Game.Cards;
using Game.Infrastructure.Core;
using Game.Infrastructure.Data;
using Game.Infrastructure.Scenes;
using Game.Shop;
using UnityEngine;
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

    private SceneData SceneData => _data.Get<SceneData>();
    private List<CombatantData> Combatants => _data.Get<ArenaData>().Combatants.Values.ToList();
    private BattleUI BattleUI => _data.Get<SceneData>().Get<BattleUI>();
    private InventoryUI InventoryUI => _data.Get<SceneData>().Get<InventoryUI>();
    private MainCamera MainCamera => _data.Get<SceneData>().Get<MainCamera>();

    public Arena(IGameData data, IGameStateMachine stateMachine, IReactionsInvoker invoker, ISpellApplier spellApplier)
    {
      _data = data;
      _stateMachine = stateMachine;
      _invoker = invoker;
      _spellApplier = spellApplier;
    }

    public void Run()
    {
      _data.Get<ProgressData>().Level++;

      Postponer.Do(BattleUI.Hide)
               .Do(InventoryUI.Hide)
               .Wait(() => React(new BattleStartedTrigger()))
               .Do(InventoryUI.Show)
               .Wait(ApplyCards)
               .Do(BattleUI.Show);
    }

    public void RunTurn()
    {
      PostponedSequence sequence = Postponer.Sequence();

      sequence.Do(BattleUI.Hide)
              .Do(InventoryUI.Hide)
              .Wait(MainCamera.ZoomIn)
              .Wait(() => React(new TurnStartedTrigger()));

      foreach (CombatantData actor in Combatants)
      foreach (CombatantData target in Combatants.Where(x => actor.TargetMatch(x)))
        sequence.Wait(() => Attack(actor, target));

      sequence.Wait(EndTurn);
    }

    private async UniTask Attack(CombatantData actor, CombatantData target)
    {
      if (actor.IsDead || actor.Stats.Atk == 0)
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
        await React(new BattleEndTrigger());
        RevertCards();

        if (_data.Get<ProgressData>().Win)
          _stateMachine.Enter<LoadSceneState, string>(ScenesList.End);
        else
          _stateMachine.Enter<LoadShopState>();
      }
      else if (GameSettings.AutoBattle)
      {
        RunTurn();
      }
      else
      {
        await MainCamera.ZoomOut();
        BattleUI.Show();
        InventoryUI.Show();
      }
    }

    private async UniTask ApplyCards()
    {
      List<CardData> list = _data.Get<InventoryData>().Cards;
      List<InventorySlotUI> slots = SceneData.Get<InventoryUI>().Slots;
      InventoryTooltip tooltip = SceneData.Get<InventoryTooltip>();

      for (int i = 0; i < list.Count; i++)
      {
        InventorySlotUI slot = slots[i];
        tooltip.Show((RectTransform) slot.transform, slot.Card);

        await UniTask.WaitForSeconds(list.Count > 2 ? 0.1f : 0.3f);
        await _spellApplier.ApplySpell(list[i].Spell);
        await UniTask.WaitForSeconds(0.1f);
      }

      tooltip.Hide();
    }

    private void RevertCards()
    {
      foreach (CardData card in _data.Get<InventoryData>().Cards)
        _spellApplier.RevertSpell(card.Spell);
    }
  }
}