using Game.Dialogues;
using Game.Infrastructure.AssetsManagement;
using Game.Shop;

namespace Game.Cards
{
  public static class CardsList
  {
    public static CardData Hand => new()
    {
      BuyCost = 1,
      SpritePath = Assets.CardHand,
      Description = DescriptionsList.Hand
    };

    public static CardData Knife => new()
    {
      BuyCost = 1,
      SpritePath = Assets.CardKnife,
      Description = DescriptionsList.Atk
    };

    public static CardData Heart => new()
    {
      BuyCost = 1,
      SpritePath = Assets.CardHeart,
      Description = DescriptionsList.Hp
    };
  }
}