using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Game.Battles
{
  public class CombatantView : MonoBehaviour
  {
    [SerializeField]
    private CombatantRendering _rendering;
    
    [SerializeField]
    private Ease _ease;

    private Vector3 _homePosition;

    private void Start() =>
      _homePosition = transform.position;

    public CombatantView SetUp(CombatantData combatant)
    {
      _rendering.SetUp(combatant);
      return this;
    }
    
    public async UniTask GetHit()
    {
      await transform.DOShakePosition(0.1f, new Vector3(0.5f, 0, 0)).WithCancellation(this.GetCancellationTokenOnDestroy());
      await _rendering.OnGetHit();
      await UniTask.WaitForSeconds(0.2f);
    }

    public async UniTask Dead()
    {
      _rendering.OnDead();
      await transform.DOShakePosition(1f, 0.5f).WithCancellation(this.GetCancellationTokenOnDestroy());
      await UniTask.WaitForSeconds(1f);
    }

    public async UniTask MoveToHome()
    {
      await Move(_homePosition);
      _rendering.OnHome();
    }

    public async UniTask UpdateStats() =>
      await _rendering.UpdateStats();

    public async UniTask MoveToTarget(CombatantView target)
    {
      _rendering.OnAttack();
      Vector3 position = target.transform.position;
      position.x *= 0.3f;
      await Move(position);
    }

    private UniTask Move(Vector3 to) =>
      transform.DOMove(to, Durations.CombatantMove).SetEase(_ease)
               .WithCancellation(this.GetCancellationTokenOnDestroy());
  }
}