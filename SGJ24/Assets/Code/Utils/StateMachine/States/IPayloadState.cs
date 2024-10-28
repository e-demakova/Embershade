namespace Utils.StateMachine.States
{
  public interface IPayloadState<in T>
  {
    public void Enter(T payload);
  }
}