using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Game.Battles
{
  public class CombatantScaleTween : MonoBehaviour
  {
    [SerializeField]
    private float _scale;

    [SerializeField]
    private float _duration;

    private CancellationTokenSource _disable;

    private void OnDisable() =>
      _disable.Cancel();

    private void OnEnable()
    {
      _disable = new CancellationTokenSource();
      transform.DOScaleY(transform.localScale.y + _scale, _duration).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo)
               .WithCancellation(_disable.Token);
    }
  }
}