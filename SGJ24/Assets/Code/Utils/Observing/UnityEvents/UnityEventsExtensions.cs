using System;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils.Observing.Subscribers;

namespace Utils.Observing.UnityEvents
{
  public static class UnityEventsExtensions
  {
    public static ISubscriber<EmptyEvent> OnClick(this Button button) =>
      button.onClick.AsHandler();
    
    public static IDisposable OnClick(this Button button, Action<EmptyEvent> action) =>
      button.onClick.AsHandler().Subscribe(action);

    public static IDisposable OnClick(this Button button, Action action) =>
      button.onClick.AsHandler().Subscribe(action);
    
    public static ISubscriber<EmptyEvent> AsHandler(this UnityEvent unityEvent) =>
      new EmptyUnityEventSubscriber(unityEvent);

    public static ISubscriber<T> AsHandler<T>(this UnityEvent<T> unityEvent) =>
      new ParameterUnityEventSubscriber<T>(unityEvent);
  }
}