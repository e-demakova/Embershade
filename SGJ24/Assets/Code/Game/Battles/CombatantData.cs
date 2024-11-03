using System;
using System.Collections.Generic;
using Game.Battles.Reactions;
using Game.Dialogues;
using Game.Infrastructure.Data;
using Utils.Localization;

namespace Game.Battles
{
  public class CombatantData : IData
  {
    public CombatantView Instance;
    public CombatantStats Stats;
    public List<IReaction> Reactions;
    public Dictionary<Type, ICombatantTag> Tags;
    public string SpritePath;
    public LocalizedString Description = DescriptionsList.Default;
    
    public bool IsDead => Stats.Hp.Value <= 0;

    public bool TargetMatch(CombatantData target) =>
      target != this;

    public bool Is<T>(out T tag) where T : class, ICombatantTag
    {
      Tags.TryGetValue(typeof(T), out ICombatantTag value);
      tag = value as T;
      return tag != null;
    }
  }
}