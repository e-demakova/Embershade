using System.Collections.Generic;
using Utils.Localization;

namespace Game.Dialogues
{
  public static class DialoguesList
  {
    public static readonly List<LocalizedString> First = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Here my journey starts." },
          new() { Language = Language.Ru, String = "Тут начинается мое приключение." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Only I can do that." },
          new() { Language = Language.Ru, String = "Только мне это по силам." }
        }
      }
    };
    
    public static readonly List<LocalizedString> FirstDeath = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "It's can't be the end." },
          new() { Language = Language.Ru, String = "Это не может быть концом." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Main character can't die so fast." },
          new() { Language = Language.Ru, String = "Главный герой не должен умирать так быстро." }
        }
      }
    };
    
    public static readonly List<LocalizedString> SmileFirst = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "You are absolutely right, hero!" },
          new() { Language = Language.Ru, String = "Ты абсолютно прав, герой!" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Why should such a valuable soul be wasted?" },
          new() { Language = Language.Ru, String = "За чем же такой ценной душе пропадать?" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Better exchange it with me!" },
          new() { Language = Language.Ru, String = "Лучше обменяй ее у меня!" }
        }
      }
    };
  }
}