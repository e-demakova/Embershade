using System;
using Cysharp.Threading.Tasks;

namespace Utils.PostponedTasks
{
  public static class Postponer
  {
    private const bool AutoRun = true;

    public static PostponedSequence Sequence() =>
      SetUpSequence(new PostponedSequence());

    public static PostponedSequence Wait(Func<UniTask> task)
    {
      PostponedSequence sequence = new();
      sequence.Wait(task);
      return SetUpSequence(sequence);
    }

    public static PostponedSequence Do(Action action)
    {
      PostponedSequence sequence = new();
      sequence.Do(action);
      return SetUpSequence(sequence);
    }

    private static async UniTask Run(PostponedSequence sequence)
    {
      await UniTask.Yield();
      await UniTask.NextFrame();
      await sequence.Run();
    }

    private static PostponedSequence SetUpSequence(PostponedSequence sequence)
    {
      if (AutoRun)
        Run(sequence).Forget();

      return sequence;
    }
  }
}