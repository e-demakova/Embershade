using Cysharp.Threading.Tasks;
using Game.Battles;
using Game.Dialogues;
using Utils.Localization;

namespace Game.Cards
{
  public class IncreaseAtkSpell : ICardSpell
  {
    private readonly int _value;

    public IncreaseAtkSpell(int value) =>
      _value = value;

    public string Description(LocalizationData localization) =>
      string.Format(localization.GetString(DescriptionsList.Atk), _value);

    public bool CanApply(CombatantData combatant) =>
      combatant.Is<MainHeroTag>(out _);

    public bool CanRevert(CombatantData combatant) =>
      combatant.Is<MainHeroTag>(out _);

    public async UniTask Apply(CombatantData combatant)
    {
      combatant.Stats.Atk += _value;
      await combatant.Instance.UpdateStats();
    }
    public void Revert(CombatantData combatant) =>
      combatant.Stats.Atk -= _value;
  }
}