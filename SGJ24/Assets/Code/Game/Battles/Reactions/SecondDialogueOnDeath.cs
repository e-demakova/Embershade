using Cysharp.Threading.Tasks;
using Game.Battles.Triggers;
using Game.Dialogues;
using Game.Infrastructure.Data;
using Zenject;

namespace Game.Battles.Reactions
{
  public class SecondDialogueOnDeath : IReaction
  {
    private int _availableExecutions = 1;

    private IGameData _data;
    private DialogueUI Dialogues => _data.Get<SceneData>().Get<DialogueUI>();

    [Inject]
    private void Construct(IGameData data)
    {
      _data = data;
    }

    public bool CanReact(ITrigger trigger, CombatantData owner) =>
      _data.Get<ArenaData>().SupportArrived &&
      _availableExecutions > 0 &&
      trigger is DeathTrigger death && death.Corpse == owner;

    public async UniTask React(ITrigger trigger, CombatantData owner)
    {
      _availableExecutions--;
      await Dialogues.SmileDialogue(DialoguesList.SecondDeath, DialoguesList.SecondSmile);
    }
  }
}