using Utils.SmartDebug;
using Utils.StateMachine;
using Utils.StateMachine.States;

namespace Game.Infrastructure.Core
{
  public interface IGameStateMachine : IStateMachine<IGameState>, IPayloadStateMachine<IGameState> { }

  public class GameStateMachine : SimpleStateMachine<IGameState>, IGameStateMachine
  {
    protected override StateMachineLogger Logger { get; } = new(DSenders.GameStateMachine);
  }
}