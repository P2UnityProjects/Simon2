using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class S2_CameraTriggerBox : MonoBehaviour
{
    public event Action<CameraOrbitSettings> OnTrigger = null;

    [SerializeField] BoxCollider boxCollider = null;
    [SerializeField] S2_CameraOrbitTriggerLinker cameraOrbitTriggerLinker = null;
    [SerializeField] bool setSmoothMove = false, setSmoothRotate = false, setCurrentAngle = false, setGoalAngle = false, setTarget = false, setHeight = false,
                          setRayon = false, setMoveSpeed = false, setRotateSpeed = false;
    [SerializeField] float debugLenght = 2;
    [SerializeField] CameraOrbitSettings settings = new CameraOrbitSettings();

    public bool IsValid => boxCollider && cameraOrbitTriggerLinker;
    public Vector3 CurentPosition => transform.position;

    private void Start()
    {
        Init();
    }
    private void OnDestroy()
    {
        OnTrigger = null;
    }
    private void OnDrawGizmos()
    {
        if (!boxCollider) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(CurentPosition, boxCollider.size);

        Vector3 _camPosition = S2_CameraAngleCalculator.GetAnglePosition(settings.CameraOrbitOffset.CurrentAngle, settings.CameraOrbitOffset.Rayon, settings.CameraOrbitOffset.Height);
        Vector3 _debugPosition = _camPosition.normalized * debugLenght;
        Gizmos.DrawLine(CurentPosition, _debugPosition + CurentPosition);
    }
    private void OnTriggerEnter(Collider other)
    {
        S2_Player _player = other.GetComponent<S2_Player>();
        if (!_player || !IsValid) return;
        OnTrigger?.Invoke(settings);
    }

    void Init()
    {
        boxCollider = GetComponent<BoxCollider>();
        if (!boxCollider) return;
        boxCollider.isTrigger = true;
        S2_World.Instance.TimerManager.AddTimer(0.1f, InitCameraOrbitTrigger);
    }
    void InitCameraOrbitTrigger()
    {
        S2_CameraBehaviour _cameraBehaviour = S2_World.Instance.CameraManager.GetFirstCamera();
        if (!_cameraBehaviour) return;
        S2_CameraOrbit _camera = (S2_CameraOrbit)_cameraBehaviour;
        if (!_camera) return;
        cameraOrbitTriggerLinker = _camera.CameraOrbitTriggerLinker;
        if (!IsValid) return;

        if (setSmoothMove)
        {
            OnTrigger += cameraOrbitTriggerLinker.SetSmoothMovement;
        }
        if(setSmoothRotate)
        {
            OnTrigger += cameraOrbitTriggerLinker.SetSmoothRotation;
        }
        if(setGoalAngle)
        {
            OnTrigger += cameraOrbitTriggerLinker.SetGoalAngle;
        }
        if(setTarget)
        {
            OnTrigger += cameraOrbitTriggerLinker.SetTarget;
        }
        if(setHeight)
        {
            OnTrigger += cameraOrbitTriggerLinker.SetHeight;
        }
        if(setRayon)
        {
            OnTrigger += cameraOrbitTriggerLinker.SetRayon;
        }
        if(setMoveSpeed)
        {
            OnTrigger += cameraOrbitTriggerLinker.SetMoveSpeed;
        }
        if(setRotateSpeed)
        {
            OnTrigger += cameraOrbitTriggerLinker.SetRotateSpeed;
        }
        if(setCurrentAngle)
        {
            OnTrigger += cameraOrbitTriggerLinker.SetCurrentAngle;
        }
    }
}