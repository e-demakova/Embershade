using Cysharp.Threading.Tasks;
using Game.Battles.Triggers;
using Game.Dialogues;
using Game.Infrastructure.Data;
using Zenject;

namespace Game.Battles.Reactions
{
  public class WinOnDeath : IReaction
  {
    private IGameData _data;
    private DialogueUI Dialogues => _data.Get<SceneData>().Get<DialogueUI>();

    [Inject]
    private void Construct(IGameData data) =>
      _data = data;

    public bool CanReact(ITrigger trigger, CombatantData owner) =>
      trigger is DeathTrigger death && death.Corpse == owner;

    public async UniTask React(ITrigger trigger, CombatantData owner)
    {
      _data.Get<ProgressData>().Win = true;
      await Dialogues.SmileDialogue(DialoguesList.DefeatChest, DialoguesList.Win);
    }
  }
}