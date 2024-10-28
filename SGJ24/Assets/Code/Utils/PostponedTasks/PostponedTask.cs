using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Utils.PostponedTasks
{
  public class PostponedTask
  {
    private readonly List<Action> _onComplete = new();
    private readonly Func<UniTask> _task;

    public PostponedTask(Func<UniTask> task)
    {
      _task = task;
    }

    public async UniTask Activate()
    {
      try
      {
        await _task();
      }
      catch (Exception e)
      {
        PostponerError.Log(e);
      }

      Complete();
    }

    public void OnComplete(Action action) =>
      _onComplete.Add(action);

    private void Complete()
    {
      foreach (Action action in _onComplete)
      {
        try
        {
          action();
        }
        catch (Exception e)
        {
          PostponerError.Log(e);
        }
      }
    }
  }
}