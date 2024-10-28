using System;
using Game.Infrastructure.Data;
using UnityEngine;
using UnityEngine.UI;
using Utils.Observing.UnityEvents;
using Zenject;

namespace Game.Audio
{
  public class AudioSlider : MonoBehaviour
  {
    [SerializeField]
    private Slider _slider;

    private IGameData _data;
    private IDisposable _subscriber;

    private AudioData Data => _data.Get<AudioData>();

    [Inject]
    private void Construct(IGameData data) =>
      _data = data;

    private void Start()
    {
      _slider.value = Data.AudioVolume.Value;
      _subscriber = _slider.onValueChanged.AsHandler().Subscribe(UpdateAudioVolume);
    }

    private void OnDestroy() =>
      _subscriber?.Dispose();

    private void UpdateAudioVolume(float value) =>
      Data.AudioVolume.Value = value;
  }
}