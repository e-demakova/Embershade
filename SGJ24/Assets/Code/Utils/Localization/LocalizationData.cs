using System;
using System.Linq;
using Game.Infrastructure.Data;
using Utils.Observing.SubjectProperties;
using Utils.SmartDebug;

namespace Utils.Localization
{
  public enum Language
  {
    Eng = 0,
    Ru = 1,
  }

  public class LocalizationData : IData
  {
    private readonly SubjectProperty<Language> _language = new();
    public Language Language => _language.Value;

    public void SwitchLanguage(Language language) =>
      _language.Value = language;

    public IDisposable OnChange(Action action) =>
      _language.OnChange().Subscribe(action);

    public string GetString(LocalizedString localizedString)
    {
      if (localizedString == null)
      {
        LogError();
        return string.Empty;
      }
      
      LocalizedEntry entry = localizedString.Entries.FirstOrDefault(x => x.Language == Language);
      
      if (entry == null)
      {
        LogError();
        return string.Empty;
      }

      return entry?.String;
    }

    private void LogError() =>
      DLogger.Message(DSenders.Localization)
             .WithText(Language.ToString().White().Bold() + " localization not set fot string.")
             .WithFormat(DebugFormat.Exception)
             .Log();
  }
}