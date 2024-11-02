using System.Collections.Generic;
using Game.Cards;
using Game.Infrastructure.Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Shop
{
  public class ShopUI : MonoBehaviour
  {
    [SerializeField]
    private TextMeshProUGUI _wallet;

    [SerializeField]
    private List<CardUI> _cards;

    private IGameData _data;

    private SoulsData Souls => _data.Get<SoulsData>();

    [Inject]
    private void Construct(IGameData data) =>
      _data = data;

    private void Start()
    {
      UpdateWalletUI();
      
      foreach (CardUI card in _cards) 
        card.SetUp(CardsList.Test, this);
    }

    public bool CanBuy(CardData card) =>
      Souls.InWallet >= card.Cost;

    public void Buy(CardData card)
    {
      Souls.InWallet -= card.Cost;
      UpdateWalletUI();
    }

    private void UpdateWalletUI() =>
      _wallet.text = Souls.InWallet.ToString();
  }
}