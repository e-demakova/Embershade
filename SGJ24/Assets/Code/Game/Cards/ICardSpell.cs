using Cysharp.Threading.Tasks;
using Game.Battles;

namespace Game.Cards
{
  public interface ICardSpell
  {
    bool CanApply(CombatantData combatant);
    bool CanRevert(CombatantData combatant);
    UniTask Apply(CombatantData combatant);
    void Revert(CombatantData combatant);
  }
}