using Cysharp.Threading.Tasks;
using Game.Battles.Triggers;
using Game.Infrastructure.Data;
using Game.Shop;
using Zenject;

namespace Game.Battles.Reactions
{
  public class DropSoulsOnDeath : IReaction
  {
    private IGameData _data;

    [Inject]
    private void Construct(IGameData data)
    {
      _data = data;
    }

    public bool CanReact(ITrigger trigger, CombatantData owner) =>
      trigger is DeathTrigger death && death.Corpse == owner;

    public async UniTask React(ITrigger trigger, CombatantData owner)
    {
      _data.Get<SoulsData>().InWallet += owner.Souls;
      await owner.Instance.DropSouls();
    }
  }
}