using System;
using UnityEngine;

[Serializable]
public class CameraOrbitOffset
{
    [SerializeField] float currentAngle, goalAngle, rayon, height;

    public float CurrentAngle { get => currentAngle; set => currentAngle = value; }
    public float GoalAngle { get => goalAngle; set => goalAngle = value; }
    public float Rayon { get => rayon; set => rayon = value; }
    public float Height { get => height; set => height = value; }
}