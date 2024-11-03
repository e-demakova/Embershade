using Cysharp.Threading.Tasks;
using Game.Battles.Triggers;
using Game.Dialogues;
using Game.Infrastructure.Data;
using Zenject;

namespace Game.Battles.Reactions
{
  public class SellTutorSmileDialogue : IReaction
  {
    private IGameData _data;
    private DialogueUI Dialogues => _data.Get<SceneData>().Get<DialogueUI>();

    [Inject]
    private void Construct(IGameData data)
    {
      _data = data;
    }

    public bool CanReact(ITrigger trigger, CombatantData owner) =>
      _data.Get<ProgressData>().Level == 1 && trigger is DeathTrigger death && death.Killer == owner;

    public async UniTask React(ITrigger trigger, CombatantData owner) =>
      await Dialogues.SmileDialogue(null, DialoguesList.SellTutor);
  }
}