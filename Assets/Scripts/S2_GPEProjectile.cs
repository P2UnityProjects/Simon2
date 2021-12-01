using UnityEngine;

public abstract class S2_GPEProjectile : S2_GPE
{
    #region Fields & Properties
    [SerializeField] protected Transform target = null;
    #endregion

    #region Methods
    public void SetTarget(Transform _target) => target = _target;
	#endregion
}
