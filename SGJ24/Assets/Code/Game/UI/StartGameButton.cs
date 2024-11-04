using Game.Battles;
using Game.Cards;
using Game.Infrastructure.Core;
using Game.Infrastructure.Data;
using Game.Shop;
using Utils.UI;
using Zenject;

namespace Game.UI
{
  public class StartGameButton : ButtonHandler
  {
    private IGameStateMachine _stateMachine;
    private IGameData _data;

    [Inject]
    private void Construct(IGameStateMachine stateMachine, IGameData data)
    {
      _stateMachine = stateMachine;
      _data = data;
    }

    protected override void OnClick()
    {
      _data.Get<ArenaData>().ResetQueue();
      _data.Get<ShopData>().ResetQueue();
      _data.Get<InventoryData>().Clear();
      _data.Get<ProgressData>().Chest = CombatantsList.Chest;

      if (_data.Get<ProgressData>().Win)
      {
        _data.Get<ArenaData>().Combatants[CombatantType.Hero].Stats.Hp = 0;
        _data.Get<ProgressData>().Win = false;
        _stateMachine.Enter<LoadShopState>();
      }
      else
      {
        _stateMachine.Enter<LoadArenaState>();
      }
    }
  }
}