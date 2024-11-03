using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Utils.UI;
using Zenject;

namespace Game.Battles
{
  public class BattleButton : ButtonHandler
  {
    private IArena _arena;
    private CancellationTokenSource _onDisable;

    [Inject]
    private void Construct(IArena arena) =>
      _arena = arena;

    private void OnEnable()
    {
      _onDisable = new CancellationTokenSource();
      transform.DOScale(1.1f, 1f).SetEase(Ease.OutElastic).SetLoops(-1, LoopType.Yoyo)
               .WithCancellation(_onDisable.Token);
    }

    private void OnDisable() =>
      _onDisable?.Cancel();

    protected override void OnClick() =>
      _arena.RunTurn();
  }
}