using System;
using UnityEngine;

[Serializable]
public class S2_InputButton : S2_Input<bool>
{
    [SerializeField] string keyName = "None";
    [SerializeField] bool useName = false;
    [SerializeField] bool keyValue = false;
    [SerializeField] KeyCode keyCode = KeyCode.None;
    [SerializeField] S2_ButtonStateEvent buttonState = S2_ButtonStateEvent.PRESSED;
    [SerializeField] S2_ButtonEvent buttonEvent = S2_ButtonEvent.NONE;

    public S2_ButtonEvent ButtonEvent => buttonEvent;

    public override bool InputAction
    {
        get
        {
            if (useName)
                return keyValue = TryGetInputValue();
            else
            {
                if (buttonState == S2_ButtonStateEvent.PRESSED)
                    return keyValue = Input.GetKey(keyCode);
                else if (buttonState == S2_ButtonStateEvent.DOWN)
                    return keyValue = Input.GetKeyDown(keyCode);
                else
                    return keyValue = Input.GetKeyUp(keyCode);
            }
        }
    }

    bool TryGetInputValue()
    {
        try
        {
            if (buttonState == S2_ButtonStateEvent.PRESSED)
                return keyValue = Input.GetButton(keyName);
            else if (buttonState == S2_ButtonStateEvent.DOWN)
                return keyValue = Input.GetButtonDown(keyName);
            else
                return keyValue = Input.GetButtonUp(keyName);
        }
        catch (ArgumentException _e)
        {
            Debug.LogError($"Button Input Error at => {_e.Message}");
            return false;
        }
    }
}