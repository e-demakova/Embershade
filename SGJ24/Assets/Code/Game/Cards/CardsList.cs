using System.Collections.Generic;
using Game.Infrastructure.AssetsManagement;
using Game.Shop;

namespace Game.Cards
{
  public static class CardsList
  {
    public static List<CardData> Common => new()
    {
      Eye,
      Finger,
      Cake
    };
    
    public static List<CardData> Trash => new()
    {
      EyeTrash,
      FingerTrash,
      CakeTrash
    };
    
    public static List<CardData> Rare => new()
    {
      EyeRare,
      FingerRare,
      CakeRare
    };
    
    public static List<CardData> Immortal => new()
    {
      Skull,
      Hand,
      FullCake
    };

    public static CardData EyeTrash => new()
    {
      BuyCost = 1,
      SellCost = 0,
      SpritePath = Assets.CardEyeTrash,
      Spell = new DecreaseEnemyAtkSpell(0)
    };

    public static CardData Eye => new()
    {
      BuyCost = 2,
      SellCost = 1,
      SpritePath = Assets.CardEye,
      Spell = new DecreaseEnemyAtkSpell(1)
    };

    public static CardData EyeRare => new()
    {
      BuyCost = 4,
      SellCost = 2,
      SpritePath = Assets.CardEye,
      Spell = new DecreaseEnemyAtkSpell(4)
    };

    public static CardData Finger => new()
    {
      BuyCost = 2,
      SellCost = 1,
      SpritePath = Assets.CardFinger,
      Spell = new IncreaseAtkSpell(1)
    };

    public static CardData FingerTrash => new()
    {
      BuyCost = 1,
      SellCost = 0,
      SpritePath = Assets.CardFingerTrash,
      Spell = new IncreaseAtkSpell(0)
    };

    public static CardData FingerRare => new()
    {
      BuyCost = 4,
      SellCost = 2,
      SpritePath = Assets.CardFinger,
      Spell = new IncreaseAtkSpell(4)
    };

    public static CardData Cake => new()
    {
      BuyCost = 2,
      SellCost = 1,
      SpritePath = Assets.CardCake,
      Spell = new IncreaseHpSpell(2)
    };

    public static CardData CakeTrash => new()
    {
      BuyCost = 1,
      SellCost = 0,
      SpritePath = Assets.CardCakeTrash,
      Spell = new IncreaseHpSpell(0)
    };

    public static CardData CakeRare => new()
    {
      BuyCost = 4,
      SellCost = 2,
      SpritePath = Assets.CardCake,
      Spell = new IncreaseHpSpell(4)
    };

    public static CardData Skull => new()
    {
      BuyCost = 6,
      SellCost = 3,
      SpritePath = Assets.CardSkull,
      Spell = new DecreaseEnemyAtkSpell(9)
    };
    
    public static CardData Hand => new()
    {
      BuyCost = 6,
      SellCost = 3,
      SpritePath = Assets.CardHand,
      Spell = new IncreaseAtkSpell(9)
    };
  
    public static CardData FullCake => new()
    {
      BuyCost = 6,
      SellCost = 3,
      SpritePath = Assets.CardFullCake,
      Spell = new IncreaseHpSpell(9)
    };
  }
}