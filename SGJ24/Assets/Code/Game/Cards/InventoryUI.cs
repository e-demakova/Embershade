using System.Collections.Generic;
using Game.Infrastructure.Data;
using Game.Shop;
using UnityEngine;
using Zenject;

namespace Game.Cards
{
  public class InventoryUI : ControllableMono<InventoryUI>
  {
    [SerializeField]
    private List<InventorySlotUI> _slots;

    private IGameData _data;

    [Inject]
    private void Construct(IGameData data)
    {
      _data = data;
    }

    protected override void Start()
    {
      base.Start();
      UpdateView();
    }

    public void UpdateView()
    {
      List<CardData> cards = _data.Get<InventoryData>().Cards;
      if (cards.Count == 0)
      {
        Hide();
        return;
      }

      gameObject.SetActive(true);

      for (int i = 0; i < cards.Count; i++)
        _slots[i].SetUp(cards[i]);

      for (int i = cards.Count; i < _slots.Count; i++)
        _slots[i].Clear();
    }

    public void Show() =>
      UpdateView();

    public void Hide() =>
      gameObject.SetActive(false);
  }
}