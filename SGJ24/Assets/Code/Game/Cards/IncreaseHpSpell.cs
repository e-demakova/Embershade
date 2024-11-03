using Cysharp.Threading.Tasks;
using Game.Battles;
using Game.Dialogues;
using Utils.Localization;

namespace Game.Cards
{
  public class IncreaseHpSpell : ICardSpell
  {
    private readonly int _value;

    public IncreaseHpSpell(int value) =>
      _value = value;

    public string Description(LocalizationData localization) =>
      string.Format(localization.GetString(DescriptionsList.Hp), _value);

    public bool CanApply(CombatantData combatant) =>
      combatant.Is<MainHeroTag>(out _);

    public bool CanRevert(CombatantData combatant) =>
      false;

    public async UniTask Apply(CombatantData combatant)
    {
      combatant.Stats.Hp += _value;
      await combatant.Instance.UpdateStats();
    }

    public void Revert(CombatantData combatant) { }
  }
}