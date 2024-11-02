using UnityEngine;

namespace Game.Battles
{
  public class BattleUI : ControllableMono<BattleUI>
  {
    [SerializeField]
    private CanvasGroup _canvasGroup;

    public void Show()
    {
      _canvasGroup.alpha = 1;
      _canvasGroup.interactable = true;
      _canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
      _canvasGroup.alpha = 0;
      _canvasGroup.interactable = false;
      _canvasGroup.blocksRaycasts = false;
    }
  }
}