using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Infrastructure.Data;
using TMPro;
using UnityEngine;
using Utils.Localization;
using Zenject;

namespace Game.Dialogues
{
  public class DialogueReplicaUI : MonoBehaviour
  {
    [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private float _duration = 0.3f;

    [SerializeField]
    private float _shakeDuration = 0.1f;

    private IGameData _data;

    private LocalizationData Localization => _data.Get<LocalizationData>();

    [Inject]
    private void Construct(IGameData data) =>
      _data = data;

    public async UniTask Show(LocalizedString replica)
    {
      _text.text = Localization.GetString(replica);
      _canvasGroup.alpha = 0;

      await DOTween.Sequence()
                   .Join(_canvasGroup.DOFade(1, _duration))
                   .Join(transform.DOShakePosition(_shakeDuration, new Vector3(10f, 5f, 0f)))
                   .WithCancellation(this.GetCancellationTokenOnDestroy());
    }

    public void Hide() =>
      _canvasGroup.alpha = 0;
  }
}