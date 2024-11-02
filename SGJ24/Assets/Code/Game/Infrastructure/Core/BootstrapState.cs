using Cysharp.Threading.Tasks;
using Game.Infrastructure.Scenes;
using Utils.PostponedTasks;
using Utils.StateMachine.States;

namespace Game.Infrastructure.Core
{
  public class BootstrapState : IGameState, IEnterState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _loader;

    public BootstrapState(IGameStateMachine stateMachine, ISceneLoader loader)
    {
      _stateMachine = stateMachine;
      _loader = loader;
    }

    public void Enter()
    {
      if (GameSettings.ShowLogo)
        Postponer.Wait(() => _loader.Load(ScenesList.Logo))
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