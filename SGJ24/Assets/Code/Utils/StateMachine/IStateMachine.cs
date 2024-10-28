using Utils.StateMachine.States;

namespace Utils.StateMachine
{
  public interface IStateMachine<in T>
  {
    void RegisterState(T state);
    void Enter<TState>() where TState : class, T, IEnterState;
  }
}