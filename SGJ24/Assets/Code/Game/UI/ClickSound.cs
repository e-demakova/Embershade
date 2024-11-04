using Game.Audio;
using Game.Infrastructure.AssetsManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.UI
{
  public class ClickSound : MonoBehaviour, IPointerDownHandler
  {
    [SerializeField]
    private AudioClip _sound;

    private IAudioPlayer _audio;
    private IAssetProvider _assets;

    [Inject]
    private void Construct(IAudioPlayer audio, IAssetProvider assets)
    {
      _audio = audio;
      _assets = assets;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      _sound ??= _assets.LoadAsset<AudioClip>(Assets.ClickSound);
      _audio.PlaySound(_sound);
    }
  }
}