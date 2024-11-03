using System.Collections.Generic;
using Game.Infrastructure.Data;

namespace Game.Battles
{
  public enum CombatantType
  {
    Hero = 0,
    Enemy = 1
  }

  public class ArenaData : IData
  {
    public readonly Dictionary<CombatantType, CombatantData> Combatants = new()
    {
      { CombatantType.Hero, CombatantsList.FirstHero },
      { CombatantType.Enemy, CombatantsList.Witch },
    };

    public Queue<CombatantData> EnemiesQueue = new();
    public bool SupportArrived { get; set; }

    public CombatantData GetNextEnemy()
    {
      if (EnemiesQueue.Count == 0)
        ResetQueue();
      
      return EnemiesQueue.Dequeue();
    }

    public void ResetQueue()
    {
      EnemiesQueue.Clear();
      EnemiesQueue.Enqueue(CombatantsList.Witch);
      EnemiesQueue.Enqueue(CombatantsList.CatEnemy);
      EnemiesQueue.Enqueue(CombatantsList.Goat);
      EnemiesQueue.Enqueue(CombatantsList.Heads);
      EnemiesQueue.Enqueue(CombatantsList.Scarecrow);
    }
  }
}