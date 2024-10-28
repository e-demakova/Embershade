using System;
using UnityEngine;
using UnityEngine.UI;
using Utils.Observing.UnityEvents;

namespace Utils.UI
{
  public abstract class ButtonHandler : MonoBehaviour
  {
    [SerializeField]
    private Button _button;

    private IDisposable _subscriber;

    protected Button Button => _button;

    private void Awake() =>
      _subscriber = _button.OnClick(OnClick);

    private void OnDestroy()
    {
      _subscriber.Dispose();
      CustomOnDestroy();
    }

    protected virtual void CustomOnDestroy() { }

    protected abstract void OnClick();
  }
}