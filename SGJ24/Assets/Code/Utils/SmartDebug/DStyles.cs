using UnityEngine;

namespace Utils.SmartDebug
{
  public static class DStyles
  {
    public const string WhiteColor = "<color=white>";
    public const string YellowColor = "<color=yellow>";
    public const string CyanColor = "<color=cyan>";
    public const string GreenColor = "<color=green>";
    public const string RedColor = "<color=red>";
    public const string BlueColor = "<color=blue>";
    public const string MagentaColor = "<color=magenta>";
    public const string ColorClose = "</color>";
    public const string BoldOpen = "<b>";
    public const string BoldClose = "</b>";

    public static string Bold(this string value) =>
      Application.isEditor ? BoldOpen + value + BoldClose : value.ToString();
    
    public static string White(this string value) =>
      Colored(value, WhiteColor);

    public static string Yellow(this string value) =>
      Colored(value, YellowColor);

    public static string Cyan(this string value) =>
      Colored(value, CyanColor);

    public static string Green(this string value) =>
      Colored(value, GreenColor);

    public static string Red(this string value) =>
      Colored(value, RedColor);

    public static string Blue(this string value) =>
      Colored(value, BlueColor);

    public static string Magenta(this string value) =>
      Colored(value, MagentaColor);

    private static string Colored(this string value, string color) =>
      Application.isEditor ? color + value + ColorClose : value.ToString();
  }
}