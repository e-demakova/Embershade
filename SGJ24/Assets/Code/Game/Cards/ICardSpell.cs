using Cysharp.Threading.Tasks;
using Game.Battles;
using Utils.Localization;

namespace Game.Cards
{
  public interface ICardSpell
  {
    string Description(LocalizationData localization);
    bool CanApply(CombatantData combatant);
    bool CanRevert(CombatantData combatant);
    UniTask Apply(CombatantData combatant);
    void Revert(CombatantData combatant);
  }
}