using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Utils.Observing.SubjectProperties;

namespace Game.Battles
{
  public class CombatantRendering : MonoBehaviour
  {
    [SerializeField]
    private SpriteRenderer _renderer;

    [SerializeField]
    private GameObject _defaultView;

    [SerializeField]
    private GameObject _deadView;

    [SerializeField]
    private Image _hpSlider;

    [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    private List<SpriteRenderer> _renderers;
    [SerializeField]
    private List<SpriteMask> _masks;
    
    public void SetSprite(Sprite sprite)
    {
      foreach (SpriteRenderer spriteRenderer in _renderers) 
        spriteRenderer.sprite = sprite;

      foreach (SpriteMask mask in _masks)
        mask.sprite = sprite;
    }

    private void Start()
    {
      _canvasGroup.alpha = 0;
    }

    public void OnAttack()
    {
      _renderer.sortingOrder = 1;
      FadeCanvasGroup();
    }

    public void OnHome()
    {
      _renderer.sortingOrder = 0;
      _canvasGroup.alpha = 1;
    }

    public void OnDead()
    {
      _defaultView.SetActive(false);
      _deadView.SetActive(true);
      _canvasGroup.alpha = 0f;
    }

    public void OnGetHit(SubjectInt hp)
    {
      _canvasGroup.alpha = 1;
      _hpSlider.fillAmount = hp.Value / (float) hp.Max;
    }

    private void FadeCanvasGroup() =>
      _canvasGroup.DOFade(0, 0.1f).WithCancellation(_canvasGroup.GetCancellationTokenOnDestroy());
  }
}