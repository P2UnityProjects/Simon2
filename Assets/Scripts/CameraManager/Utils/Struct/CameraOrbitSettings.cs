using System;
using UnityEngine;

[Serializable]
public class CameraOrbitSettings
{
    [SerializeField] bool smoothMove = false, smoothRotation = false;
    [SerializeField] float moveSpeed = 0, rotateSpeed = 0;
    [SerializeField] CameraOrbitOffset cameraOrbitOffset = new CameraOrbitOffset();
    [SerializeField] Transform target = null;

    public bool IsValid => target;
    public bool SmoothMove { get => smoothMove; set => smoothMove = value; }
    public bool SmoothRotation { get => smoothRotation; set => smoothRotation = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float RotateSpeed { get => rotateSpeed; set => rotateSpeed = value; }
    public Vector3 TargetPosition => target.position;
    public Quaternion TargetRotation => target.rotation;
    public CameraOrbitOffset CameraOrbitOffset => cameraOrbitOffset;
    public Transform Target { get => target; set => target = value; }
}