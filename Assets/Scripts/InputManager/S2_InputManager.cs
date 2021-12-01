using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class S2_InputManager : S2_Singleton<S2_InputManager>
{
    event Action OnUpdateInput = null;

    [SerializeField] List<S2_InputButton> buttonsInputs = new List<S2_InputButton>();
    [SerializeField] List<S2_InputAxis> axisInputs = new List<S2_InputAxis>();

    private void Update() => OnUpdateInput?.Invoke();
    private void OnDestroy() => OnUpdateInput = null;

    public void BindAction(S2_ButtonEvent _buttonEvent, Action<bool> _callback)
    {
        List<S2_InputButton> _buttons = buttonsInputs.Where((button) => button.ButtonEvent == _buttonEvent).ToList();
        _buttons.ForEach((button) => OnUpdateInput += () => _callback?.Invoke(button.InputAction));
    }
    public void UnBindAction(S2_ButtonEvent _buttonEvent, Action<bool> _callback)
    {
        List<S2_InputButton> _buttons = buttonsInputs.Where((button) => button.ButtonEvent == _buttonEvent).ToList();
        _buttons.ForEach((button) => OnUpdateInput -= () => _callback?.Invoke(button.InputAction));
    }
    public void BindAxis(S2_AxisEvent _axisEvent, Action<float> _callback)
    {
        List<S2_InputAxis> _axis = axisInputs.Where((axis) => _axisEvent == axis.AxisEvent).ToList();
        _axis.ForEach((axis) => OnUpdateInput += () => _callback?.Invoke(axis.InputAction));
    }
    public void UnBindAxis(S2_AxisEvent _axisEvent, Action<float> _callback)
    {
        List<S2_InputAxis> _axis = axisInputs.Where((axis) => _axisEvent == axis.AxisEvent).ToList();
        _axis.ForEach((axis) => OnUpdateInput -= () => _callback?.Invoke(axis.InputAction));
    }
}