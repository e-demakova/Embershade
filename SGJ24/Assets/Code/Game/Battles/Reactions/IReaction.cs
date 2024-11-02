using Cysharp.Threading.Tasks;
using Game.Battles.Triggers;

namespace Game.Battles.Reactions
{
  public interface IReaction
  {
    bool CanReact(ITrigger trigger, CombatantData owner);
    UniTask React(ITrigger trigger, CombatantData owner);
  }
}