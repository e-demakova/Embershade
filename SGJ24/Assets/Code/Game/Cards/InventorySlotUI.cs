using Game.Infrastructure.AssetsManagement;
using Game.Infrastructure.Data;
using Game.Shop;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.UI;
using Zenject;

namespace Game.Cards
{
  public class InventorySlotUI : ButtonHandler, IPointerEnterHandler, IPointerExitHandler
  {
    [SerializeField]
    private Image _image;

    public CardData Card;
    private IAssetProvider _assets;
    private IGameData _data;

    [Inject]
    private void Construct(IAssetProvider assets, IGameData data)
    {
      _assets = assets;
      _data = data;
    }

    public void SetUp(CardData card)
    {
      Card = card;
      _image.sprite = _assets.LoadAsset<Sprite>(card.SpritePath);
      _image.enabled = true;
    }

    public void Clear()
    {
      Card = null;
      _image.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      if (Card != null && _data.Get<SceneData>().TryGet(out ShopUI _))
        _data.Get<SceneData>().Get<InventoryTooltip>().Show((RectTransform) transform, Card);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      if (Card != null && _data.Get<SceneData>().TryGet(out ShopUI _))
        HideTooltip();
    }

    protected override void OnClick()
    {
      if (Card != null && _data.Get<SceneData>().TryGet(out ShopUI shop))
      {
        HideTooltip();
        shop.SellCard(Card);
      }
    }

    private void HideTooltip() =>
      _data.Get<SceneData>().Get<InventoryTooltip>().Hide();
  }
}