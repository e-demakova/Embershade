using Game.PlayerInput;
using Utils.StateMachine.States;

namespace Game.Infrastructure.Core
{
  public class GameLoopState : IGameState, IEnterState, IExitState
  {
    private readonly IInput _input;

    public GameLoopState(IInput input) =>
      _input = input;

    public void Enter() =>
      _input.Enabled = true;

    public void Exit() =>
      _input.Enabled = false;
  }
}