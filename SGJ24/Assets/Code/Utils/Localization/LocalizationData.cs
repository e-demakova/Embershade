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
      LocalizedEntry entry = localizedString.Entries.FirstOrDefault(x => x.Language == Language);
      if (entry == null)
      {
        DLogger.Message(DSenders.Localization)
               .WithText(Language.ToString().White().Bold() + " localization not set fot string with id " + localizedString.Id.White().Bold())
               .WithFormat(DebugFormat.Exception)
               .Log();

        return string.Empty;
      }

      return entry?.String;
    }
  }
}