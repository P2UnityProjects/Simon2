using UnityEngine;

public static class S2_CameraAngleCalculator
{
    public static Vector3 GetAnglePosition(float _angle, float _rayon, float _height)
    {
        float _rad = Mathf.Deg2Rad * _angle;
        float _x = Mathf.Cos(_rad) * _rayon;
        float _y = _height;
        float _z = Mathf.Sin(_rad) * _rayon;
        return new Vector3(_x, _y, _z);
    }
}