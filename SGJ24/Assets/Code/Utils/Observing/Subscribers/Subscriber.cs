using System;
using System.Collections.Generic;
using Utils.Observing.Handlers;

namespace Utils.Observing.Subscribers
{
  public class Subscriber : Subscriber<EmptyEvent>, ISubscriber
  {
    public Subscriber(IHandler<EmptyEvent> handler, Action<EmptyEvent> action = default)
      : base(handler, action) { }
  }

  public class Subscriber<T> : IActivatableSubscriber<T>
  {
    private readonly List<Func<T, bool>> _predicates = new();
    private readonly IHandler<T> _handler;

    public Action<T> Action { get; private set; }

    public Subscriber(IHandler<T> handler, Action<T> action = default)
    {
      _handler = handler;
      Action = action;
    }

    public void Dispose() =>
      _handler.Unsubscribe(this);

    public IDisposable Subscribe(Action<T> action)
    {
      Action = action;
      return Subscribe();
    }

    public IDisposable Subscribe(Action action)
    {
      Action = _ => action?.Invoke();
      return Subscribe();
    }

    private IDisposable Subscribe()
    {
      _handler.Subscribe(this);
      return this;
    }

    public void OnNext(T value)
    {
      if (Predicate(value) && CustomPredicate(value))
        Action?.Invoke(value);
    }

    public ISubscriber<T> When(Func<T, bool> predicate)
    {
      _predicates.Add(predicate);
      return this;
    }

    protected virtual bool CustomPredicate(T value) =>
      true;

    private bool Predicate(T value)
    {
      for (var i = 0; i < _predicates.Count; i++)
      {
        if (!_predicates[i](value))
          return false;
      }

      return true;
    }

    public override string ToString() =>
      Action.Method.Name;

    void IObserver<T>.OnCompleted() { }

    void IObserver<T>.OnError(Exception error) { }
  }
}