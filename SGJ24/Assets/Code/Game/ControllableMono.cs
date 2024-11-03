using Game.Infrastructure.Data;
using UnityEngine;
using Zenject;

namespace Game
{
  public class ControllableMono<T> : MonoBehaviour where T : ControllableMono<T>
  {
    private IGameData _gameData;
    private SceneData SceneData => _gameData.Get<SceneData>();

    [Inject]
    private void Construct(IGameData gameData) =>
      _gameData = gameData;

    protected virtual void Start() =>
      SceneData.Register(this);

    private void OnDestroy() =>
      SceneData.Unregister<T>();
  }
}