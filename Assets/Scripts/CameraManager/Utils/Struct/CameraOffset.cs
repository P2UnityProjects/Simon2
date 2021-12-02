using System;
using UnityEngine;

[Serializable]
public struct CameraOffset
{
    [SerializeField] bool isLocal;
    [SerializeField] float xOffset, yOffset, zOffset;

    public bool IsLocal => isLocal;
    public Vector3 Offset => new Vector3(xOffset, yOffset, zOffset);

    public Vector3 GetOffset(Transform _target)
    {
        Vector3 _position = isLocal ? GetLocalOffset(_target) : GetWorldOffset();
        return _position + _target.position;
    }

    Vector3 GetLocalOffset(Transform _target)
    {
        return (xOffset * _target.right) + (yOffset * _target.up) + (zOffset * _target.forward);
    }
    Vector3 GetWorldOffset()
    {
        return Offset;
    }
}