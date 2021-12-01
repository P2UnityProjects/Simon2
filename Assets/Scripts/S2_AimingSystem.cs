using System;
using UnityEngine;

public class S2_AimingSystem : MonoBehaviour
{
    #region Fields & Properties
    public Action<bool> OnTargetAimed = null;

	[SerializeField] float aimDetectionRate = .1f, aimRange = 10, aimAngle = 90, aimSpeed = 15;
	[SerializeField] LayerMask aimingMask = 0;
    Transform target = null;
    Vector3 initForward = Vector3.zero;

    public Transform Target => target;
    #endregion

    #region Methods
    private void Start() => Init();
    private void Update() => DetectionBehaviour();

    void Init()
    {
        initForward = transform.forward;
    }

    float GetAngle(Vector3 _from, Vector3 _to)
    {
        float _length = Mathf.Pow(_from.sqrMagnitude * _to.sqrMagnitude, 2);
        float _dot = Vector3.Dot(_from, _to);
        float _acos = Mathf.Acos(_dot / _length);
        float _angle = Mathf.Rad2Deg * _acos;

        return _angle;
    }

    void DetectionBehaviour()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, aimRange, aimingMask);
        if (_colliders.Length > 0) //if a collider is detected
        {
            Transform _target = _colliders[0].transform;

            float _angle = GetAngle(initForward, _target.position - transform.position.normalized);

            if (_angle < aimAngle) //and is in detectionAngle
            {
                target = _target;
                AimTarget();
                OnTargetAimed?.Invoke(true);
                return;
            }
        }
        target = null;
        OnTargetAimed?.Invoke(false);
    }
    void AimTarget()
    {
        Vector3 _direction = target.position - transform.position;
        Quaternion _rotation = Quaternion.LookRotation(_direction);
        if (_direction == Vector3.zero) _rotation = Quaternion.identity;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, Time.deltaTime * aimSpeed);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aimRange);
    }
    #endregion

}
