using Utils.StateMachine.States;

namespace Utils.StateMachine
{
  public interface IPayloadStateMachine<in T>
  {
    void Enter<TState, TPayload>(TPayload payload) where TState : class, T, IPayloadState<TPayload>;
  }
}