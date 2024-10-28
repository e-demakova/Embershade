using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;
using Utils.Observing.UnityEvents;

namespace Utils.UI
{
  public abstract class SelectorHandler : MonoBehaviour 
  {
    private readonly List<IDisposable> _subscribers = new();

    [SerializeField]
    private Button _previous;

    [SerializeField]
    private Button _next;

    private void Awake()
    {
      _next.onClick.AsHandler().Subscribe(Next).AddTo(_subscribers);
      _previous.onClick.AsHandler().Subscribe(Previous).AddTo(_subscribers);
    }

    private void OnDestroy() =>
      _subscribers.DisposeAll();

    protected abstract void Next();
    protected abstract void Previous();
  }
}