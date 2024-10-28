using System;
using Utils.Observing.Handlers;
using Utils.Observing.Subscribers;

namespace Utils.Observing.SubjectProperties
{
  public struct ValueChanged<T>
  {
    public T OldValue;
    public T NewValue;

    public override string ToString() =>
      $"Old: {OldValue} New: {NewValue}";
  }

  public interface ISubjectProperty<T>
  {
    T Value { get; }
    ISubscriber<ValueChanged<T>> OnChange();
  }

  public class SubjectProperty<T> : ISubjectProperty<T>, IDisposable
  {
    protected readonly Handler<ValueChanged<T>> OnChanged = new();

    protected T CurrentValue;

    public virtual T Value
    {
      get => CurrentValue;
      set
      {
        if (CurrentValue != null && CurrentValue.Equals(value))
          return;

        T oldValue = CurrentValue;
        CurrentValue = value;

        OnChanged.Raise(new ValueChanged<T> { OldValue = oldValue, NewValue = CurrentValue });
      }
    }

    public SubjectProperty(T value)
    {
      CurrentValue = value;
    }

    public SubjectProperty() { }

    public ISubscriber<ValueChanged<T>> OnChange() =>
      new Subscriber<ValueChanged<T>>(OnChanged);

    public void ChangeSilently(T to) =>
      CurrentValue = to;

    public void Dispose() =>
      OnChanged.Dispose();
  }
}