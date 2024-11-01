namespace Game.Battles
{
  public class BattleUI : ControllableMono<BattleUI>
  {
    public void Show() =>
      gameObject.SetActive(true);

    public void Hide() =>
      gameObject.SetActive(false);
  }
}