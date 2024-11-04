using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Game
{
  public class SimpleTweener : MonoBehaviour
  {
    [SerializeField]
    private Vector3 _rotation;

    [SerializeField]
    private float _move;

    [SerializeField]
    private float _rotationDuration;

    [SerializeField]
    private float _moveDuration;

    private CancellationTokenSource _disable;

    private void OnDisable() =>
      _disable.Cancel();

    private void OnEnable()
    {
      _disable = new CancellationTokenSource();
      transform.DOLocalMoveY(transform.position.y + _move, _moveDuration).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo)
               .WithCancellation(_disable.Token);

      transform.DOLocalRotate(_rotation, _rotationDuration).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo)
               .WithCancellation(_disable.Token);
    }
  }
}