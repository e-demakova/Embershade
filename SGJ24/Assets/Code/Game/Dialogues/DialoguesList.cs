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
          new() { Language = Language.Eng, String = "This is where my journey begins." },
          new() { Language = Language.Ru, String = "Здесь начинается мое путешествие." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Only I can save them all." },
          new() { Language = Language.Ru, String = "Только мне по силам всех спасти." }
        }
      }
    };

    public static readonly List<LocalizedString> Knight = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Gold! Gold!" },
          new() { Language = Language.Ru, String = "Золото! Золото!" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I'd devour my own mother for a couple of coins!" },
          new() { Language = Language.Ru, String = "Я сожру родную мать за пару золотых!" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "And I'd devour you even easier." },
          new() { Language = Language.Ru, String = "А тебя и подавно сожру." }
        }
      },
    };
    
    public static readonly List<LocalizedString> KnightDead = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Bring me back!" },
          new() { Language = Language.Ru, String = "Воскреси меня!" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "My sons! They don’t deserve to grow up without a father." },
          new() { Language = Language.Ru, String = "Мои сыновья! Они не заслуживают расти без отца!" }
        }
      },
    };
    
    public static readonly List<LocalizedString> KnightSmile = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "They don't deserve to grow up with a father like you." },
          new() { Language = Language.Ru, String = "Они не заслуживают расти с таким отцом как ты." }
        }
      },
    };
    
    public static readonly List<LocalizedString> Elf = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I will prove my strength." },
          new() { Language = Language.Ru, String = "Я докажу свою силу." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "No one will dare laugh at me again." },
          new() { Language = Language.Ru, String = "Больше никто не посмеет смеяться надо мной." }
        }
      },
    };
    
    public static readonly List<LocalizedString> ElfDead = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "What a disgrace... How could I lose?" },
          new() { Language = Language.Ru, String = "Какой позор... Как я мог проиграть?" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "All that training wasted?" },
          new() { Language = Language.Ru, String = "Столько тренировок впустую?" }
        }
      },
    };
    
    public static readonly List<LocalizedString> ElfSmile = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Training won’t help the talentless." },
          new() { Language = Language.Ru, String = "Бездарности тренировки не помогут." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Better to invest in what you’re actually good at." },
          new() { Language = Language.Ru, String = "Лучше бы вложился в свои настоящие таланты." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Like drinking and loafing." },
          new() { Language = Language.Ru, String = "В тунеядство и пьянство." }
        }
      },
    };

    public static readonly List<LocalizedString> Cat = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I must find the medicine." },
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
          new() { Language = Language.Eng, String = "No... I need the medicine!" },
          new() { Language = Language.Ru, String = "Нет... Мне нужно лекарство!" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "My mother... She will die!" },
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
          new() { Language = Language.Eng, String = "Better to die than to live with a daughter like you." },
          new() { Language = Language.Ru, String = "Лучше умереть, чем жить с такой дочерью, как ты." }
        },
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "How could you forget your mother's birthday?" },
          new() { Language = Language.Ru, String = "Как ты могла забыть про мамин день рождения?" }
        },
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Maybe that’s why she got sick?" },
          new() { Language = Language.Ru, String = "Может она поэтому и заболела?" }
        },
      }
    };

    public static readonly List<LocalizedString> FirstDeath = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "This can't be the end." },
          new() { Language = Language.Ru, String = "Это же не конец?" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Somebody... Help me..." },
          new() { Language = Language.Ru, String = "Кто-нибудь... Помогите..." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "The hero shouldn't die so quickly." },
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
          new() { Language = Language.Eng, String = "Another death? I don’t want this..." },
          new() { Language = Language.Ru, String = "Снова смерть? Я не хочу..." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I need another chance! I must save them!" },
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
          new() { Language = Language.Eng, String = "No need. There was never any real danger." },
          new() { Language = Language.Ru, String = "Не должен. Никакой опасности никогда не было." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "They lied to you just to make you leave." },
          new() { Language = Language.Ru, String = "Они соврали, чтобы ты наконец ушел." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Seems you're just a bothersome side character." },
          new() { Language = Language.Ru, String = "Похоже, ты лишь надоедливый герой второго плана." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "And I have other lost souls waiting for me." },
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
          new() { Language = Language.Eng, String = "Why should such a valuable soul fade so soon?" },
          new() { Language = Language.Ru, String = "Зачем же такой ценной душе так скоро угасать?" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Better to trade it to me!" },
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
          new() { Language = Language.Eng, String = "If you don’t have enough souls for a purchase..." },
          new() { Language = Language.Ru, String = "Если тебе не хватает душ на покупку..." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "You can sell your items from the inventory!" },
          new() { Language = Language.Ru, String = "Ты можешь продать свои вещи из инвентаря!" }
        }
      },
    };

    public static readonly List<LocalizedString> MeetChestSecondTime = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Heroes before me have wounded this chest." },
          new() { Language = Language.Ru, String = "Герои до меня ранили этот сундук." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I'll finish it off." },
          new() { Language = Language.Ru, String = "А я его добью." }
        }
      },
    };

    public static readonly List<LocalizedString> DefeatChest = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Finally! I’ve won!" },
          new() { Language = Language.Ru, String = "Наконец-то! Я победил!" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Now my dream..." },
          new() { Language = Language.Ru, String = "Теперь моя мечта..." }
        }
      }
    };

    public static readonly List<LocalizedString> Win = new()
    {
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "My dream!" },
          new() { Language = Language.Ru, String = "Моя мечта!" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "If only it weren't for your pride and arrogance..." },
          new() { Language = Language.Ru, String = "Если бы не ваше самомнение и гордость..." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "...the confidence that fate will bend to your will." },
          new() { Language = Language.Ru, String = "...уверенность в том, что судьба подстроиться под вас." }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "I would have never gotten this chest!" },
          new() { Language = Language.Ru, String = "Я бы ни когда не получил этот сундук!" }
        }
      },
      new LocalizedString
      {
        Entries = new List<LocalizedEntry>
        {
          new() { Language = Language.Eng, String = "Thank you, hero. Farewell." },
          new() { Language = Language.Ru, String = "Спасибо, герой. И прощай." }
        }
      },
    };
  }
}