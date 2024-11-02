using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
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
    
    private IInput _input;
    private bool _skip;

    [Inject]
    private void Construct(IInput input)
    {
      _input = input;
    }

    public async UniTask ShowDialogue(List<LocalizedString> replicas)
    {
      foreach (LocalizedString replica in replicas)
      {
        await _replica.Show(replica);
        await WaitPlayerInput();
      }

      _replica.Hide();
    }

    private async UniTask WaitPlayerInput()
    {
      _skip = false;
      IDisposable subscriber = _input.OnAct.Down().Subscribe(() => _skip = true);
      await UniTask.WaitUntil(() => _skip);
      subscriber.Dispose();
    }
  }
}