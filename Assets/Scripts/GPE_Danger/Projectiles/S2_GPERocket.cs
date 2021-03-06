using UnityEngine;

public class S2_GPERocket : S2_GPEProjectile
{
    #region Fields & Properties
    [SerializeField] float moveSpeed = 10, rotateSpeed = 1000;

    public bool IsValid => target;
    #endregion

    #region Methods
    private void Update()
    {
        MoveToTarget();
        RotateToTarget();
    }

    void MoveToTarget() 
    {
        if (!IsValid) return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
    }
    void RotateToTarget()
    {
        if (!IsValid) return;
        Vector3 _direction = target.position - transform.position;

        Quaternion _rotation = Quaternion.identity;
        if (_direction != Vector3.zero)
            _rotation = Quaternion.LookRotation(_direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, Time.deltaTime * rotateSpeed);
    }
    #endregion

}
