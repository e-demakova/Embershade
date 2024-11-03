using Cysharp.Threading.Tasks;
using DG.Tweening;
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

    private void Start()
    {
      transform.DOScale(1.1f, 1f).SetEase(Ease.OutElastic).SetLoops(-1, LoopType.Yoyo)
               .WithCancellation(this.GetCancellationTokenOnDestroy());
    }

    protected override void OnClick() =>
      _arena.RunTurn();
  }
}