using Game.Infrastructure.AssetsManagement;
using UnityEngine;

namespace Game.Audio
{
  public interface IAudioPlayer
  {
    void PlayAmbience(AudioClip clip);
  }

  public class AudioPlayer : IAudioPlayer
  {
    private const string AmbienceName = "ambience-source";

    private readonly IBuildersFactory _factory;

    private AudioSource _ambience;

    private AudioSource Ambience =>
      _ambience ??= CreateAmbience();

    public AudioPlayer(IBuildersFactory factory) =>
      _factory = factory;

    public void PlayAmbience(AudioClip clip)
    {
      Ambience.Stop();
      Ambience.clip = clip;
      Ambience.Play();
    }

    private AudioSource CreateAmbience()
    {
      AudioSource source =
        _factory.New(AmbienceName)
                .With<AudioSource>()
                .With<AudioVolumeActualizer>()
                .DontDestroy()
                .Instantiate<AudioSource>();

      source.playOnAwake = false;
      return source;
    }
  }
}