using System;
using System.Collections.Generic;
using Game.Cards;
using Game.Infrastructure.Data;

namespace Game.Shop
{
  public class CardData : IData
  {
    public int BuyCost;
    public int SellCost;

    public string SpritePath;
    public ICardSpell Spell;

    public Dictionary<Type, ICardTag> Tags = new();

    public bool Is<T>(out T tag) where T : class, ICardTag
    {
      Tags.TryGetValue(typeof(T), out ICardTag value);
      tag = value as T;
      return tag != null;
    }
  }
}