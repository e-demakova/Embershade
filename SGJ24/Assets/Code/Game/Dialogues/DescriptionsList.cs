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
        new() { Language = Language.Ru, String = "Временное описание для теста." }
      }
    };
    
    public static readonly LocalizedString Broken = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Corrupted" },
        new() { Language = Language.Ru, String = "Поврежден" }
      }
    };

    public static readonly LocalizedString Hp = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Increases health by {0} at the start of each battle." },
        new() { Language = Language.Ru, String = "Увеличивает здоровье на {0} в начале каждого боя" }
      }
    };
    
    public static readonly LocalizedString HpForEveryBroken = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Increases health by {0} for each Corrupted Cake in inventory at the start of each battle." },
        new() { Language = Language.Ru, String = "В начале каждого боя увеличивает здоровье на {0} за каждый Поврежденный Торт." }
      }
    };

    public static readonly LocalizedString Atk = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Increases attack by {0}" },
        new() { Language = Language.Ru, String = "Увеличивает атаку на {0}" }
      }
    };
    
    public static readonly LocalizedString AtkForEveryBroken = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Increases attack by {0} for each Corrupted Finger in inventory." },
        new() { Language = Language.Ru, String = "Увеличивает атаку на {0} за каждый Поврежденный Палец." }
      }
    };
    
    public static readonly LocalizedString DecreaseEnemyAttak = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Decreases enemy attack on {0}" },
        new() { Language = Language.Ru, String = "Уменьшает атаку противника на {0}" }
      }
    };
    
    public static readonly LocalizedString DecreaseEnemyForEveryBroken = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Decreases enemy attack by {0} for each Corrupted Eye in inventory." },
        new() { Language = Language.Ru, String = "Уменьшает атаку противника на {0} за каждый Поврежденный Глаз." }
      }
    };
  }
}