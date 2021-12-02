using UnityEngine;

[RequireComponent(typeof(S2_CameraOrbit))]
public class S2_CameraOrbitTriggerLinker : MonoBehaviour
{
    [SerializeField] S2_CameraOrbit cameraOrbit = null;

    public bool IsValid => cameraOrbit;
    public S2_CameraOrbit CameraOrbit => cameraOrbit;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        cameraOrbit = GetComponent<S2_CameraOrbit>();
    }

    public void SetTarget(CameraOrbitSettings _settings)
    {
        if (!IsValid) return;
        cameraOrbit.Settings.Target = _settings.Target;
    }
    public void SetHeight(CameraOrbitSettings _settings)
    {
        if (!IsValid) return;
        cameraOrbit.Settings.CameraOrbitOffset.Height = _settings.CameraOrbitOffset.Height;
    }
    public void SetRayon(CameraOrbitSettings _settings)
    {
        if (!IsValid) return;
        cameraOrbit.Settings.CameraOrbitOffset.Rayon = _settings.CameraOrbitOffset.Rayon;
    }
    public void SetGoalAngle(CameraOrbitSettings _settings)
    {
        if (!IsValid) return;
        float _goalAngle = _settings.CameraOrbitOffset.GoalAngle;
        _goalAngle %= 360;
        float _angleDifference = _goalAngle - cameraOrbit.Settings.CameraOrbitOffset.CurrentAngle;
        if (_angleDifference > 180)
            _goalAngle -= 360;
        if (_angleDifference < 180)
            _goalAngle += 360;
        cameraOrbit.Settings.CameraOrbitOffset.GoalAngle = _goalAngle;
    }
    public void SetSmoothRotation(CameraOrbitSettings _settings)
    {
        if (!IsValid) return;
        cameraOrbit.Settings.SmoothRotation = _settings.SmoothRotation;
    }
    public void SetSmoothMovement(CameraOrbitSettings _settings)
    {
        if (!IsValid) return;
        cameraOrbit.Settings.SmoothMove = _settings.SmoothMove;
    }
    public void SetMoveSpeed(CameraOrbitSettings _settings)
    {
        if (!IsValid) return;
        cameraOrbit.Settings.MoveSpeed = _settings.MoveSpeed;
    }
    public void SetRotateSpeed(CameraOrbitSettings _settings)
    {
        if (!IsValid) return;
        cameraOrbit.Settings.RotateSpeed = _settings.RotateSpeed;
    }
    public void SetCurrentAngle(CameraOrbitSettings _settings)
    {
        if (!IsValid) return;
        cameraOrbit.Settings.CameraOrbitOffset.CurrentAngle = _settings.CameraOrbitOffset.CurrentAngle;
    }
}