using System.Linq;
using Cysharp.Threading.Tasks;
using Game.Battles;
using Game.Dialogues;
using Game.Infrastructure.Data;
using Game.Shop;
using Utils.Localization;
using Zenject;

namespace Game.Cards
{
  public class IncreaseHpForCakeSpell : ICardSpell
  {
    private readonly int _value;

    private IGameData _data;

    private int Value => _data.Get<InventoryData>().Cards.Count(x => x.Is<Broken>(out _) && x.Is<Cake>(out _)) * _value;

    public IncreaseHpForCakeSpell(int value) =>
      _value = value;

    [Inject]
    private void Construct(IGameData data)
    {
      _data = data;
    }

    public string Description(LocalizationData localization) =>
      string.Format(localization.GetString(DescriptionsList.HpForEveryBroken), _value);

    public bool CanApply(CombatantData combatant) =>
      combatant.Is<MainHeroTag>(out _);

    public bool CanRevert(CombatantData combatant) =>
      false;

    public async UniTask Apply(CombatantData combatant)
    {
      combatant.Stats.Hp += Value;
      await combatant.Instance.UpdateStats();
    }

    public void Revert(CombatantData combatant) { }
  }
}