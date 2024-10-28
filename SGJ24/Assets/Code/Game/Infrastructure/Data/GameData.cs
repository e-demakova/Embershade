using System;
using System.Collections.Generic;
using Utils.Extensions;

namespace Game.Infrastructure.Data
{
  public interface IData { }

  public interface IGameData
  {
    T Get<T>() where T : IData, new();
    public void Clear();
  }

  public class GameData : IGameData
  {
    private readonly Dictionary<Type, IData> _data = new();

    public T Get<T>() where T : IData, new() =>
      _data.SafeGet<T, IData>();

    public void Clear() =>
      _data.Clear();
  }
}