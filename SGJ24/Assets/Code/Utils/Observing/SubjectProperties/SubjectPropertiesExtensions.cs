namespace Utils.Observing.SubjectProperties
{
  public static class SubjectPropertiesExtensions
  {
    public static float Percentage(this ISubjectFloat subjectFloat)
      => subjectFloat.Value / subjectFloat.Max;

    public static float Percentage(this ISubjectInt subjectFloat)
      => subjectFloat.Value / (float) subjectFloat.Max;
  }
}