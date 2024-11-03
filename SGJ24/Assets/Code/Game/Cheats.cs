using System;
using System.Collections.Generic;
using Game.Infrastructure.Core;
using Game.Infrastructure.Data;
using Game.PlayerInput;
using Game.Shop;
using Utils.Extensions;
using Zenject;

namespace Game
{
  public class Cheats : IInitializable, IDisposable
  {
    private readonly List<IDisposable> _subscribers = new();
    private readonly IInput _input;
    private readonly IGameStateMachine _stateMachine;
    private readonly IGameData _data;

    public Cheats(IInput input, IGameStateMachine stateMachine, IGameData data)
    {
      _input = input;
      _stateMachine = stateMachine;
      _data = data;
    }

    public void Initialize()
    {
      if (!GameSettings.Cheats)
        return;

      _input.OnLoadShop.Down().Subscribe(LoadShop).AddTo(_subscribers);
      _input.OnAddSouls.Down().Subscribe(AddSouls).AddTo(_subscribers);
      _input.OnLoadArena.Down().Subscribe(LoadArena).AddTo(_subscribers);
    }

    public void Dispose() =>
      _subscribers.DisposeAll();

    private void AddSouls() =>
      _data.Get<SoulsData>().InWallet += 10;

    private void LoadShop() =>
      _stateMachine.Enter<LoadShopState>();
    
    private void LoadArena() =>
      _stateMachine.Enter<LoadArenaState>();
  }
}