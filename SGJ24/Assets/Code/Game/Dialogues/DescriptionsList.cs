using System.Collections.Generic;
using Utils.Localization;

namespace Game.Dialogues
{
  public static class DescriptionsList
  {
    public static readonly LocalizedString Default = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Default description for test." },
        new() { Language = Language.Ru, String = "Временнное описание для теста." }
      }
    };

    public static readonly LocalizedString Hp = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Increase health on {0}" },
        new() { Language = Language.Ru, String = "Увеличивает здоровье на {0}" }
      }
    };

    public static readonly LocalizedString Atk = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Increase attack on {0}" },
        new() { Language = Language.Ru, String = "Увеличивает атаку на {0}" }
      }
    };
    
    public static readonly LocalizedString DecreaseEnemyAttak = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Decrease enemy attack on {0}" },
        new() { Language = Language.Ru, String = "Уменьшает атаку противника на {0}" }
      }
    };
  }
}