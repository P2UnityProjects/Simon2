using UnityEngine;

[RequireComponent(typeof(S2_CameraOrbitTriggerLinker))]
public class S2_CameraOrbit : S2_CameraBehaviour
{
    [SerializeField] CameraOrbitSettings settings = new CameraOrbitSettings();
    [SerializeField] S2_CameraOrbitTriggerLinker cameraOrbitTriggerLinker = null;

    public bool IsValid => cameraOrbitTriggerLinker;
    public CameraOrbitSettings Settings => settings;
    public S2_CameraOrbitTriggerLinker CameraOrbitTriggerLinker => cameraOrbitTriggerLinker;

    protected override void Start()
    {
        base.Start();
        Init();
    }

    void Init()
    {
        cameraOrbitTriggerLinker = GetComponent<S2_CameraOrbitTriggerLinker>();
    }
    void UpdateAngle()
    {
        settings.CameraOrbitOffset.CurrentAngle = settings.SmoothMove ? Mathf.Lerp(settings.CameraOrbitOffset.CurrentAngle,
                                                                                   settings.CameraOrbitOffset.GoalAngle,
                                                                                   settings.MoveSpeed * Time.deltaTime)
                                                                      : settings.CameraOrbitOffset.GoalAngle;
    }
    protected override Vector3 GetPosition()
    {
        if (!settings.IsValid) return Vector3.zero;
        UpdateAngle();
        Vector3 _camPosition = S2_CameraAngleCalculator.GetAnglePosition(settings.CameraOrbitOffset.CurrentAngle, 
                                                                         settings.CameraOrbitOffset.Rayon,
                                                                         settings.CameraOrbitOffset.Height);
        return _camPosition + settings.TargetPosition;
    }
    protected override Quaternion GetRotation()
    {
        if (!settings.IsValid) return Quaternion.identity;
        Vector3 _offset = settings.TargetPosition - CurrentPosition;
        if (_offset == Vector3.zero) return Quaternion.identity;
        Quaternion _lookAt = Quaternion.LookRotation(_offset);
        return settings.SmoothRotation ? Quaternion.RotateTowards(CurrentRotation, _lookAt, Time.deltaTime * settings.RotateSpeed) : _lookAt;
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