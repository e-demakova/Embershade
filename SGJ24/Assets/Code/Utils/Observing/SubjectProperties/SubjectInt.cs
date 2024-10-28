using System;

namespace Utils.Observing.SubjectProperties
{
  public interface ISubjectInt : ISubjectProperty<int>
  {
    public int Min { get; set; }
    public int Max { get; set; }
  }

  public class SubjectInt : SubjectProperty<int>, ISubjectInt
  {
    public SubjectInt(int value, int min, int max)
    {
      CurrentValue = value;
      Min = min;
      Max = max;
    }
    
    public override int Value
    {
      set
      {
        value = Math.Min(Max, value);
        value = Math.Max(Min, value);
        
        if (CurrentValue == value)
          return;
        
        int oldValue = CurrentValue;
        CurrentValue = value;

        OnChanged.Raise(new ValueChanged<int> { OldValue = oldValue, NewValue = CurrentValue });
      }
    }

    public int Min { get; set; } = int.MinValue;
    public int Max { get; set; } = int.MaxValue;

    public bool IsMax => Value >= Max;
    public bool IsMin => Value <= Min;

    public SubjectInt(int value) : base(value) { }
    public SubjectInt() { }
  }
}