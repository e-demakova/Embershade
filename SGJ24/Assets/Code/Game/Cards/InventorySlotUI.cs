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

    private CardData _card;
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
      _card = card;
      _image.sprite = _assets.LoadAsset<Sprite>(card.SpritePath);
      _image.enabled = true;
    }

    public void Clear()
    {
      _card = null;
      _image.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      if (_card != null)
        _data.Get<SceneData>().Get<InventoryTooltip>().Show((RectTransform) transform, _card);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      if (_card != null)
        _data.Get<SceneData>().Get<InventoryTooltip>().Hide();
    }

    protected override void OnClick()
    {
      if (_card != null && _data.Get<SceneData>().TryGet(out ShopUI shop))
        shop.SellCard(_card);
    }
  }
}