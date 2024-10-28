using Cysharp.Threading.Tasks;
using Game.Infrastructure.Scenes;
using Utils.StateMachine.States;

namespace Game.Infrastructure.Core
{
  public class BootstrapState : IGameState, IEnterState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public BootstrapState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
      if (GameSettings.ShowLogo)
        _sceneLoader.Load(ScenesList.Logo)
                    .Wait(ShowLogo)
                    .Do(LoadMenu);
      else
        LoadMenu();
    }

    private static async UniTask ShowLogo() =>
      await UniTask.WaitForSeconds(Durations.Logo);

    private void LoadMenu() =>
      _stateMachine.Enter<LoadSceneState, string>(ScenesList.Menu);
  }
}