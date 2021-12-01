using System;
using UnityEngine;

[Serializable]
public class S2_InputAxis : S2_Input<float>
{
    [SerializeField] string axisInputName = "Vertical";
    [SerializeField, Range(-1, 1)] float axisInputValue = 0;
    [SerializeField] bool invertAxis = false;
    [SerializeField] S2_AxisEvent axisEvent = S2_AxisEvent.NONE;

    public S2_AxisEvent AxisEvent => axisEvent;

    public override float InputAction
    {
        get
        {
            try
            {
                float _result = Input.GetAxis(axisInputName);
                return axisInputValue = invertAxis ? -_result : _result;
            }
            catch (ArgumentException _e)
            {
                Debug.LogError($"Axis Input Error at => {_e.Message}");
                return 0;
            }
        }
    }
}