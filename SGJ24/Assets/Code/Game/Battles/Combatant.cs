using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Game.Battles
{
  public class Combatant : MonoBehaviour
  {
    [SerializeField]
    private Ease _ease;
    
    private Vector2 _homePosition;

    private void Start() =>
      _homePosition = transform.position;

    public bool TargetMatch(Combatant target) =>
      target != this;

    public async UniTask MoveToHome() =>
      await Move(_homePosition);

    public async UniTask MoveToTarget(Combatant target) =>
      await Move(target.transform.position);

    private UniTask Move(Vector3 to) =>
      transform.DOMove(to, Durations.CombatantMove).SetEase(_ease)
               .WithCancellation(this.GetCancellationTokenOnDestroy());
  }
}