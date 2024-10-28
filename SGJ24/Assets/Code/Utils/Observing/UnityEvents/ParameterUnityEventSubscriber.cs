using System;
using UnityEngine.Events;

namespace Utils.Observing.UnityEvents
{
  public class ParameterUnityEventSubscriber<T> : UnityEventSubscriber<T>
  {
    private readonly UnityEvent<T> _event;

    public ParameterUnityEventSubscriber(UnityEvent<T> unityEvent) =>
      _event = unityEvent;

    public override void Dispose() =>
      _event.RemoveListener(OnEvent);

    protected override IDisposable Subscribe()
    {
      _event.AddListener(OnEvent);
      return this;
    }

    private void OnEvent(T value)
    {
      if (Predicate(value))
        OnNext?.Invoke(value);
    }
  }
}