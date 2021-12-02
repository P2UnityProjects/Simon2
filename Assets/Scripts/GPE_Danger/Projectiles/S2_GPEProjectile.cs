using UnityEngine;

public abstract class S2_GPEProjectile : S2_GPE
{
    #region Fields & Properties
    protected Transform target = null;
    protected GameObject launcher = null;
    #endregion

    #region Methods
    public void SetLauncher(GameObject _launcher) => launcher = _launcher;
    public GameObject GetLauncher() => launcher;
    public void SetTarget(Transform _target) => target = _target;
	#endregion
}
