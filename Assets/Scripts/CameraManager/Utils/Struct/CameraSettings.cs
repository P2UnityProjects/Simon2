using System;
using UnityEngine;

[Serializable]
public class CameraSettings
{
    [SerializeField] CameraOffset cameraOffset = new CameraOffset(), cameraLookAtOffset = new CameraOffset();
    [SerializeField] float moveSpeed = 20, rotateSpeed = 200;
    [SerializeField] Camera gameCamera = null;
    [SerializeField] Transform target = null;

    public bool IsValid => gameCamera && target;
    public float MoveSpeed => moveSpeed;
    public float RotateSpeed => rotateSpeed;
    public CameraOffset CameraOffset => cameraOffset;
    public CameraOffset CameraLookAtOffset => cameraLookAtOffset;
    public Camera Camera => gameCamera;
    public Transform Target => target;
}