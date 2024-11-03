using System.Collections.Generic;
using Game.Battles;
using Game.Infrastructure.Data;
using Game.Shop;
using UnityEngine;
using Zenject;

namespace Game.Cards
{
  public class InventoryUI : ControllableMono<InventoryUI>
  {
    [SerializeField]
    private CanvasGroup _canvasGroup;
    
    [SerializeField]
    private List<InventorySlotUI> _slots;

    private IGameData _data;

    public List<InventorySlotUI> Slots => _slots;

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
      if (!_data.Get<ArenaData>().SupportArrived && cards.Count == 0)
      {
        Hide();
        return;
      }

      _canvasGroup.alpha = 1;
      
      for (int i = 0; i < cards.Count; i++)
        Slots[i].SetUp(cards[i]);

      for (int i = cards.Count; i < Slots.Count; i++)
        Slots[i].Clear();
    }

    public void Show() =>
      UpdateView();

    public void Hide() =>
      _canvasGroup.alpha = 0;
  }
}