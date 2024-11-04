using Game.Audio;
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

    [SerializeField]
    private Image _soulIcon;

    [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    private AudioClip _sound;

    private CardData _data;
    private IGameData _gameData;
    private IAssetProvider _assets;
    private IAudioPlayer _audioPlayer;

    private ShopUI Shop => _gameData.Get<SceneData>().Get<ShopUI>();

    [Inject]
    private void Construct(IAssetProvider assets, IGameData data, IAudioPlayer audioPlayer)
    {
      _gameData = data;
      _assets = assets;
      _audioPlayer = audioPlayer;
    }

    public void SetUp(CardData data)
    {
      _data = data;

      _image.sprite = _assets.LoadAsset<Sprite>(data.SpritePath);
      _description.text = data.Spell.Description(_gameData.Get<LocalizationData>());
      _cost.text = _data.BuyCost.ToString();
      UpdateCostView();
    }

    public void UpdateCostView()
    {
      bool canBuy = _gameData.Get<SoulsData>().InWallet >= _data.BuyCost;

      _cost.color = canBuy ? Color.white : Color.red;
      _soulIcon.color = canBuy ? Color.white : Color.red;
      _canvasGroup.alpha = canBuy ? 1 : 0.5f;
    }

    protected override void OnClick()
    {
      if (!Shop.CanBuy(_data))
        return;

      Shop.Buy(_data);
      gameObject.SetActive(false);
      _audioPlayer.PlaySound(_sound);
    }
  }
}