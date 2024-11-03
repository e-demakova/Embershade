using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Battles.Triggers;
using Game.Dialogues;
using Game.Infrastructure.Data;
using Utils.Localization;
using Zenject;

namespace Game.Battles.Reactions
{
  public class SmileDialogueOnDeath : IReaction
  {
    private readonly List<LocalizedString> _centered;
    private readonly List<LocalizedString> _smile;

    private int _availableExecutions = 1;

    private IGameData _data;
    private DialogueUI Dialogues => _data.Get<SceneData>().Get<DialogueUI>();

   public SmileDialogueOnDeath(List<LocalizedString> centered, List<LocalizedString> smile)
   {
     _centered = centered;
     _smile = smile;
   }
    
    [Inject]
    private void Construct(IGameData data)
    {
      _data = data;
    }

    public bool CanReact(ITrigger trigger, CombatantData owner) =>
      _availableExecutions > 0 && trigger is DeathTrigger death && death.Corpse == owner;

    public async UniTask React(ITrigger trigger, CombatantData owner)
    {
      _availableExecutions--;
      await Dialogues.SmileDialogue(_centered, _smile);
    }
  }
}