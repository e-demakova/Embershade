using System;

namespace Utils.Observing.Subscribers
{
  public interface ISubscriber<out T> : IDisposable
  {
    IDisposable Subscribe(Action<T> action);
    IDisposable Subscribe(Action action);
    ISubscriber<T> When(Func<T, bool> predicate);
  }

  public interface ISubscriber : ISubscriber<EmptyEvent> { }

  public interface IActivatableSubscriber<T> : ISubscriber<T>, IObserver<T>
  {
    Action<T> Action { get; }
  }
}