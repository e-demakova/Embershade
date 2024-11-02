namespace Game.Battles
{
  public interface ITrigger { }

  public class DeathTrigger : ITrigger
  {
    public CombatantData Corpse;
    public CombatantData Killer;
  }
}