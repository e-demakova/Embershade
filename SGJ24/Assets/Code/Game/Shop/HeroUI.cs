using Game.Battles;
using Game.Infrastructure.AssetsManagement;
using UnityEngine;
using UnityEngine.UI;
using Utils.UI;
using Zenject;

namespace Game.Shop
{
  public class HeroUI : ButtonHandler
  {
    [SerializeField]
    private Image _image;
    
    private CombatantData _data;
    private ShopUI _shop;
    private IAssetProvider _assets;

    [Inject]
    private void Construct(IAssetProvider assets)
    {
      _assets = assets;
    }
    
    public void SetUp(CombatantData data, ShopUI shopUI)
    {
      _data = data;
      _shop = shopUI;
      _image.sprite = _assets.LoadAsset<Sprite>(data.SpritePath);
    }
    
    protected override void OnClick()
    {
      _shop.Select(_data);
    }
  }
}