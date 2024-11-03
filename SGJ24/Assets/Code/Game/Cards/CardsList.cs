using Game.Infrastructure.AssetsManagement;
using Game.Shop;

namespace Game.Cards
{
  public static class CardsList
  {
    public static CardData Eye => new()
    {
      BuyCost = 2,
      SellCost = 1,
      SpritePath = Assets.CardEye,
      Spell = new DecreaseEnemyAtkSpell(1)
    };

    public static CardData Finger => new()
    {
      BuyCost = 2,
      SellCost = 1,
      SpritePath = Assets.CardFinger,
      Spell = new IncreaseAtkSpell(1)
    };

    public static CardData Cake => new()
    {
      BuyCost = 2,
      SellCost = 1,
      SpritePath = Assets.CardCake,
      Spell = new IncreaseHpSpell(2)
    };
  }
}