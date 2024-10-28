using Game.Infrastructure.AssetsManagement;
using UnityEngine.SceneManagement;
using Utils.PostponedTasks;

namespace Game.Infrastructure.Scenes
{
  public interface ISceneLoader
  {
    PostponedSequence Load(string scene);
  }

  public class SceneLoader : ISceneLoader
  {
    private readonly IBuildersFactory _factory;

    private LoadingScreen _loadingScreen;
    public LoadingScreen LoadingScreen => _loadingScreen ??= _factory.FromResources(Assets.LoadingScreen).Instantiate<LoadingScreen>();

    public SceneLoader(IBuildersFactory factory) =>
      _factory = factory;

    public PostponedSequence Load(string scene) =>
      Postponer.Wait(LoadingScreen.Appear)
               .Do(() => SceneManager.LoadScene(scene))
               .Wait(LoadingScreen.Fade);
  }
}