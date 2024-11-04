using Cysharp.Threading.Tasks;
using Game.Battles;
using Game.Dialogues;
using Utils.Localization;

namespace Game.Cards
{
  public class BrokenSpell : ICardSpell
  {
    public string Description(LocalizationData localization) =>
      string.Format(localization.GetString(DescriptionsList.Broken));

    public bool CanApply(CombatantData combatant) =>
      true;

    public bool CanRevert(CombatantData combatant) =>
      false;

    public async UniTask Apply(CombatantData combatant) { }

    public void Revert(CombatantData combatant) { }
  }
}