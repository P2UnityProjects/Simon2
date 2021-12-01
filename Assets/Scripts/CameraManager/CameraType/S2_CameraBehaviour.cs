using System;
using UnityEngine;

public abstract class S2_CameraBehaviour : MonoBehaviour, IManagedItem<string>
{
    public event Action OnUpdate = null;

    [SerializeField] string id = "Camera";
    [SerializeField] CameraSettings settings = new CameraSettings();

    public string ID => id;
    public CameraSettings Settings => settings;
    public Vector3 CurrentPosition => transform.position;
    public Quaternion CurrentRotation => transform.rotation;

    protected virtual void Start()
    {
        OnUpdate += () =>
        {
            MoveTo();
            RotateTo();
        };
    }
    protected virtual void LateUpdate() => OnUpdate?.Invoke();

    protected abstract void MoveTo();
    protected abstract void RotateTo();
    protected abstract Vector3 GetPosition();
    protected abstract Quaternion GetRotation();
}