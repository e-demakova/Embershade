using System.Linq;
using Cysharp.Threading.Tasks;
using Game.Battles.Triggers;
using Game.Infrastructure.Data;
using Zenject;

namespace Game.Battles.Reactions
{
  public class RecoverHealthOnBattleEnded : IReaction
  {
    private int _availableExecutions;
    private IGameData _data;

    public RecoverHealthOnBattleEnded(int availableExecutions) =>
      _availableExecutions = availableExecutions;

    [Inject]
    private void Construct(IGameData data) =>
      _data = data;

    public bool CanReact(ITrigger trigger, CombatantData owner) =>
      _availableExecutions > 0 && trigger is BattleEndTrigger;

    public async UniTask React(ITrigger trigger, CombatantData owner)
    {
      _availableExecutions--;
      foreach (CombatantData combatant in _data.Get<ArenaData>().Combatants.Values.Where(x => x.Is<MainHeroTag>(out _)))
        combatant.Stats.Hp = 1;
    }
  }
}