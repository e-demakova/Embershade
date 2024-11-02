using Game.Infrastructure.Core;
using Utils.UI;
using Zenject;

namespace Game.UI
{
  public class ExitShopButton : ButtonHandler
  {
    private IGameStateMachine _stateMachine;

    [Inject]
    private void Construct(IGameStateMachine stateMachine) =>
      _stateMachine = stateMachine;

    protected override void OnClick() =>
      _stateMachine.Enter<LoadArenaState>();
  }
}