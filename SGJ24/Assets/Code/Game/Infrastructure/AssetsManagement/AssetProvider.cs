using JetBrains.Annotations;
using UnityEngine;
using Utils.SmartDebug;
using Object = UnityEngine.Object;

namespace Game.Infrastructure.AssetsManagement
{
  public interface IAssetProvider
  {
    T LoadAsset<T>(string address) where T : Object;
  }

  [UsedImplicitly]
  public class AssetProvider : IAssetProvider
  {
    public T LoadAsset<T>(string address) where T : Object
    {
      T asset = Resources.Load<T>(address);
      LogResult(asset, address);
      return asset;
    }

    private static void LogResult<T>(T asset, string address) where T : Object
    {
      if (asset)
        DLogger.Message(DSenders.Assets).WithText("Load resource by path: " + address.White()).Log();
      else
        DLogger.Message(DSenders.Assets).WithFormat(DebugFormat.Exception)
               .WithText("Can't find resource by path: " + address.Red().Bold())
               .Log();
    }
  }
}