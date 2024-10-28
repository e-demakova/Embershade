using UnityEngine;

namespace Utils.Extensions
{
  public static class ComponentExtensions
  {
    public static T GetOrAdd<T>(this Component component) where T : Component =>
      component.gameObject.GetOrAdd<T>();

    public static T GetOrAdd<T>(this GameObject gameObject) where T : Component =>
      !gameObject.TryGetComponent(out T component) ? gameObject.AddComponent<T>() : component;

    public static T DontDestroyOnLoad<T>(this T component) where T : Component
    {
      Object.DontDestroyOnLoad(component.gameObject);
      return component;
    }
  }
}