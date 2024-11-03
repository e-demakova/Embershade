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
      { CombatantType.Enemy, CombatantsList.DefaultEnemy },
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
      EnemiesQueue.Enqueue(CombatantsList.DefaultEnemy);
      EnemiesQueue.Enqueue(CombatantsList.EnemyOne);
      EnemiesQueue.Enqueue(CombatantsList.EnemyTwo);
    }
  }
}