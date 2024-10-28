using System;
using Game.Infrastructure.Data;
using UnityEngine;
using Zenject;

namespace Game.Audio
{
  public class AudioVolumeActualizer : MonoBehaviour
  {
    private IGameData _data;
    private IDisposable _subscriber;
    private AudioSource _source;
    private AudioData Data => _data.Get<AudioData>();

    [Inject]
    private void Construct(IGameData data) =>
      _data = data;

    private void Start()
    {
      _source = GetComponent<AudioSource>();
      _subscriber = Data.AudioVolume.OnChange().Subscribe(UpdateVolume);
      UpdateVolume();
    }

    private void OnDestroy() =>
      _subscriber?.Dispose();

    private void UpdateVolume() =>
      _source.volume = Data.AudioVolume.Value;
  }
}