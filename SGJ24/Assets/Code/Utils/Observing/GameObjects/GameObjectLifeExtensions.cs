using UnityEngine;
using Utils.Extensions;
using Utils.Observing.Subscribers;

namespace Utils.Observing.GameObjects
{
  public static class GameObjectLifeExtensions
  {
    public static ISubscriber OnDestroy(this GameObject gameObject) => 
      gameObject.GetOrAdd<GameObjectLifeSubject>().WhenDestroy();
  }
}