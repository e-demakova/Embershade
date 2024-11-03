using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.SmartDebug;

namespace Game.Infrastructure.Data
{
  public class SceneData : IData
  {
    private readonly Dictionary<Type, MonoBehaviour> _behaviours = new();

    public T Get<T>() where T : ControllableMono<T>, new()
    {
      if (_behaviours.TryGetValue(typeof(T), out MonoBehaviour mono))
        return (T) mono;

      LogNotFound<T>();
      return null;
    }

    public bool TryGet<T>(out T t) where T : ControllableMono<T>, new()
    {
      t = _behaviours.TryGetValue(typeof(T), out MonoBehaviour mono)
        ? mono as T
        : null;

      return t != null;
    }

    public void Register<T>(ControllableMono<T> mono) where T : ControllableMono<T>
    {
      if (_behaviours.ContainsKey(typeof(T)))
      {
        LogDuplicate<T>();
        return;
      }

      _behaviours.Add(typeof(T), mono);
    }

    public void Unregister<T>() where T : ControllableMono<T> =>
      _behaviours.Remove(typeof(T));

    private static void LogDuplicate<T>() where T : ControllableMono<T>
    {
      DLogger.Message(DSenders.SceneData)
             .WithText("Object with type: " + $"{typeof(T)}".White().Bold() + " already added")
             .WithFormat(DebugFormat.Error)
             .Log();
    }

    private static void LogNotFound<T>() where T : ControllableMono<T>, new()
    {
      DLogger.Message(DSenders.SceneData)
             .WithText("Can't find object with type: " + $"{typeof(T)}".White().Bold())
             .WithFormat(DebugFormat.Exception)
             .Log();
    }
  }
}