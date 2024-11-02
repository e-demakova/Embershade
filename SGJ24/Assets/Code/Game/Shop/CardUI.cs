using Utils.UI;

namespace Game.Shop
{
  public class CardUI : ButtonHandler
  {
    private CardData _data;
    private ShopUI _shop;

    public void SetUp(CardData data, ShopUI shopUI)
    {
      _data = data;
      _shop = shopUI;
    }

    protected override void OnClick()
    {
      if (!_shop.CanBuy(_data))
        return;

      _shop.Buy(_data);
      gameObject.SetActive(false);
    }
  }
}