using UnityEngine;
using Utils.Observing.Handlers;
using Utils.Observing.Subscribers;

namespace Utils.Observing.GameObjects
{
  public class GameObjectLifeSubject : MonoBehaviour
  {
    private readonly Handler _onDestroy = new();

    private void OnDestroy()
    {
      _onDestroy.Raise();
      
      _onDestroy.Dispose();
    }

    public ISubscriber WhenDestroy() =>
      new Subscriber(_onDestroy);
  }
}