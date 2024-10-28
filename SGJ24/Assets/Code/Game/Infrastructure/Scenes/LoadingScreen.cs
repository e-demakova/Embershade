using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Game.Infrastructure.Scenes
{
  public class LoadingScreen : MonoBehaviour
  {
    [SerializeField]
    private CanvasGroup _canvas;

    private void Start() =>
      DontDestroyOnLoad(gameObject);

    public async UniTask Appear() =>
      await _canvas.DOFade(1, Durations.LoadingScreen)
                   .WithCancellation(this.GetCancellationTokenOnDestroy());

    public async UniTask Fade() =>
      await _canvas.DOFade(0, Durations.LoadingScreen)
                   .WithCancellation(this.GetCancellationTokenOnDestroy());
  }
}