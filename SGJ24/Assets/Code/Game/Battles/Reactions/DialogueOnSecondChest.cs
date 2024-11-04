using Cysharp.Threading.Tasks;
using Game.Battles.Triggers;
using Game.Dialogues;
using Game.Infrastructure.Data;
using Zenject;

namespace Game.Battles.Reactions
{
  public class DialogueOnSecondChest : IReaction
  {
    private IGameData _data;
    private MainCamera MainCamera => _data.Get<SceneData>().Get<MainCamera>();

    [Inject]
    private void Construct(IGameData data)
    {
      _data = data;
    }

    public bool CanReact(ITrigger trigger, CombatantData owner) =>
      trigger is BattleStartedTrigger;

    public async UniTask React(ITrigger trigger, CombatantData owner)
    {
      if (_data.Get<ProgressData>().ChestMeet < 1)
      {
        _data.Get<ProgressData>().ChestMeet++;
        return;
      }
      
      await MainCamera.ZoomIn();
      await _data.Get<SceneData>().Get<DialogueUI>().ShowDialogue(DialoguesList.MeetChestSecondTime);
      await MainCamera.ZoomOut();
    }
  }
}