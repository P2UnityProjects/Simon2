using UnityEngine;

public abstract class S2_GPEProjectile : S2_GPE
{
    #region Fields & Properties
    protected Transform target = null;
    #endregion

    #region Methods
    public void SetTarget(Transform _target) => target = _target;

    protected virtual void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
    #endregion
}
