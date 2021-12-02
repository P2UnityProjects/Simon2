using System;
using UnityEngine;

[Serializable]
public class CameraOrbitSettings
{
    [SerializeField] bool smoothMove, smoothRotation;
    [SerializeField] float moveSpeed, rotateSpeed;
    [SerializeField] CameraOrbitOffset cameraOrbitOffset;
    [SerializeField] Transform target;

    public bool IsValid => target;
    public bool SmoothMove { get => smoothMove; set => smoothMove = value; }
    public bool SmoothRotation { get => smoothRotation; set => smoothRotation = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float RotateSpeed { get => rotateSpeed; set => rotateSpeed = value; }
    //public float CurrentAngle { get => cameraOrbitOffset.CurrentAngle; set => cameraOrbitOffset.CurrentAngle = value; }
    //public float GoalAngle { get => cameraOrbitOffset.GoalAngle; set => cameraOrbitOffset.GoalAngle = value; }
    //public float Rayon { get => cameraOrbitOffset.Rayon; set => cameraOrbitOffset.Rayon = value; }
   // public float Height { get => cameraOrbitOffset.Height; set => cameraOrbitOffset.Height = value; }
    public Vector3 TargetPosition => target.position;
    public Quaternion TargetRotation => target.rotation;
    public CameraOrbitOffset CameraOrbitOffset => cameraOrbitOffset;
    public Transform Target { get => target; set => target = value; }
}