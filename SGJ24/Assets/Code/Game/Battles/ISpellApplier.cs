using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Game.Cards;
using Game.Infrastructure.Data;
using UnityEngine;
using Zenject;

namespace Game.Battles
{
  public interface ISpellApplier
  {
    UniTask ApplySpell(ICardSpell spell);
    void RevertSpell(ICardSpell spell);
  }

  public class SpellApplier : ISpellApplier
  {
    private readonly DiContainer _container;
    private readonly IGameData _data;

    public SpellApplier(DiContainer container, IGameData data)
    {
      _container = container;
      _data = data;
    }

    public async UniTask ApplySpell(ICardSpell spell)
    {
      try
      {
        _container.Inject(spell);
        
        foreach (CombatantData combatant in Combatants.Where(spell.CanApply)) 
          await spell.Apply(combatant);
      }
      catch (Exception e)
      {
        Debug.LogException(e);
      }
    }

    private Dictionary<CombatantType, CombatantData>.ValueCollection Combatants => _data.Get<ArenaData>().Combatants.Values;

    public void RevertSpell(ICardSpell spell)
    {
      try
      {
        _container.Inject(spell);
        
        foreach (CombatantData combatant in Combatants.Where(spell.CanRevert)) 
          spell.Revert(combatant);
      }
      catch (Exception e)
      {
        Debug.LogException(e);
      }
    }
  }
}