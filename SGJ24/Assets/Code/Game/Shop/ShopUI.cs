﻿using System.Collections.Generic;
using Game.Battles;
using Game.Cards;
using Game.Infrastructure.Core;
using Game.Infrastructure.Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Shop
{
  public class ShopUI : ControllableMono<ShopUI>
  {
    [SerializeField]
    private TextMeshProUGUI _wallet;

    [SerializeField]
    private GameObject _heroesContainer;

    [SerializeField]
    private GameObject _cardsContainer;

    [SerializeField]
    private List<CardUI> _cards;

    [SerializeField]
    private List<HeroUI> _heroes;

    private IGameData _data;
    private IGameStateMachine _stateMachine;

    private SoulsData Souls => _data.Get<SoulsData>();
    private ArenaData Arena => _data.Get<ArenaData>();
    private InventoryUI InventoryUI => _data.Get<SceneData>().Get<InventoryUI>();
    private InventoryData Inventory => _data.Get<InventoryData>();

    [Inject]
    private void Construct(IGameData data, IGameStateMachine stateMachine)
    {
      _data = data;
      _stateMachine = stateMachine;
    }

    protected override void Start()
    {
      base.Start();
      UpdateWalletUI();

      if (Arena.Combatants[CombatantType.Hero].IsDead)
        ShowHeroes();
      else
        ShowCards();
    }

    private void ShowHeroes()
    {
      _heroesContainer.SetActive(true);

      _heroes[0].SetUp(CombatantsList.CatHero, this);
      _heroes[1].SetUp(CombatantsList.ElfHero, this);
      _heroes[2].SetUp(CombatantsList.KnightHero, this);
    }

    private void ShowCards()
    {
      _cardsContainer.SetActive(true);

      _cards[0].SetUp(CardsList.Hand, this);
      _cards[1].SetUp(CardsList.Heart, this);
      _cards[2].SetUp(CardsList.Knife, this);
    }

    public void Select(CombatantData combatant)
    {
      Inventory.Clear();
      Arena.Combatants[CombatantType.Hero] = combatant;
      Arena.ResetQueue();
      Souls.InWallet = combatant.Souls;
      _stateMachine.Enter<LoadShopState>();
    }

    public bool CanBuy(CardData card) =>
      Inventory.CanAdd() && Souls.InWallet >= card.BuyCost;

    public void Buy(CardData card)
    {
      Souls.InWallet -= card.BuyCost;
      UpdateWalletUI();
      Inventory.Add(card);
      InventoryUI.UpdateView();

      foreach (CardUI cardUI in _cards)
        cardUI.UpdateCostView();
    }

    public void SellCard(CardData card)
    {
      Souls.InWallet += card.SellCost;
      Inventory.Remove(card);
      UpdateWalletUI();
      InventoryUI.UpdateView();
    }

    private void UpdateWalletUI() =>
      _wallet.text = Souls.InWallet.ToString();
  }
}