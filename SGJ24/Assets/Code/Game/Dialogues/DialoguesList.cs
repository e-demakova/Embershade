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
          new() { Language = Language.Ru, String = "Только мне по силам всех спасти." }
        }
      }
    };

    public static readonly List<LocalizedString> Cat = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I can't them let down." },
          new() { Language = Language.Ru, String = "Я должна найти лекарство." }
        }
      }
    };

    public static readonly List<LocalizedString> CatDead = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I can't them let down." },
          new() { Language = Language.Ru, String = "Нет... Мне нужно лекарство!" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I can't them let down." },
          new() { Language = Language.Ru, String = "Моя мама... Она же умрет!" }
        }
      },
    };

    public static readonly List<LocalizedString> CatDeadSmile = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I can't them let down." },
          new() { Language = Language.Ru, String = "Лучше умереть, чем жить с такой дочерью как ты." }
        },
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I can't them let down." },
          new() { Language = Language.Ru, String = "Как ты могла забыть про мамин день рождения?" }
        },
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I can't them let down." },
          new() { Language = Language.Ru, String = "Может, она поэтому и заболела?" }
        },
      }
    };

    public static readonly List<LocalizedString> FirstDeath = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "It's can't be the end." },
          new() { Language = Language.Ru, String = "Это же не может быть концом?" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "It's can't be the end." },
          new() { Language = Language.Ru, String = "Кто-нибудь... Помогите..." }
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
    
    public static readonly List<LocalizedString> SecondDeath = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "It's can't be the end." },
          new() { Language = Language.Ru, String = "Снова смерть? Я не хочу..." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "It's can't be the end." },
          new() { Language = Language.Ru, String = "Мне нужен еще шанс! Я должен их спасти!" }
        }
      },
    };
    
    public static readonly List<LocalizedString> SecondSmile = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "It's can't be the end." },
          new() { Language = Language.Ru, String = "Не должен. Никакой опасности никогда не было." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "It's can't be the end." },
          new() { Language = Language.Ru, String = "Они соврали, что бы ты наконец ушел." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "It's can't be the end." },
          new() { Language = Language.Ru, String = "Похоже, ты лишь надоедливый герой второго плана." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "It's can't be the end." },
          new() { Language = Language.Ru, String = "А меня ждут другие заблудшие души." }
        }
      },
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
          new() { Language = Language.Ru, String = "За чем же такой ценной душе так скоро угасать?" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Better exchange it with me!" },
          new() { Language = Language.Ru, String = "Лучше продай ее мне!" }
        }
      }
    };

    public static readonly List<LocalizedString> SellTutor = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "If you haven't souls, you can sell items from your inventory." },
          new() { Language = Language.Ru, String = "Если тебе не хватает душ на покупку..." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "If you haven't souls, you can sell items from your inventory." },
          new() { Language = Language.Ru, String = "Ты можешь продать свои вещи из инвентаря!" }
        }
      },
    };
  }
}