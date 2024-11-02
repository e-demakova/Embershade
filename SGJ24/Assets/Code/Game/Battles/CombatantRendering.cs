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

    private void Start() =>
      _canvasGroup.alpha = 0;

    public void OnAttack()
    {
      _renderer.sortingOrder = 1;
      _canvasGroup.alpha = 0;
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
      _canvasGroup.alpha = 0;
    }

    public void OnGetHit(SubjectInt hp) =>
      _hpSlider.fillAmount = hp.Value / (float) hp.Max;
  }
}