using System;
using System.Collections.Generic;
using Utils.Observing.Subscribers;

namespace Utils.Observing.UnityEvents
{
  public abstract class UnityEventSubscriber<T> : ISubscriber<T>
  {
    protected Action<T> OnNext;
    private readonly List<Func<T, bool>> _predicates = new();
    
    public abstract void Dispose();

    public IDisposable Subscribe(Action<T> action)
    {
      OnNext = action;
      return Subscribe();
    }

    public IDisposable Subscribe(Action action)
    {
      OnNext = _ => action?.Invoke();
      return Subscribe();
    }

    public ISubscriber<T> When(Func<T, bool> predicate)
    {
      _predicates.Add(predicate);
      return this;
    }

    protected abstract IDisposable Subscribe();

    protected bool Predicate(T value)
    {
      for (var i = 0; i < _predicates.Count; i++)
      {
        if (!_predicates[i](value))
          return false;
      }

      return true;
    }
  }
}