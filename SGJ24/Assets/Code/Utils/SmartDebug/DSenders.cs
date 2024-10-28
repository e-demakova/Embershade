namespace Utils.SmartDebug
{
  public static class DSenders
  {
    public static readonly DSender Application = new(name: "[Application]".Green());
    public static readonly DSender Assets = new(name: "[Assets]");
    public static readonly DSender GameStateMachine = new(name: "[Game State Machine]");
    public static readonly DSender SceneData = new(name: "[Scene Data]");
    public static readonly DSender Postponer = new(name: "[Postponer]");
    public static readonly DSender Localization = new(name: "[Localization]");
  }
}