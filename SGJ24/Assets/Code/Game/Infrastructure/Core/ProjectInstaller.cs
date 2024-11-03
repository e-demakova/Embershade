using Game.Audio;
using Game.Battles;
using Game.Infrastructure.AssetsManagement;
using Game.Infrastructure.Data;
using Game.Infrastructure.Scenes;
using Utils.Extensions;
using Zenject;

namespace Game.Infrastructure.Core
{
  public class ProjectInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      BindGameStateMachine();

      Container.BindService<GameApplication>();
      Container.BindService<GameData>();
      Container.BindService<SceneLoader>();
      Container.BindService<PlayerInput.Input>();
      Container.BindService<BuildersFactory>();
      Container.BindService<AssetProvider>();
      Container.BindService<AudioPlayer>();
      Container.BindService<Cheats>();

      Container.BindService<Arena>();
      Container.BindService<ArenaFactory>();
      Container.BindService<ReactionsInvoker>();
      Container.BindService<SpellApplier>();
    }

    private void BindGameStateMachine()
    {
      Container.BindService<GameStateMachine>();

      Container.FullBind<BootstrapState>();
      Container.FullBind<GameLoopState>();
      Container.FullBind<LoadSceneState>();
      Container.FullBind<LoadArenaState>();
      Container.FullBind<LoadShopState>();
    }
  }
}