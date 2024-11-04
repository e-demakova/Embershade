using Game.Battles;
using Game.Infrastructure.Data;

namespace Game
{
  public class ProgressData : IData
  {
    public int Level;
    public int Run;
    public int ChestMeet;
    public bool Win;
    public CombatantData Chest;
  }
}