using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Extensions
{
  public static class CollectionExtensions
  {
    public static T Random<T>(this IReadOnlyCollection<T> list) =>
      list.ElementAt(UnityEngine.Random.Range(0, list.Count));
    
    public static T Random<T>(this T[] array) =>
      array[UnityEngine.Random.Range(0, array.Length)];
    
    public static T AddTo<T>(this T element, List<T> list)
    {
      list.Add(element);
      return element;
    }

    public static void DisposeAll(this ICollection<IDisposable> list)
    {
      foreach (IDisposable disposable in list)
        disposable?.Dispose();

      list.Clear();
    }
    
    public static TValue SafeGet<TKey, TValue>(this Dictionary<TKey, TValue> collection, TKey key) where TValue : new()
    {
      if (!collection.TryGetValue(key, out TValue value))
      {
        value = new TValue();
        collection[key] = value;
      }

      return value;
    }
    
    public static T SafeGet<T, TValue>(this Dictionary<Type, TValue> collection) where T : TValue, new()
    {
      if (!collection.TryGetValue(typeof(T), out TValue value))
      {
        value = new T();
        collection[typeof(T)] = value;
      }

      return (T) value;
    }
  }
}