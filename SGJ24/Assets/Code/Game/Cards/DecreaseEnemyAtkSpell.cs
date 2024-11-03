using Cysharp.Threading.Tasks;
using Game.Battles;

namespace Game.Cards
{
  public class DecreaseEnemyAtkSpell : ICardSpell
  {
    private readonly int _value;

    public DecreaseEnemyAtkSpell(int value) =>
      _value = value;

    public bool CanApply(CombatantData combatant) =>
      !combatant.Is<MainHeroTag>(out _);

    public bool CanRevert(CombatantData combatant) =>
      !combatant.Is<MainHeroTag>(out _);

    public async UniTask Apply(CombatantData combatant)
    {
      combatant.Stats.Atk -= _value;
      await combatant.Instance.UpdateStats();
    }

    public void Revert(CombatantData combatant) =>
      combatant.Stats.Atk -= _value;
  }
}