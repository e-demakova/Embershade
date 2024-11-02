using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
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

    private IInput _input;
    private bool _skip;
    
    [Inject]
    private void Construct(IInput input)
    {
      _input = input;
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

    private async UniTask Show(List<LocalizedString> replicas, DialogueReplicaUI replicaUI)
    {
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