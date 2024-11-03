using Game.Infrastructure.AssetsManagement;
using Game.Shop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Cards
{
  public class InventorySlotUI : MonoBehaviour
  {
    [SerializeField]
    private Image _image;

    private CardData _card;
    private IAssetProvider _assets;

    [Inject]
    private void Construct(IAssetProvider assets)
    {
      _assets = assets;
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
  }
}