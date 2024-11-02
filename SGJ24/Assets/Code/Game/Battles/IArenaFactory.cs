﻿using Game.Infrastructure.AssetsManagement;
using Game.Infrastructure.Data;
using UnityEngine;

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
    private readonly IAssetProvider _assets;
    private ArenaData ArenaData => _data.Get<ArenaData>();

    public ArenaFactory(IBuildersFactory builders, IGameData data, IAssetProvider assets)
    {
      _builders = builders;
      _assets = assets;
      _data = data;
    }

    public void CreateCombatants()
    {
      CreateHero();
      CreateEnemy();

      if (ArenaData.SupportArrived)
        _builders.FromResources(Assets.Support).Instantiate();
    }

    private void CreateHero()
    {
      CombatantData hero = ArenaData.Combatants[CombatantType.Hero];
      
      hero.Instance =
        _builders.FromResources(Assets.Hero).At(new Vector3(-2.5f, -2.5f, 8f))
                 .Instantiate<CombatantView>()
                 .SetUp(_assets.LoadAsset<Sprite>(hero.SpritePath));
    }

    private void CreateEnemy()
    {
      CombatantData enemy = ArenaData.Combatants[CombatantType.Enemy] = CombatantsList.DefaultEnemy;
      enemy.Instance = _builders.FromResources(Assets.Enemy).At(new Vector3(2.5f, -2.5f, 8f)).Instantiate<CombatantView>();
    }
  }
}