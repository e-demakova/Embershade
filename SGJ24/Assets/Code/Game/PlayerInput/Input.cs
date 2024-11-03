using System;
using System.Linq;
using Game.Infrastructure.AssetsManagement;
using Input;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Utils.Extensions;
using Utils.Observing.Handlers;
using Utils.Observing.Subscribers;
using Zenject;
using static UnityEngine.InputSystem.InputAction;

namespace Game.PlayerInput
{
  public struct InputContext
  {
    public InputAction Action;
    public InputActionPhase Phase;
  }

  public class Input : IInput, IInitializable, IDisposable, ITickable
  {
    private readonly Handler<InputContext> _actionsHandler = new();

    private readonly Actions _actions = new();
    private readonly IBuildersFactory _factory;

    private EventSystem _eventSystem;
    public Actions.PlayerActions Main => _actions.Player;
    public ISubscriber<InputContext> OnAct => OnAction(Main.Act);
    public ISubscriber<InputContext> OnLoadShop => OnAction(Main.LoadShop);
    public ISubscriber<InputContext> OnLoadArena => OnAction(Main.LoadArena);
    public ISubscriber<InputContext> OnAddSouls => OnAction(Main.AddSouls);

    public EventSystem EventSystem =>
      _eventSystem ??= _factory.FromResources(Assets.EventSystem).Instantiate<EventSystem>().DontDestroyOnLoad();

    public bool Enabled
    {
      set
      {
        if (value)
          _actions.Enable();
        else
          _actions.Disable();

        EventSystem.enabled = value;
      }
    }

    public Input(IBuildersFactory factory) =>
      _factory = factory;

    public void Initialize() =>
      Main.Get().actionTriggered += OnActionTriggered;

    public void Dispose()
    {
      _actionsHandler?.Dispose();
      Main.Get().actionTriggered -= OnActionTriggered;
    }

    public void Tick() =>
      RaisePerformed();

    public ISubscriber<InputContext> OnAction(InputAction action) =>
      new Subscriber<InputContext>(_actionsHandler).When(x => x.Action == action);

    private void RaisePerformed()
    {
      foreach (InputAction inputAction in Main.Get().Where(x => x.phase == InputActionPhase.Performed))
      {
        _actionsHandler.Raise(new InputContext
        {
          Action = inputAction,
          Phase = InputActionPhase.Performed
        });
      }
    }

    private void OnActionTriggered(CallbackContext context)
    {
      if (context.phase == InputActionPhase.Performed)
        return;

      _actionsHandler.Raise(new InputContext
      {
        Action = context.action,
        Phase = context.phase
      });
    }
  }
}