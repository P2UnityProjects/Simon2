using UnityEngine;

public class S2_GPERocket : S2_GPEProjectile
{
    #region Fields & Properties
    [SerializeField] float moveSpeed = 10, rotateSpeed = 1000;
    [SerializeField] bool isCountered = false;

    #endregion

    #region Methods
    public void SetIsCountered(bool _status) => isCountered = _status;
    private void Update()
    {
        MoveToTarget();
        RotateToTarget();
    }

    void MoveToTarget()
    {
        if (!target) return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
    }
    void RotateToTarget()
    {
        if (!target) return;
        Vector3 _direction = target.position - transform.position;

        Quaternion _rotation = Quaternion.identity;
        if (_direction != Vector3.zero)
            _rotation = Quaternion.LookRotation(_direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, Time.deltaTime * rotateSpeed);
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triger Enter");
        if(!isCountered)
        {
            GameObject _go = other.transform.gameObject;
            if (!_go) return;
            S2_Player _player = _go.GetComponent<S2_Player>();
            if (!_player) return;
            _player.GetDamaged();
            Destroy(this.gameObject);
        }
       else if (isCountered)
        {
            GameObject _go = other.transform.gameObject;
            if (!_go) return;
            S2_GPETurret _turret = _go.GetComponent<S2_GPETurret>();
            if (!_turret) return;


            Destroy(_turret);
        }
    }

}
