using Game.Battles;
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
  public class HeroUI : ButtonHandler
  {
    [SerializeField]
    private Image _image;

    [SerializeField]
    private TextMeshProUGUI _description;
    
    private CombatantData _data;
    private IAssetProvider _assets;
    private IGameData _gameData;

    private ShopUI Shop => _gameData.Get<SceneData>().Get<ShopUI>();

    [Inject]
    private void Construct(IAssetProvider assets, IGameData data)
    {
      _assets = assets;
      _gameData = data;
    }

    public void SetUp(CombatantData data)
    {
      _data = data;
      _image.sprite = _assets.LoadAsset<Sprite>(data.SpritePath);
      _description.text = _gameData.Get<LocalizationData>().GetString(_data.Description);
    }
    
    protected override void OnClick() =>
      Shop.Select(_data);
  }
}