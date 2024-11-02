using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Battles
{
  public class CombatantView : MonoBehaviour
  {
    [FormerlySerializedAs("_view")]
    [SerializeField]
    private CombatantRendering rendering;
    
    [SerializeField]
    private Ease _ease;

    private Vector3 _homePosition;

    private void Start() =>
      _homePosition = transform.position;

    public async UniTask GetHit() =>
      await transform.DOShakePosition(0.1f, new Vector3(0.5f, 0, 0)).WithCancellation(this.GetCancellationTokenOnDestroy());

    public async UniTask Dead()
    {
      rendering.Dead();
      await transform.DOShakePosition(1f, 0.5f).WithCancellation(this.GetCancellationTokenOnDestroy());
    }

    public async UniTask MoveToHome()
    {
      await Move(_homePosition);
      rendering.SetToBack();
    }

    public async UniTask MoveToTarget(CombatantView target)
    {
      rendering.SetToFront();
      Vector3 position = target.transform.position;
      position.x *= 0.7f;
      await Move(position);
    }

    private UniTask Move(Vector3 to) =>
      transform.DOMove(to, Durations.CombatantMove).SetEase(_ease)
               .WithCancellation(this.GetCancellationTokenOnDestroy());
  }
}