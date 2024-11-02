using Game.Infrastructure.AssetsManagement;
using Game.Infrastructure.Data;

namespace Game.Battles
{
  public interface IArenaFactory
  {
    void CreateCombatants();
  }

  public class ArenaFactory : IArenaFactory
  {
    private readonly IBuildersFactory _builders;
    private readonly IGameData _data;
    private ArenaData ArenaData => _data.Get<ArenaData>();

    public ArenaFactory(IBuildersFactory builders, IGameData data)
    {
      _builders = builders;
      _data = data;
    }

    public void CreateCombatants()
    {
      ArenaData.Combatants[CombatantType.Hero].Instance =
        _builders.FromResources(Assets.Hero).At(Combatants.HeroPosition).Instantiate<CombatantView>();

      ArenaData.Combatants[CombatantType.Enemy].Instance =
        _builders.FromResources(Assets.Enemy).At(Combatants.EnemyPosition).Instantiate<CombatantView>();

      if (ArenaData.SupportArrived)
        _builders.FromResources(Assets.Support).Instantiate();
    }
  }
}