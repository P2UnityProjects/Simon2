using UnityEngine;

public class S2_CameraTPS : S2_CameraBehaviour
{

    protected override Vector3 GetPosition()
    {
        return Settings.IsValid ? Vector3.MoveTowards(CurrentPosition, Settings.CameraOffset.GetOffset(Settings.Target), Time.deltaTime * Settings.MoveSpeed)
                                : Vector3.zero;
    }
    protected override Quaternion GetRotation()
    {
        if (!Settings.IsValid) return Quaternion.identity;
        Vector3 _offset = (Settings.CameraLookAtOffset.GetOffset(Settings.Target) - CurrentPosition);
        if (_offset == Vector3.zero) return Quaternion.identity;
        Quaternion _lookAt = Quaternion.LookRotation(_offset);
        return Quaternion.RotateTowards(CurrentRotation, _lookAt, Time.deltaTime * Settings.RotateSpeed);
    }
    protected override void MoveTo()
    {
        transform.position = GetPosition();
    }
    protected override void RotateTo()
    {
        transform.rotation = GetRotation();
    }
}