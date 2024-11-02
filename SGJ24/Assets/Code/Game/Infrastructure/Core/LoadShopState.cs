using Game.Infrastructure.Scenes;
using Utils.PostponedTasks;
using Utils.StateMachine.States;

namespace Game.Infrastructure.Core
{
  public class LoadShopState : IGameState, IEnterState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _loader;
    
    public LoadShopState(IGameStateMachine stateMachine, ISceneLoader loader)
    {
      _stateMachine = stateMachine;
      _loader = loader;
    }

    public void Enter() =>
      Postponer.Wait(_loader.LoadingScreen.Appear)
               .Wait(() => _loader.Load(ScenesList.Shop))
               .Wait(_loader.LoadingScreen.Fade)
               .Do(_stateMachine.Enter<GameLoopState>);
  }
}