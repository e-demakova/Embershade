using Cysharp.Threading.Tasks;
using Game.Battles.Triggers;
using Game.Infrastructure.AssetsManagement;
using Game.Infrastructure.Data;
using Game.Shop;
using Zenject;

namespace Game.Battles.Reactions
{
  public class SummonOnDeath : IReaction
  {
    private int _availableExecutions = 1;

    private IGameData _data;
    private IBuildersFactory _builders;
    private ArenaData ArenaData => _data.Get<ArenaData>();

    [Inject]
    private void Construct(IGameData data, IBuildersFactory builders)
    {
      _data = data;
      _builders = builders;
    }

    public bool CanReact(ITrigger trigger, CombatantData owner) =>
      _availableExecutions > 0 && trigger is DeathTrigger death && death.Corpse == owner;

    public async UniTask React(ITrigger trigger, CombatantData owner)
    {
      _availableExecutions--;

      _data.Get<SoulsData>().InWallet = owner.Souls;
      ArenaData.SupportArrived = true;
      ArenaData.ResetQueue();
    }
  }
}