using Cysharp.Threading.Tasks;
using Game.Battles.Triggers;
using Game.Dialogues;
using Game.Infrastructure.AssetsManagement;
using Game.Infrastructure.Data;
using Zenject;

namespace Game.Battles.Reactions
{
  public class SummonOnDeath : IReaction
  {
    private int _availableExecutions = 1;

    private IGameData _data;
    private IBuildersFactory _builders;
    private ArenaData ArenaData => _data.Get<ArenaData>();
    private DialogueUI Dialogues => _data.Get<SceneData>().Get<DialogueUI>();

    [Inject]
    private void Construct(IGameData data, IBuildersFactory builders)
    {
      _data = data;
      _builders = builders;
    }

    public bool CanReact(ITrigger trigger, CombatantData owner) =>
      _availableExecutions > 0 && trigger is DeathTrigger death && death.Corpse == owner;

    public async UniTask React(ITrigger trigger, CombatantData owner)
    {
      _availableExecutions--;

      await Dialogues.HideBack();
      
      _data.Get<SceneData>().Get<MainCamera>().ZoomOut().Forget();
      
      ArenaData.SupportArrived = true;
      
      foreach (CombatantData combatant in _data.Get<ArenaData>().Combatants.Values) 
        combatant.Instance.gameObject.SetActive(false);
      
      await Dialogues.ShowCentredDialogue(DialoguesList.FirstDeath);
      
      _builders.FromResources(Assets.SupportAppear).Instantiate();
      
      await Dialogues.ShowBack();
      
      await UniTask.WaitForSeconds(1f);
      await _data.Get<SceneData>().Get<DialogueUI>().ShowSmileDialogue(DialoguesList.SmileFirst);
    }
  }
}