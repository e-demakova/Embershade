using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace Game.Infrastructure.AssetsManagement
{
  public interface IPoolableItem<T> where T : Component
  {
    void OnDequeue(Pool<T> pool);
    void OnEnqueue();
  }

  public interface IPool<T> where T : Component
  {
    bool IsEmpty { get; }
    T Get();
    void Return(T item);
  }

  public class Pool<T> : IPool<T> where T : Component
  {
    private readonly List<T> _created = new();
    private readonly Queue<T> _queue = new();
    private readonly GameObjectBuilder _builder;

    public bool IsEmpty => _queue.IsEmpty();

    public Pool(GameObjectBuilder builder) =>
      _builder = builder;

    public T Get()
    {
      T item = IsEmpty ? _builder.Instantiate<T>() : _queue.Dequeue();
      _created.Add(item);

      if (item is IPoolableItem<T> poolable)
        poolable.OnDequeue(this);

      return item;
    }

    public void Return(T item)
    {
      if (item is IPoolableItem<T> poolable)
        poolable.OnEnqueue();

      _queue.Enqueue(item);
      _created.Remove(item);
    }

    public void ReturnAll()
    {
      for (int i = _created.Count - 1; i >= 0; i--)
      {
        T item = _created[i];
        Return(item);
      }
    }
  }
}