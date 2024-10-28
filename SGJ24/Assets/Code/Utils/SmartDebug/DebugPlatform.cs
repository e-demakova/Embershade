using System;

namespace Utils.SmartDebug
{
  [Flags]
  public enum DebugPlatform
  {
    Editor = 1 << 1,
    Build = 1 << 2,
    DebugBuild = 1 << 3,
    All = Editor | Build | DebugBuild,
    None = 0,
  }
}