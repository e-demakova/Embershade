using Game.Battles;
using Game.Infrastructure.Scenes;
using Utils.PostponedTasks;
using Utils.StateMachine.States;

namespace Game.Infrastructure.Core
{
  public class LoadArenaState : IGameState, IEnterState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _loader;
    private readonly IArenaFactory _arenaFactory;

    public LoadArenaState(IGameStateMachine stateMachine, ISceneLoader loader, IArenaFactory arenaFactory)
    {
      _stateMachine = stateMachine;
      _loader = loader;
      _arenaFactory = arenaFactory;
    }

    public void Enter() =>
      Postponer.Wait(_loader.LoadingScreen.Appear)
               .Wait(() => _loader.Load(ScenesList.Main))
               .Do(_arenaFactory.CreateCombatants)
               .Wait(_loader.LoadingScreen.Fade)
               .Do(_stateMachine.Enter<GameLoopState>);
  }
}