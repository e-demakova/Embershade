using Utils.UI;
using Zenject;

namespace Game.Battles
{
  public class BattleButton : ButtonHandler
  {
    private IArena _arena;

    [Inject]
    private void Construct(IArena arena) =>
      _arena = arena;

    protected override void OnClick() =>
      _arena.RunTurn();
  }
}