using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Utils.Observing.SubjectProperties;

namespace Game.Battles
{
  public class CombatantView : MonoBehaviour
  {
    [FormerlySerializedAs("rendering")]
    [FormerlySerializedAs("_view")]
    [SerializeField]
    private CombatantRendering _rendering;
    
    [SerializeField]
    private Ease _ease;

    private Vector3 _homePosition;

    private void Start() =>
      _homePosition = transform.position;

    public async UniTask GetHit(SubjectInt hp)
    {
      _rendering.OnGetHit(hp);
      await transform.DOShakePosition(0.1f, new Vector3(0.5f, 0, 0)).WithCancellation(this.GetCancellationTokenOnDestroy());
    }

    public async UniTask Dead()
    {
      _rendering.OnDead();
      await transform.DOShakePosition(1f, 0.5f).WithCancellation(this.GetCancellationTokenOnDestroy());
    }

    public async UniTask MoveToHome()
    {
      await Move(_homePosition);
      _rendering.OnHome();
    }

    public async UniTask MoveToTarget(CombatantView target)
    {
      _rendering.OnAttack();
      Vector3 position = target.transform.position;
      position.x *= 0.7f;
      await Move(position);
    }

    private UniTask Move(Vector3 to) =>
      transform.DOMove(to, Durations.CombatantMove).SetEase(_ease)
               .WithCancellation(this.GetCancellationTokenOnDestroy());
  }
}