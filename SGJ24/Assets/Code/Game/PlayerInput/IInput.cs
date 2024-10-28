using Input;
using UnityEngine.EventSystems;

namespace Game.PlayerInput
{
  public interface IInput
  {
    EventSystem EventSystem { get; }
    bool Enabled { set; }
    public Actions.PlayerActions Main { get; }
  }
}