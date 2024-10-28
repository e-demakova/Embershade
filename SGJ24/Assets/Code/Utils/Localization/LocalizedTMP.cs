using System;
using System.Collections.Generic;
using Game.Infrastructure.Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace Utils.Localization
{
  [Serializable]
  public class LocalizedEntry
  {
    public Language Language;
    public string String;
  }

  [Serializable]
  public class LocalizedString
  {
    public string Id;
    public List<LocalizedEntry> Entries;
  }
  
  [RequireComponent(typeof(TextMeshProUGUI))]
  public class LocalizedTMP : MonoBehaviour
  {
    private IGameData _data;
    private LocalizationData Localization => _data.Get<LocalizationData>();
    
    [SerializeField]
    private LocalizedString _localizedString;

    private TextMeshProUGUI _text;
    private IDisposable _subscriber;

    [Inject]
    private void Construct(IGameData data) =>
      _data = data;

    private void Start()
    {
      _text = GetComponent<TextMeshProUGUI>();
      _text.text = Localization.GetString(_localizedString);
      _subscriber = Localization.OnChange(UpdateText);
    }

    private void OnDestroy() =>
      _subscriber?.Dispose();

    private void UpdateText() =>
      _text.text = Localization.GetString(_localizedString);
  }
}