using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Battles;
using Game.Cards;
using Game.Infrastructure.Core;
using Game.Infrastructure.Data;
using TMPro;
using UnityEngine;
using Utils.Extensions;
using Zenject;

namespace Game.Shop
{
  public class ShopUI : ControllableMono<ShopUI>
  {
    [SerializeField]
    private CanvasGroup _canvas;

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

      EnableInteraction().Forget();
    }

    private void ShowHeroes()
    {
      _heroesContainer.SetActive(true);

      _heroes[0].SetUp(CombatantsList.CatHero);
      _heroes[1].SetUp(CombatantsList.ElfHero);
      _heroes[2].SetUp(CombatantsList.KnightHero);
    }

    private void ShowCards()
    {
      _cardsContainer.SetActive(true);

      List<CardData> cards = _data.Get<ShopData>().Cards();

      foreach (CardUI cardUI in _cards)
      {
        CardData card = cards.Random();
        cardUI.SetUp(card);
        cards.Remove(card);
      }
    }

    public void Select(CombatantData combatant)
    {
      Inventory.Clear();
      Arena.Combatants[CombatantType.Hero] = combatant;
      Arena.ResetQueue();
      _data.Get<ShopData>().ResetQueue();
      _data.Get<ProgressData>().Level = 0;
      _data.Get<ProgressData>().Run++;
      Souls.InWallet = combatant.Souls;
      _stateMachine.Enter<LoadShopState>();
    }

    public bool CanBuy(CardData card) =>
      Inventory.CanAdd() && Souls.InWallet >= card.BuyCost;

    public void Buy(CardData card)
    {
      Inventory.Add(card);
      Souls.InWallet -= card.BuyCost;
      UpdateView();
    }

    public void SellCard(CardData card)
    {
      Inventory.Remove(card);
      Souls.InWallet += card.SellCost;
      UpdateView();
    }

    private void UpdateView()
    {
      UpdateWalletUI();
      InventoryUI.UpdateView();

      foreach (CardUI cardUI in _cards)
        cardUI.UpdateCostView();
    }

    private void UpdateWalletUI() =>
      _wallet.text = Souls.InWallet.ToString();

    private async UniTask EnableInteraction()
    {
      _canvas.alpha = 0;
      await _canvas.DOFade(1, 0.3f).WithCancellation(_canvas.GetCancellationTokenOnDestroy());
      _canvas.interactable = true;
    }
  }
}