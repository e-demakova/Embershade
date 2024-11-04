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
  public class IncreaseAtkForFingerSpell : ICardSpell
  {
    private readonly int _value;
    
    private IGameData _data;
    
    private int Value => _data.Get<InventoryData>().Cards.Count(x => x.Is<Broken>(out _) && x.Is<Finger>(out _)) * _value;
    
    public IncreaseAtkForFingerSpell(int value) =>
      _value = value;

    [Inject]
    private void Construct(IGameData data)
    {
      _data = data;
    }

    public string Description(LocalizationData localization) =>
      string.Format(localization.GetString(DescriptionsList.AtkForEveryBroken), _value);

    public bool CanApply(CombatantData combatant) =>
      combatant.Is<MainHeroTag>(out _);

    public bool CanRevert(CombatantData combatant) =>
      combatant.Is<MainHeroTag>(out _);

    public async UniTask Apply(CombatantData combatant)
    {
      combatant.Stats.Atk += Value;
      await combatant.Instance.UpdateStats();
    }

    public void Revert(CombatantData combatant) =>
      combatant.Stats.Atk -= Value;
  }
}