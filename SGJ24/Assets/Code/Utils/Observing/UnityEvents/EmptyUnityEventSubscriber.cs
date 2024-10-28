using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Utils.Observing.UnityEvents
{
  public class EmptyUnityEventSubscriber : UnityEventSubscriber<EmptyEvent>
  {
    private readonly List<Func<EmptyEvent, bool>> _predicates = new();
    private readonly UnityEvent _event;

    public EmptyUnityEventSubscriber(UnityEvent unityEvent) =>
      _event = unityEvent;

    public override void Dispose() =>
      _event.RemoveListener(OnEvent);

    private void OnEvent()
    {
      if(Predicate(default))
        OnNext?.Invoke(default);
    }

    protected override IDisposable Subscribe()
    {
      _event.AddListener(OnEvent);
      return this;
    }
  }
}