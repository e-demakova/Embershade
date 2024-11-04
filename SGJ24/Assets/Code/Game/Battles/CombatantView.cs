using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Audio;
using UnityEngine;
using Zenject;

namespace Game.Battles
{
  public class CombatantView : MonoBehaviour
  {
    [SerializeField]
    private CombatantRendering _rendering;
    
    [SerializeField]
    private Ease _ease;

    [SerializeField]
    private AudioClip _dead;
    
    [SerializeField]
    private AudioClip _updateStat;
    
    [SerializeField]
    private AudioClip _hit;
    
    private Vector3 _homePosition;
    private IAudioPlayer _audioPlayer;

    [Inject]
    private void Construct(IAudioPlayer audioPlayer)
    {
      _audioPlayer = audioPlayer;
    }
    
    private void Start() =>
      _homePosition = transform.position;

    public CombatantView SetUp(CombatantData combatant)
    {
      _rendering.SetUp(combatant);
      return this;
    }
    
    public async UniTask GetHit()
    {
      _audioPlayer.PlaySound(_hit);
      await transform.DOShakePosition(0.1f, new Vector3(0.5f, 0, 0)).WithCancellation(this.GetCancellationTokenOnDestroy());
      await _rendering.OnGetHit();
      await UniTask.WaitForSeconds(0.2f);
    }

    public async UniTask Dead()
    {
      _audioPlayer.PlaySound(_dead);
      _rendering.OnDead();
      await transform.DOShakePosition(1f, 0.5f).WithCancellation(this.GetCancellationTokenOnDestroy());
      await UniTask.WaitForSeconds(0.5f);
    }

    public async UniTask MoveToHome()
    {
      await Move(_homePosition);
      _rendering.OnHome();
    }

    public async UniTask UpdateStats()
    {
      if(!_rendering.StatsChanged)
         return;
      
      _audioPlayer.PlaySound(_updateStat);
      await _rendering.UpdateStats();
    }

    public async UniTask MoveToTarget(CombatantView target)
    {
      _rendering.OnAttack();
      Vector3 position = target.transform.position;
      position.x *= 0.3f;
      await Move(position);
    }

    public async UniTask DropSouls(int souls) =>
      await _rendering.DropSouls(souls);

    private UniTask Move(Vector3 to) =>
      transform.DOMove(to, Durations.CombatantMove).SetEase(_ease)
               .WithCancellation(this.GetCancellationTokenOnDestroy());
  }
}