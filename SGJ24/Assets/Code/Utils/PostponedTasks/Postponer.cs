using System;
using Cysharp.Threading.Tasks;

namespace Utils.PostponedTasks
{
  public static class Postponer
  {
    private const bool AutoRun = true;

    public static PostponedSequence Wait(Func<UniTask> task)
    {
      PostponedSequence sequence = new();
      sequence.Wait(task);
      
      if (AutoRun) 
        Run(sequence).Forget();

      return sequence;
    }

    public static PostponedSequence Do(Action action)
    {
      PostponedSequence sequence = new();
      sequence.Do(action);
      
      if (AutoRun) 
        Run(sequence).Forget();

      return sequence;
    }

    private static async UniTask Run(PostponedSequence sequence)
    {
      await UniTask.Yield();
      await UniTask.NextFrame();
      await sequence.Run();
    }
  }
}