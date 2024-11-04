using System;
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

    public static List<CardData> SmallTrash => new()
    {
      EyeTrash,
      Finger,
      Cake
    };

    public static List<CardData> Trash => new()
    {
      EyeTrash,
      FingerTrash,
      CakeTrash,
      Eye,
      Finger,
      Cake
    };

    public static List<CardData> FullTrash => new()
    {
      Eye,
      FingerTrash,
      CakeTrash,
    };

    public static List<CardData> Rare => new()
    {
      EyeRare,
      FingerRare,
      CakeRare,
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
      Spell = new BrokenSpell(),
      Tags = new Dictionary<Type, ICardTag>
      {
        { typeof(Eye), new Eye() },
        { typeof(Broken), new Broken() },
      }
    };

    public static CardData Eye => new()
    {
      BuyCost = 2,
      SellCost = 1,
      SpritePath = Assets.CardEye,
      Spell = new DecreaseEnemyAtkSpell(1),
      Tags = new Dictionary<Type, ICardTag>
      {
        { typeof(Eye), new Eye() },
      }
    };

    public static CardData EyeRare => new()
    {
      BuyCost = 4,
      SellCost = 2,
      SpritePath = Assets.CardEye,
      Spell = new DecreaseEnemyAtkSpell(4),
      Tags = new Dictionary<Type, ICardTag>
      {
        { typeof(Eye), new Eye() },
      }
    };

    public static CardData Finger => new()
    {
      BuyCost = 2,
      SellCost = 1,
      SpritePath = Assets.CardFinger,
      Spell = new IncreaseAtkSpell(2),
      Tags = new Dictionary<Type, ICardTag>
      {
        { typeof(Finger), new Finger() },
      }
    };

    public static CardData FingerTrash => new()
    {
      BuyCost = 1,
      SellCost = 0,
      SpritePath = Assets.CardFingerTrash,
      Spell = new BrokenSpell(),
      Tags = new Dictionary<Type, ICardTag>
      {
        { typeof(Finger), new Finger() },
        { typeof(Broken), new Broken() },
      }
    };

    public static CardData FingerRare => new()
    {
      BuyCost = 3,
      SellCost = 2,
      SpritePath = Assets.CardFinger,
      Spell = new IncreaseAtkSpell(3),
      Tags = new Dictionary<Type, ICardTag>
      {
        { typeof(Finger), new Finger() },
      }
    };

    public static CardData Cake => new()
    {
      BuyCost = 2,
      SellCost = 1,
      SpritePath = Assets.CardCake,
      Spell = new IncreaseHpSpell(2),
      Tags = new Dictionary<Type, ICardTag>
      {
        { typeof(Cake), new Cake() },
      }
    };

    public static CardData CakeTrash => new()
    {
      BuyCost = 1,
      SellCost = 0,
      SpritePath = Assets.CardCakeTrash,
      Spell = new BrokenSpell(),
      Tags = new Dictionary<Type, ICardTag>
      {
        { typeof(Cake), new Cake() },
        { typeof(Broken), new Broken() },
      }
    };

    public static CardData CakeRare => new()
    {
      BuyCost = 3,
      SellCost = 2,
      SpritePath = Assets.CardCake,
      Spell = new IncreaseHpSpell(4),
      Tags = new Dictionary<Type, ICardTag>
      {
        { typeof(Cake), new Cake() },
      }
    };

    public static CardData Skull => new()
    {
      BuyCost = 6,
      SellCost = 3,
      SpritePath = Assets.CardSkull,
      Spell = new DecreaseEnemyAtkForEyeSpell(3)
    };

    public static CardData Hand => new()
    {
      BuyCost = 6,
      SellCost = 3,
      SpritePath = Assets.CardHand,
      Spell = new IncreaseAtkForFingerSpell(9)
    };

    public static CardData FullCake => new()
    {
      BuyCost = 6,
      SellCost = 3,
      SpritePath = Assets.CardFullCake,
      Spell = new IncreaseHpForCakeSpell(9)
    };
  }
}