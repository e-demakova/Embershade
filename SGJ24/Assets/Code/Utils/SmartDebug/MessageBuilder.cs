using System;
using UnityEngine;

namespace Utils.SmartDebug
{
  public class MessageBuilder
  {
    private readonly string _senderName;
    private readonly DSender _sender;
    
    private string _text = string.Empty;
    private DebugFormat _format;

    private string _message;

    public MessageBuilder(string senderName, DSender sender)
    {
      _senderName = senderName;
      _sender = sender;
    }

    public MessageBuilder WithText(object message)
    {
      _text = message.ToString();
      _message = null;
      return this;
    }

    public MessageBuilder WithFormat(DebugFormat format)
    {
      _format = format;
      return this;
    }

    public void Log()
    {
      if (!PlatformAvailable(_sender.Platform) && _format != DebugFormat.Exception)
        return;

      _message ??= _senderName + " " + _text;

      switch (_format)
      {
        case DebugFormat.Normal:
          Debug.Log(_message);
          break;

        case DebugFormat.Warning:
          Debug.LogWarning(_message);
          break;

        case DebugFormat.Assertion:
          Debug.LogAssertion(_message);
          break;

        case DebugFormat.Error:
          Debug.LogError(_message);
          break;

        case DebugFormat.Exception:
          Debug.LogException(new Exception(_message));
          break;
      }
      
    }

    private static bool PlatformAvailable(DebugPlatform platform)
    {
      return (Application.isEditor && platform.HasFlag(DebugPlatform.Editor)) ||
             (Debug.isDebugBuild && !Application.isEditor && platform.HasFlag(DebugPlatform.DebugBuild)) ||
             (!Debug.isDebugBuild && !Application.isEditor && platform.HasFlag(DebugPlatform.Build));
    }
  }
}