using UnityEngine.InputSystem;
using Utils.Observing.Subscribers;

namespace Game.PlayerInput
{
  public static class InputSubscriberExtensions
  {
    public static ISubscriber<InputContext> Down(this ISubscriber<InputContext> subscriber) =>
      subscriber.When(x => x.Phase == InputActionPhase.Started);

    public static ISubscriber<InputContext> Up(this ISubscriber<InputContext> subscriber) =>
      subscriber.When(x => x.Phase == InputActionPhase.Canceled);

    public static ISubscriber<InputContext> Performed(this ISubscriber<InputContext> subscriber) =>
      subscriber.When(x => x.Phase == InputActionPhase.Performed);

    public static ISubscriber<InputContext> Button(this ISubscriber<InputContext> subscriber, InputActionPhase phase) =>
      subscriber.When(x => x.Phase == phase);
  }
}