using System;
using Game.Infrastructure.Data;
using Utils.UI;
using Zenject;

namespace Utils.Localization
{
  public class LanguageSelector : SelectorHandler
  {
    private IGameData _data;
    private LocalizationData Localization => _data.Get<LocalizationData>();
    private int CurrentLocale => (int) Localization.Language;
    private int LocalesCount => Enum.GetValues(typeof(Language)).Length;

    [Inject]
    private void Construct(IGameData data) =>
      _data = data;

    protected override void Next()
    {
      int index = (CurrentLocale + 1) % LocalesCount;
      SetLocale(index);
    }

    protected override void Previous()
    {
      int index = CurrentLocale == 0 ? LocalesCount : CurrentLocale;
      SetLocale(index - 1);
    }

    private void SetLocale(int index) =>
      Localization.SwitchLanguage((Language) index);
  }
}