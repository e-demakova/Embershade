using UnityEngine;
using Zenject;

namespace Game.Infrastructure.AssetsManagement
{
  public interface IBuildersFactory
  {
    GameObjectBuilder FromResources(string address);
    EmptyGameObjectBuilder New(string name);
  }

  public class BuildersFactory : IBuildersFactory
  {
    private readonly IAssetProvider _assets;
    private readonly DiContainer _container;

    public BuildersFactory(IAssetProvider assets, DiContainer container)
    {
      _assets = assets;
      _container = container;
    }

    public GameObjectBuilder FromResources(string address)
    {
      GameObject prefab = _assets.LoadAsset<GameObject>(address);
      return new GameObjectBuilder(prefab, _container);
    }

    public EmptyGameObjectBuilder New(string name) =>
      new EmptyGameObjectBuilder(name, _container);
  }
}