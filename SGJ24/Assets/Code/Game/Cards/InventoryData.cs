using System.Collections.Generic;
using Game.Infrastructure.Data;
using Game.Shop;

namespace Game.Cards
{
  public class InventoryData : IData
  {
    private const int MaxSlots = 6;
    public readonly List<CardData> Cards = new();

    public bool CanAdd() =>
      Cards.Count < MaxSlots;

    public void Add(CardData data) =>
      Cards.Add(data);
    
    public void Remove(CardData data) =>
      Cards.Remove(data);

    public void Clear() =>
      Cards.Clear();
  }
}