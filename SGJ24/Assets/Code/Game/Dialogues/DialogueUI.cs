using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Battles;
using Game.Infrastructure.AssetsManagement;
using Game.Infrastructure.Data;
using Game.PlayerInput;
using UnityEngine;
using Utils.Localization;
using Zenject;

namespace Game.Dialogues
{
  public class DialogueUI : ControllableMono<DialogueUI>
  {
    [SerializeField]
    private DialogueReplicaUI _replica;

    [SerializeField]
    private DialogueReplicaUI _smileReplica;

    [SerializeField]
    private DialogueReplicaUI _centredReplica;

    [SerializeField]
    private CanvasGroup _dark;

    private IBuildersFactory _builders;
    private IInput _input;
    private IGameData _data;
    private bool _skip;

    [Inject]
    private void Construct(IInput input, IBuildersFactory builders, IGameData data)
    {
      _input = input;
      _builders = builders;
      _data = data;
    }

    public async UniTask ShowDialogue(List<LocalizedString> replicas) =>
      await Show(replicas, _replica);

    public async UniTask ShowSmileDialogue(List<LocalizedString> replicas) =>
      await Show(replicas, _smileReplica);

    public async UniTask HideBack() =>
      await _dark.DOFade(1, 0.1f).WithCancellation(_dark.GetCancellationTokenOnDestroy());

    public async UniTask ShowBack() =>
      await _dark.DOFade(0, 0.1f).WithCancellation(_dark.GetCancellationTokenOnDestroy());

    public async UniTask ShowCentredDialogue(List<LocalizedString> replicas) =>
      await Show(replicas, _centredReplica);

    public async UniTask SmileDialogue(List<LocalizedString> centered, List<LocalizedString> smile)
    {
      await UniTask.WhenAll(
        HideBack(),
        _data.Get<SceneData>().Get<MainCamera>().ZoomOut());

      foreach (CombatantData combatant in _data.Get<ArenaData>().Combatants.Values)
        combatant.Instance.gameObject.SetActive(false);

      if (centered != null)
        await ShowCentredDialogue(centered);

      _builders.FromResources(Assets.SupportAppear).Instantiate();

      await ShowBack();

      await UniTask.WaitForSeconds(1f);
      await ShowSmileDialogue(smile);
    }

    private async UniTask Show(List<LocalizedString> replicas, DialogueReplicaUI replicaUI)
    {
      if (GameSettings.SkipDialogues)
        return;

      foreach (LocalizedString replica in replicas)
      {
        await replicaUI.Show(replica);
        await WaitPlayerInput();
      }

      replicaUI.Hide();
    }

    private async UniTask WaitPlayerInput()
    {
      _skip = false;
      IDisposable subscriber = _input.OnAct.Up().Subscribe(() => _skip = true);
      await UniTask.WaitUntil(() => _skip);
      subscriber.Dispose();
    }
  }
}