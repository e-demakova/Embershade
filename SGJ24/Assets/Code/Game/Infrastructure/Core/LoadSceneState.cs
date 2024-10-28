using Game.Infrastructure.Scenes;
using Utils.StateMachine.States;

namespace Game.Infrastructure.Core
{
  public class LoadSceneState : IGameState, IPayloadState<string>
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _scenes;

    public LoadSceneState(IGameStateMachine stateMachine, ISceneLoader scenes)
    {
      _stateMachine = stateMachine;
      _scenes = scenes;
    }

    public void Enter(string payload) =>
      _scenes.Load(payload)
             .Do(_stateMachine.Enter<GameLoopState>);
  }
}