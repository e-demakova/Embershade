using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Game
{
  public class MainCamera : ControllableMono<MainCamera>
  {
    private static readonly float ZoomInTarget = -6;
    private static readonly float ZoomInDuration = 0.4f;

    private static readonly float ZoomOutTarget = -10;
    private static readonly float ZoomOutDuration = 0.2f;

    public async UniTask ZoomOut() =>
      await Zoom(ZoomOutTarget, ZoomOutDuration);

    public async UniTask ZoomIn() =>
      await Zoom(ZoomInTarget, ZoomInDuration);

    public async UniTask Zoom(float to, float duration)
    {
      if (Math.Abs(transform.position.z - to) < 0.1f)
        return;

      await DOTween.Sequence()
                   .Join(transform.DOMoveZ(to, duration))
                   .Join(transform.DOMoveY(0.3f, duration / 2).SetLoops(2, LoopType.Yoyo))
                   .SetEase(Ease.InOutQuad)
                   .WithCancellation(this.GetCancellationTokenOnDestroy());
    }

    public async UniTask Shake() =>
      await transform.DOShakePosition(0.3f, 0.3f).WithCancellation(this.GetCancellationTokenOnDestroy());
  }
}