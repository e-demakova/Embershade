using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils.Observing.Subscribers;

namespace Utils.Observing.Handlers
{
  public class Handler : Handler<EmptyEvent>, IHandler
  {
    public void Raise() =>
      Raise(new EmptyEvent());
  }

  public class Handler<T> : IHandler<T>
  {
    private readonly HashSet<IActivatableSubscriber<T>> _actions = new();
    private readonly HashSet<IActivatableSubscriber<T>> _forRemoving = new();
    private readonly HashSet<IActivatableSubscriber<T>> _forAdding = new();

    private bool _iterating;

    public void Dispose()
    {
      Complete();

      EndRemoving();
      _forAdding.Clear();
      _actions.Clear();
    }

    public ISubscriber<T> Subscribe(Action<T> action)
    {
      CheckSubscriberRegistration(action);
      _forRemoving.RemoveWhere(x => x.Action == action);

      Subscriber<T> subscriber = new(this, action);
      return RegisterSubscriber(subscriber);
    }

    public ISubscriber<T> Subscribe(Action action) =>
      Subscribe(_ => action.Invoke());

    public ISubscriber<T> Subscribe(IActivatableSubscriber<T> subscriber)
    {
      CheckSubscriberRegistration(subscriber.Action);
      _forRemoving.RemoveWhere(x => x.Action == subscriber.Action);

      return RegisterSubscriber(subscriber);
    }

    public void Unsubscribe(Action<T> action)
    {
      _forAdding.RemoveWhere(x => x.Action == action);

      if (!SubscriberRegistered(action, out IActivatableSubscriber<T> subscriber) || _forRemoving.Any(x => x.Action == action))
        return;

      if (_iterating)
        SafeRemove(subscriber);
      else
        Remove(subscriber);
    }

    public void Unsubscribe(IActivatableSubscriber<T> subscriber)
    {
      if (_forAdding.Contains(subscriber))
        _forAdding.Remove(subscriber);

      if (!SubscriberRegistered(subscriber.Action, out subscriber) || _forRemoving.Any(x => x.Action == subscriber.Action))
        return;

      if (_iterating)
        SafeRemove(subscriber);
      else
        Remove(subscriber);
    }

    private IActivatableSubscriber<T> RegisterSubscriber(IActivatableSubscriber<T> subscriber)
    {
      return _iterating ? SafeRegistration(subscriber) : Register(subscriber);
    }

    private bool CheckSubscriberRegistration(Action<T> action)
    {
      bool subscriberRegistered = SubscriberRegistered(action, out _);

      if (_forRemoving.Any(x => x.Action == action))
        Debug.LogWarning($"Try to subscribe and unsubscribe action <b>{action.Method.Name}</b> in one frame");
      else if (subscriberRegistered)
        Debug.LogWarning($"Try to subscribe already registered action: <b>{action.Method.Name}</b>");

      return subscriberRegistered;
    }

    private bool SubscriberRegistered(Action<T> action, out IActivatableSubscriber<T> subscriber)
    {
      subscriber = null;

      if (_actions.Any(x => x.Action == action))
      {
        subscriber = _actions.FirstOrDefault(x => x.Action == action);
        return true;
      }

      if (_forAdding.Any(x => x.Action == action))
      {
        subscriber = _forAdding.FirstOrDefault(x => x.Action == action);
        return true;
      }

      return false;
    }

    public void Raise(T argument)
    {
      if (_iterating)
        Iterate(argument);
      else
      {
        _iterating = true;
        Iterate(argument);

        _iterating = false;
        EndRemoving();
        EndRegistration();
      }
    }

    private void Iterate(T argument)
    {
      foreach (IActivatableSubscriber<T> subscriber in _actions) 
        subscriber.OnNext(argument);
    }

    private IActivatableSubscriber<T> Register(IActivatableSubscriber<T> subscriber)
    {
      _actions.Add(subscriber);
      return subscriber;
    }

    private IActivatableSubscriber<T> SafeRegistration(IActivatableSubscriber<T> subscriber)
    {
      _forAdding.Add(subscriber);
      return subscriber;
    }

    private void SafeRemove(IActivatableSubscriber<T> subscriber)
    {
      _forRemoving.Add(subscriber);
    }

    private void Remove(IActivatableSubscriber<T> subscriber)
    {
      _actions.Remove(subscriber);
    }

    private void EndRemoving()
    {
      foreach (IActivatableSubscriber<T> subscriber in _forRemoving)
        Remove(subscriber);

      _forRemoving.Clear();
    }

    private void EndRegistration()
    {
      foreach (IActivatableSubscriber<T> subscriber in _forAdding)
        Register(subscriber);

      _forAdding.Clear();
    }

    private void Complete()
    {
      _iterating = true;

      foreach (IActivatableSubscriber<T> subscriber in _actions)
        subscriber.OnCompleted();

      _iterating = false;
    }
  }
}