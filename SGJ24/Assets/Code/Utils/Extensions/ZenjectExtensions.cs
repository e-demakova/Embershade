using Zenject;

namespace Utils.Extensions
{
  public static class ZenjectExtensions
  {
    public static void FullBind<T>(this DiContainer container, T instance)
    {
      container.BindInterfacesAndSelfTo<T>().FromInstance(instance).AsSingle().NonLazy();
    }

    public static void BindService<T>(this DiContainer container)
    {
      container.BindInterfacesTo<T>().AsSingle().NonLazy();
    }

    public static void FullBind<T>(this DiContainer container)
    {
      container.BindInterfacesAndSelfTo<T>().AsSingle().NonLazy();
    }
  }
}