using Game.Infrastructure.AssetsManagement;
using UnityEngine;

namespace Game.Audio
{
  public interface IAudioPlayer
  {
    void PlayAmbience(AudioClip clip);
    void PlaySound(AudioClip sound);
  }

  public class AudioPlayer : IAudioPlayer
  {
    private const string AmbienceName = "ambience-source";
    private const string SoundName = "sound-source";

    private readonly IBuildersFactory _factory;

    private AudioSource _ambience;
    private AudioSource Ambience =>
      _ambience ??= CreateSource(true, AmbienceName);

    private AudioSource _sound;
    private AudioSource Sound =>
      _sound ??= CreateSource(false, SoundName);

    public AudioPlayer(IBuildersFactory factory) =>
      _factory = factory;

    public void PlayAmbience(AudioClip clip)
    {
      Ambience.Stop();
      Ambience.clip = clip;
      Ambience.Play();
    }

    public void PlaySound(AudioClip sound)
    {
      Sound.Stop();
      Sound.clip = sound;
      Sound.Play();
    }

    private AudioSource CreateSource(bool loop, string name)
    {
      AudioSource source =
        _factory.New(name)
                .With<AudioSource>()
                .With<AudioVolumeActualizer>()
                .DontDestroy()
                .Instantiate<AudioSource>();

      source.playOnAwake = false;
      source.loop = loop;
      return source;
    }
  }
}