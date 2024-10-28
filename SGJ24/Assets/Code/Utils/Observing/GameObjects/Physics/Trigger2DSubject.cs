using UnityEngine;
using Utils.Observing.Handlers;

namespace Utils.Observing.GameObjects.Physics
{
  public class Trigger2DSubject : MonoBehaviour
  {
    private readonly Handler<Collider2D> _onEnter = new();
    private readonly Handler<Collider2D> _onExit = new();
    
    private void OnEnable()
    {
      if (!TryGetComponent<Collider2D>(out _)) 
        Debug.LogError($"<b>Collider2D</b> don't found at <b>{name}</b>");
    }

    private void OnDestroy()
    {
      _onEnter.Dispose();
      _onExit.Dispose();
    }

    public ITriggerSubscriber2D OnEnter() => 
      new TriggerSubscriber2D(_onEnter);

    public ITriggerSubscriber2D OnExit() => 
      new TriggerSubscriber2D(_onExit);

    private void OnTriggerEnter2D(Collider2D other) => 
      _onEnter.Raise(other);

    private void OnTriggerExit2D(Collider2D other) => 
      _onExit.Raise(other);
  }
}