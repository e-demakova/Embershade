using UnityEngine;

namespace Game.Battles
{
  public class BattleUI : ControllableMono<BattleUI>
  {
    [SerializeField]
    private CanvasGroup _canvasGroup;

    public void Show() =>
      _canvasGroup.gameObject.SetActive(true);

    public void Hide() =>
      _canvasGroup.gameObject.SetActive(false);
  }
}