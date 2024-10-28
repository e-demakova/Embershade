using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Infrastructure.AssetsManagement
{
  public class EmptyGameObjectBuilder
  {
    private readonly List<Type> _components = new();
    private readonly DiContainer _container;
    private readonly string _name;

    private bool _dontDestroy;

    public EmptyGameObjectBuilder(string name, DiContainer container)
    {
      _name = name;
      _container = container;
    }

    public EmptyGameObjectBuilder DontDestroy()
    {
      _dontDestroy = true;
      return this;
    }

    public EmptyGameObjectBuilder With<T>()
    {
      _components.Add(typeof(T));
      return this;
    }

    public T Instantiate<T>() =>
      Instantiate().GetComponent<T>();

    public GameObject Instantiate()
    {
      GameObject gameObject = new(_name, _components.ToArray());
      _container.InjectGameObject(gameObject);

      if(_dontDestroy)
        Object.DontDestroyOnLoad(gameObject);
      
      return gameObject;
    }
  }
}