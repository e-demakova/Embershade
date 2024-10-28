using System;
using Utils.Observing.Subscribers;

namespace Utils.Observing.SubjectProperties
{
  public static class NumbersSubjectPropertiesExtensions
  {
    public static ISubscriber<ValueChanged<float>> WhenIncrease(this ISubscriber<ValueChanged<float>> subscriber) =>
      subscriber.When(x => x.NewValue > x.OldValue);

    public static ISubscriber<ValueChanged<int>> WhenIncrease(this ISubscriber<ValueChanged<int>> subscriber) =>
      subscriber.When(x => x.NewValue > x.OldValue);


    public static ISubscriber<ValueChanged<float>> WhenDecrease(this ISubscriber<ValueChanged<float>> subscriber) =>
      subscriber.When(x => x.NewValue < x.OldValue);

    public static ISubscriber<ValueChanged<int>> WhenDecrease(this ISubscriber<ValueChanged<int>> subscriber) =>
      subscriber.When(x => x.NewValue < x.OldValue);


    public static ISubscriber<ValueChanged<int>> WhenMore(this ISubscriber<ValueChanged<int>> subscriber, int that) =>
      subscriber.When(x => x.NewValue > that);

    public static ISubscriber<ValueChanged<int>> WhenMoreOrEqual(this ISubscriber<ValueChanged<int>> subscriber, int that) =>
      subscriber.When(x => x.NewValue >= that);

    public static ISubscriber<ValueChanged<float>> WhenMore(this ISubscriber<ValueChanged<float>> subscriber, float that) =>
      subscriber.When(x => x.NewValue > that);

    public static ISubscriber<ValueChanged<float>> WhenMoreOrEqual(this ISubscriber<ValueChanged<float>> subscriber, float that) =>
      subscriber.When(x => x.NewValue >= that);

    public static ISubscriber<ValueChanged<int>> WhenEqual(this ISubscriber<ValueChanged<int>> subscriber, int that) =>
      subscriber.When(x => x.NewValue == that);

    public static ISubscriber<ValueChanged<float>> WhenEqual(this ISubscriber<ValueChanged<float>> subscriber, float that) =>
      subscriber.When(x => Math.Abs(x.NewValue - that) < float.Epsilon);
    
    public static ISubscriber<ValueChanged<int>> WhenLess(this ISubscriber<ValueChanged<int>> subscriber, int that) =>
      subscriber.When(x => x.NewValue < that);

    public static ISubscriber<ValueChanged<int>> WhenLessOrEqual(this ISubscriber<ValueChanged<int>> subscriber, int that) =>
      subscriber.When(x => x.NewValue <= that);

    public static ISubscriber<ValueChanged<float>> WhenLess(this ISubscriber<ValueChanged<float>> subscriber, float that) =>
      subscriber.When(x => x.NewValue < that);

    public static ISubscriber<ValueChanged<float>> WhenLessOrEqual(this ISubscriber<ValueChanged<float>> subscriber, float that) =>
      subscriber.When(x => x.NewValue <= that);
  }
}