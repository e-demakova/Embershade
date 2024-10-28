using System;
using System.Collections.Generic;
using Utils.StateMachine.States;

namespace Utils.StateMachine
{
  public abstract class SimpleStateMachine<T> : IStateMachine<T>, IPayloadStateMachine<T>
  {
    private readonly Dictionary<Type, T> _states = new();
    private T _state;

    protected abstract StateMachineLogger Logger { get; }
    
    public void RegisterState(T state) =>
      _states.Add(state.GetType(), state);

    public void Enter<TState>() where TState : class, T, IEnterState
    {
      Switch<TState>();
      
      if (_state is IEnterState enterState)
        enterState.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, T, IPayloadState<TPayload>
    {
      Switch<TState>();
      
      IPayloadState<TPayload> state = (IPayloadState<TPayload>) _state;
      state.Enter(payload);
    }

    private void Switch<TState>() where TState : class, T
    {
      T next = _states[typeof(TState)];
      Logger.LogEnter(next, _state);

      if (_state is IExitState exitState)
        exitState.Exit();

      _state = next;
    }
  }
}