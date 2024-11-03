using Game.Infrastructure.AssetsManagement;
using Game.Infrastructure.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Localization;
using Utils.UI;
using Zenject;

namespace Game.Shop
{
  public class CardUI : ButtonHandler
  {
    [SerializeField]
    private Image _image;

    [SerializeField]
    private TextMeshProUGUI _description;

    [SerializeField]
    private TextMeshProUGUI _cost;

    private CardData _data;
    private ShopUI _shop;
    private IGameData _gameData;
    private IAssetProvider _assets;

    [Inject]
    private void Construct(IAssetProvider assets, IGameData data)
    {
      _gameData = data;
      _assets = assets;
    }

    public void SetUp(CardData data, ShopUI shopUI)
    {
      _data = data;
      _shop = shopUI;

      _image.sprite = _assets.LoadAsset<Sprite>(data.SpritePath);
      _description.text = _gameData.Get<LocalizationData>().GetString(_data.Description);
      _cost.text = _data.BuyCost.ToString();
      UpdateCostView();
    }

    public void UpdateCostView() =>
      _cost.color = _gameData.Get<SoulsData>().InWallet >= _data.BuyCost ? Color.white : Color.red;

    protected override void OnClick()
    {
      if (!_shop.CanBuy(_data))
        return;

      _shop.Buy(_data);
      gameObject.SetActive(false);
    }
  }
}