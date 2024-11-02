using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Game
{
  public class MainCamera : ControllableMono<MainCamera>
  {
    public async UniTask Zoom(float to, float duration)
    {
      await DOTween.Sequence()
                   .Join(transform.DOMoveZ(to, duration))
                   .Join(transform.DOMoveY(0.3f, duration / 2).SetLoops(2, LoopType.Yoyo))
                   .SetEase(Ease.InOutQuad)
                   .WithCancellation(this.GetCancellationTokenOnDestroy());
    }

    public async UniTask Move(Vector3 to, float duration) =>
      await transform.DOMove(to, duration).WithCancellation(this.GetCancellationTokenOnDestroy());

    public async UniTask Shake() =>
      await transform.DOShakePosition(0.1f).WithCancellation(this.GetCancellationTokenOnDestroy());
  }
}