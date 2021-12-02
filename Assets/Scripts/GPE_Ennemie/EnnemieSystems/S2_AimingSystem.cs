using System;
using UnityEngine;

public class S2_AimingSystem : S2_EnnemieSystem
{
    #region Fields & Properties
    public event Action<bool> OnTargetAimed = null;

    [SerializeField] float aimDetectionRate = .1f, aimRange = 10, aimAngle = 90, aimSpeed = 15;
	[SerializeField] LayerMask aimingMask = 0;
    Vector3 initForward = Vector3.zero;
    #endregion

    #region Methods
    private void Update() => DetectionBehaviour();

    protected override void Init()
    {
        base.Init();

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
        if (!owner) return;

        Collider[] _colliders = Physics.OverlapSphere(transform.position, aimRange, aimingMask);
        if (_colliders.Length > 0)
        {
            Transform _target = _colliders[0].transform;

            float _angle = GetAngle(initForward, _target.position - transform.position.normalized);

           // Debug.Log(_angle); //! angle stays at 90°

            if (_angle < aimAngle)
            {

                owner.SetTarget(_target);
                AimTarget();
                owner.ShootingSystem.UpdateShootingStatus(true);
                return;
            }
        }
        owner.SetTarget(null);
        owner.ShootingSystem.UpdateShootingStatus(false);
    }
    void AimTarget()
    {
        Vector3 _direction = owner.Target.position - transform.position;
        Quaternion _rotation = Quaternion.LookRotation(_direction);
        if (_direction == Vector3.zero) _rotation = Quaternion.identity;
        Quaternion _finalRotation = Quaternion.RotateTowards(transform.rotation, _rotation, Time.deltaTime * aimSpeed);

        transform.rotation = new Quaternion(transform.rotation.x, _finalRotation.y, transform.rotation.z, transform.rotation.w);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aimRange);
    }
    #endregion

}
