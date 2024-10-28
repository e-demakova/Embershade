using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Utils.Extensions;

namespace Utils.PostponedTasks
{
  public class PostponedSequence
  {
    private readonly List<PostponedTask> _tasks = new();
    private readonly List<Action> _onStart = new();

    public PostponedSequence Wait(Func<UniTask> task)
    {
      new PostponedTask(task).AddTo(_tasks);
      return this;
    }

    public PostponedSequence Do(Action action)
    {
      if (_tasks.Count > 0)
        _tasks[^1].OnComplete(action);
      else
        _onStart.Add(action);

      return this;
    }

    public async UniTask Run()
    {
      OnStart();

      foreach (PostponedTask task in _tasks)
        await task.Activate();
    }

    private void OnStart()
    {
      foreach (Action action in _onStart)
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