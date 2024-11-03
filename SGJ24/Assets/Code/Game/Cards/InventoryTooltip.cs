using Game.Infrastructure.Data;
using Game.Shop;
using TMPro;
using UnityEngine;
using Utils.Localization;
using Zenject;

namespace Game.Cards
{
  public class InventoryTooltip : ControllableMono<InventoryTooltip>
  {
    [SerializeField]
    private CanvasGroup _canvasGroup;
    
    [SerializeField]
    private TextMeshProUGUI _description;
    
    [SerializeField]
    private TextMeshProUGUI _sellCost;

    private IGameData _data;

    [Inject]
    private void Construct(IGameData data)
    {
      _data = data;
    }
    
    public void Show(RectTransform rectTransform, CardData card)
    {
      Vector3 position = transform.position;
      position.x = rectTransform.position.x;
      transform.position = position;

      _canvasGroup.alpha = 1;
      _description.text = card.Spell.Description(_data.Get<LocalizationData>());
      _sellCost.text = card.SellCost.ToString();
    }

    public void Hide() =>
      _canvasGroup.alpha = 0;
  }
}