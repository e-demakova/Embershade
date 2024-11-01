using Game.Battles;
using Game.Infrastructure.Scenes;
using Utils.StateMachine.States;

namespace Game.Infrastructure.Core
{
  public class LoadArenaState : IGameState, IEnterState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _scenes;
    private readonly IArenaFactory _arenaFactory;
    private readonly IArena _arena;

    public LoadArenaState(IGameStateMachine stateMachine, ISceneLoader scenes, IArenaFactory arenaFactory, IArena arena)
    {
      _stateMachine = stateMachine;
      _scenes = scenes;
      _arenaFactory = arenaFactory;
      _arena = arena;
    }

    public void Enter() =>
      _scenes.Load(ScenesList.Main)
             .Do(_arenaFactory.CreateCombatants)
             .Do(_stateMachine.Enter<GameLoopState>);
  }
}