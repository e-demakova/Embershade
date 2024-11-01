using System.Collections.Generic;
using Game.Infrastructure.AssetsManagement;
using Game.Infrastructure.Data;
using Utils.Extensions;

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
    private List<Combatant> Combatants => _data.Get<ArenaData>().Combatants;

    public ArenaFactory(IBuildersFactory builders, IGameData data)
    {
      _builders = builders;
      _data = data;
    }

    public void CreateCombatants()
    {
      _builders.FromResources(Assets.Hero).At(Battles.Combatants.HeroPosition).Instantiate<Combatant>().AddTo(Combatants);
      _builders.FromResources(Assets.Enemy).At(Battles.Combatants.EnemyPosition).Instantiate<Combatant>().AddTo(Combatants);
    }
  }
}