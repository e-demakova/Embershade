using System;
using Cysharp.Threading.Tasks;
using Game.Battles.Reactions;
using Game.Battles.Triggers;
using UnityEngine;
using Utils.SmartDebug;
using Zenject;

namespace Game.Battles
{
  public interface IReactionsInvoker
  {
    UniTask React(IReaction reaction, ITrigger trigger, CombatantData combatant);
  }

  public class ReactionsInvoker : IReactionsInvoker
  {
    private readonly DiContainer _container;

    public ReactionsInvoker(DiContainer container)
    {
      _container = container;
    }

    public async UniTask React(IReaction reaction, ITrigger trigger, CombatantData combatant)
    {
      try
      {
        _container.Inject(reaction);

        if (reaction.CanReact(trigger, combatant))
          await reaction.React(trigger, combatant);
      }
      catch (Exception exception)
      {
        Debug.LogError("Exception in reaction " + reaction.GetType().Name.White() + " " + exception);
      }
    }
  }
}