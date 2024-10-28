using System.Collections.Generic;
using Zenject;

namespace Utils.StateMachine
{
  public class StateMachineInitializer<T> : IInitializable
  {
    private readonly List<T> _states;
    private readonly IStateMachine<T> _stateMachine;

    public StateMachineInitializer(IStateMachine<T> stateMachine, List<T> states)
    {
      _states = states;
      _stateMachine = stateMachine;
    }

    public void Initialize() =>
      RegisterStates();

    private void RegisterStates()
    {
      foreach (T state in _states)
        _stateMachine.RegisterState(state);
    }
  }
}