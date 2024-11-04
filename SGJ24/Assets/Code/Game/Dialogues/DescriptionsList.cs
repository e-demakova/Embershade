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
    
    public static readonly LocalizedString Broken = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Corrupted." },
        new() { Language = Language.Ru, String = "Повреждено." }
      }
    };

    public static readonly LocalizedString Hp = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Increase health on {0} every battle." },
        new() { Language = Language.Ru, String = "Увеличивает здоровье на {0} в начале каждого боя" }
      }
    };
    
    public static readonly LocalizedString HpForEveryBroken = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Increase health by {0} for each broken cake in inventory at the start of each turn." },
        new() { Language = Language.Ru, String = "В начале каждого хода Увеличивает здоровье на {0} за каждый поврежденный торт." }
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
    
    public static readonly LocalizedString AtkForEveryBroken = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Increase attack by {0} for each broken finger in inventory." },
        new() { Language = Language.Ru, String = "Увеличивает атаку на {0}, за каждый поврежденный палец." }
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
    
    public static readonly LocalizedString DecreaseEnemyForEveryBroken = new()
    {
      Entries = new List<LocalizedEntry>
      {
        new() { Language = Language.Eng, String = "Decrease enemy attack by {0} for each broken eye in inventory." },
        new() { Language = Language.Ru, String = "Уменьшает атаку противника на {0} за каждый поврежденный глаз." }
      }
    };
  }
}