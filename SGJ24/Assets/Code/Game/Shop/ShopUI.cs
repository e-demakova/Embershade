using System.Collections.Generic;
using Game.Battles;
using Game.Cards;
using Game.Infrastructure.Core;
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

    [Inject]
    private void Construct(IGameData data, IGameStateMachine stateMachine)
    {
      _data = data;
      _stateMachine = stateMachine;
    }

    private void Start()
    {
      UpdateWalletUI();

      if (Arena.Combatants[CombatantType.Hero].IsDead)
        ShowHeroes();
      else
        ShowCards();
    }

    private void ShowHeroes()
    {
      _heroesContainer.SetActive(true);
      
      foreach (HeroUI hero in _heroes)
        hero.SetUp(CombatantsList.FirstHero, this);
    }

    private void ShowCards()
    {
      _cardsContainer.SetActive(true);
      foreach (CardUI card in _cards)
        card.SetUp(CardsList.Test, this);
    }

    public void Select(CombatantData combatant)
    {
      Arena.Combatants[CombatantType.Hero] = combatant;
      _stateMachine.Enter<LoadArenaState>();
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