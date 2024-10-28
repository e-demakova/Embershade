using UnityEngine;
using Zenject;

namespace Game.Infrastructure.AssetsManagement
{
  public class GameObjectBuilder
  {
    private readonly GameObject _source;
    private readonly DiContainer _container;

    private Vector3 _position = Vector3.zero;
    private Quaternion _rotation = Quaternion.identity;
    private Transform _parent;

    public GameObjectBuilder(GameObject source, DiContainer container)
    {
      _source = source;
      _container = container;
    }

    public GameObjectBuilder At(Vector3 position)
    {
      _position = position;
      return this;
    }

    public GameObjectBuilder With(Quaternion rotation)
    {
      _rotation = rotation;
      return this;
    }

    public GameObjectBuilder With(Transform parent)
    {
      _parent = parent;
      return this;
    }
    
    public T Instantiate<T>() =>
      Instantiate().GetComponent<T>();

    public GameObject Instantiate()
    {
      GameObject gameObject = Object.Instantiate(_source, _position, _rotation, _parent);

      _container.InjectGameObject(gameObject);
      return gameObject;
    }
  }
}