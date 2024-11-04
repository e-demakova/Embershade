using System.Collections.Generic;
using Game.Cards;
using Game.Infrastructure.Data;

namespace Game.Shop
{
  public class ShopData : IData
  {
    private readonly Queue<List<CardData>> _cardsQueue = new();

    public List<CardData> Cards()
    {
      if (_cardsQueue.Count == 0)
        ResetQueue();

      return _cardsQueue.Dequeue();
    }

    public void ResetQueue()
    {
      _cardsQueue.Clear();
      _cardsQueue.Enqueue(CardsList.Common);
      _cardsQueue.Enqueue(CardsList.Rare);
      _cardsQueue.Enqueue(CardsList.SmallTrash);
      _cardsQueue.Enqueue(CardsList.FullTrash);
      _cardsQueue.Enqueue(CardsList.Immortal);
      _cardsQueue.Enqueue(CardsList.FullTrash);
      _cardsQueue.Enqueue(CardsList.Trash);
      _cardsQueue.Enqueue(CardsList.Trash);
    }
  }
}