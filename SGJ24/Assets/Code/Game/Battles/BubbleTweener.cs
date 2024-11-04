using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Game.Battles
{
  public class BubbleTweener : MonoBehaviour
  {
    private CancellationTokenSource _onDisable;
    
    private void OnEnable()
    {
      _onDisable = new CancellationTokenSource();
      transform.DOScale(1.1f, 1f).SetEase(Ease.OutElastic).SetLoops(-1, LoopType.Yoyo)
               .WithCancellation(_onDisable.Token);
    }

    private void OnDisable() =>
      _onDisable?.Cancel();
  }
}