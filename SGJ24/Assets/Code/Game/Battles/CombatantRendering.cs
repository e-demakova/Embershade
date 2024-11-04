using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Infrastructure.AssetsManagement;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Battles
{
  public class CombatantRendering : MonoBehaviour
  {
    [SerializeField]
    private ParticleSystem _particle;

    [SerializeField]
    private SpriteRenderer _renderer;

    [SerializeField]
    private GameObject _defaultView;

    [SerializeField]
    private GameObject _deadView;

    [SerializeField]
    private TextMeshProUGUI _hpValue;

    [SerializeField]
    private TextMeshProUGUI _atkValue;

    [SerializeField]
    private Transform _hpContainer;

    [SerializeField]
    private Transform _atkContainer;

    [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    private List<SpriteRenderer> _renderers;

    [SerializeField]
    private List<SpriteMask> _masks;

    [SerializeField]
    private TextMeshProUGUI _soulsCount;
    
    [SerializeField]
    private GameObject _soulsDrop;
    
    private IAssetProvider _assets;
    private CombatantData _combatant;
    private int _prevHp;
    private int _prevAtk;

    public bool StatsChanged => _prevHp != _combatant.Stats.Hp || _prevAtk != _combatant.Stats.Atk;
    
    [Inject]
    private void Construct(IAssetProvider assets)
    {
      _assets = assets;
    }

    public void SetUp(CombatantData combatant)
    {
      _combatant = combatant;

      SetUpSprite();
      SetUpStats();
    }

    public void OnAttack() =>
      _renderer.sortingOrder = 1;

    public void OnHome() =>
      _renderer.sortingOrder = 0;

    public void OnDead()
    {
      _canvasGroup.alpha = 0;
      _defaultView.SetActive(false);
      _deadView.SetActive(true);
    }

    public async UniTask OnGetHit() =>
      await UpdateStats();

    public async UniTask UpdateStats()
    {
      await UniTask.WhenAll(
        UpdateStat(_prevHp, _combatant.Stats.Hp, _hpValue, _hpContainer),
        UpdateStat(_prevAtk, _combatant.Stats.Atk, _atkValue, _atkContainer));

      _prevHp = _combatant.Stats.Hp;
      _prevAtk = _combatant.Stats.Atk;
    }

    public async UniTask DropSouls(int souls)
    {
      _soulsCount.text = souls.ToString();
      _soulsDrop.gameObject.SetActive(true);
      await UniTask.WaitForSeconds(0.7f);
    }

    private async UniTask UpdateStat(int prev, int current, TextMeshProUGUI text, Transform container)
    {
      if (prev == current)
        return;

      await container.DOScale(1.3f, 0.2f)
                     .SetEase(Ease.InExpo)
                     .SetLoops(2, LoopType.Yoyo)
                     .WithCancellation(text.GetCancellationTokenOnDestroy());

      text.text = current.ToString();
    }

    private void SetUpSprite()
    {
      Sprite sprite = _assets.LoadAsset<Sprite>(_combatant.SpritePath);

      _particle.textureSheetAnimation.SetSprite(0, sprite);
      foreach (SpriteRenderer spriteRenderer in _renderers)
        spriteRenderer.sprite = sprite;

      foreach (SpriteMask mask in _masks)
        mask.sprite = sprite;
    }

    private void SetUpStats()
    {
      _prevHp = _combatant.Stats.Hp;
      _prevAtk = _combatant.Stats.Atk;
      _hpValue.text = _combatant.Stats.Hp.ToString();
      _atkValue.text = _combatant.Stats.Atk.ToString();
    }
  }
}