using System;

namespace Utils.Observing.SubjectProperties
{
  public interface ISubjectFloat : ISubjectProperty<float>
  {
    public float Min { get; set; }
    public float Max { get; set; }
  }

  public class SubjectFloat : SubjectProperty<float>, ISubjectFloat
  {
    public SubjectFloat(float value, float min, float max)
    {
      CurrentValue = value;
      Min = min;
      Max = max;
    }
    
    public override float Value
    {
      set
      {
        if (Math.Abs(CurrentValue - value) < float.Epsilon)
          return;

        value = Math.Min(Max, value);
        value = Math.Max(Min, value);

        float oldValue = CurrentValue;
        CurrentValue = value;

        OnChanged.Raise(new ValueChanged<float> { OldValue = oldValue, NewValue = CurrentValue });
      }
    }

    
    public float Min { get; set; } = float.MinValue;
    
    public float Max { get; set; } = float.MaxValue;

    public SubjectFloat(float value) : base(value) { }
    public SubjectFloat() { }
  }
}