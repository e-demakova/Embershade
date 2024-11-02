using Game.Battles;
using Utils.UI;

namespace Game.Shop
{
  public class HeroUI : ButtonHandler
  {
    private CombatantData _data;
    private ShopUI _shop;
    
    public void SetUp(CombatantData data, ShopUI shopUI)
    {
      _data = data;
      _shop = shopUI;
    }
    
    protected override void OnClick() =>
      _shop.Select(_data);
  }
}