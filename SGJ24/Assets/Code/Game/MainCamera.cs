using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Game
{
  public class MainCamera : ControllableMono<MainCamera>
  {
    public async UniTask Zoom(float to, float duration) =>
      await transform.DOMoveZ(to, duration).WithCancellation(this.GetCancellationTokenOnDestroy());
  }
}