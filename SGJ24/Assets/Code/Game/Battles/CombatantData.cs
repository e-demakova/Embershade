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
    public int Souls = 1;

    public string SpritePath;
    public LocalizedString Description = DescriptionsList.Default;

    public List<IReaction> Reactions;
    public Dictionary<Type, ICombatantTag> Tags = new();

    public bool IsDead => Stats.Hp <= 0;

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