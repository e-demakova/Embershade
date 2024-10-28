using System;

namespace Utils.Observing.Subscribers
{
  public static class SubscriberDebugExtensions
  {
    public static IDisposable Debug<T>(this ISubscriber<T> subscriber) =>
      subscriber.Subscribe(x => UnityEngine.Debug.Log(x));

    public static IDisposable Debug<T>(this ISubscriber<T> subscriber, string message) =>
      subscriber.Subscribe(x => UnityEngine.Debug.Log(message));

    public static IDisposable Debug<T>(this ISubscriber<T> subscriber, Func<T, string> message) =>
      subscriber.Subscribe(x => UnityEngine.Debug.Log(message?.Invoke(x)));


    public static IDisposable DebugError<T>(this ISubscriber<T> subscriber) =>
      subscriber.Subscribe(x => UnityEngine.Debug.LogError(x));

    public static IDisposable DebugError<T>(this ISubscriber<T> subscriber, string message) =>
      subscriber.Subscribe(x => UnityEngine.Debug.LogError(message));

    public static IDisposable DebugError<T>(this ISubscriber<T> subscriber, Func<T, string> message) =>
      subscriber.Subscribe(x => UnityEngine.Debug.LogError(message?.Invoke(x)));

    
    public static IDisposable DebugWarning<T>(this ISubscriber<T> subscriber) =>
      subscriber.Subscribe(x => UnityEngine.Debug.LogWarning(x));

    public static IDisposable DebugWarning<T>(this ISubscriber<T> subscriber, string message) =>
      subscriber.Subscribe(x => UnityEngine.Debug.LogWarning(message));

    public static IDisposable DebugWarning<T>(this ISubscriber<T> subscriber, Func<T, string> message) =>
      subscriber.Subscribe(x => UnityEngine.Debug.LogWarning(message?.Invoke(x)));
  }
}