using UnityEngine;
using Zenject;

namespace Game.Audio
{
  public class AmbianceSource : MonoBehaviour
  {
    [SerializeField]
    private AudioClip _clip;

    [SerializeField]
    private bool _playOnStart = true;

    private IAudioPlayer _audio;

    [Inject]
    private void Construct(IAudioPlayer audio) =>
      _audio = audio;

    private void Start()
    {
      if (_playOnStart)
        Play();
    }

    public void Play() =>
      _audio.PlayAmbience(_clip);
  }
}