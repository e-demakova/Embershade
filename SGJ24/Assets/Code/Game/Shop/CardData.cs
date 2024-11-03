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
  }
}