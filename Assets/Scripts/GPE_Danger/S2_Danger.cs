using UnityEngine;
using System;

public abstract class S2_Danger : S2_GPE
{
    //public event Action OnHitPlayer = null; //hiden to avoid warning
    #region Fields&Properties

    [SerializeField, Header("GPE Danger - Settings :")] protected bool isActive = true;
    [SerializeField] protected float timeBeforeActive = 1;

    public Vector3 Position => transform.position;

    #endregion

    #region Methods

    virtual protected void Start() => Init();
    virtual protected void OnDestroy()
    {
        // OnHitPlayer = null; //hiden to avoid warning
    }
    virtual protected void OnDrawGizmos()
    {
        Gizmos.color = isActive ? Color.green : Color.red;
        Gizmos.DrawSphere(Position, .2f);
    }

    virtual protected void Init()
    {
        if (!isActive)
            S2_TimerManager.Instance?.AddTimer(timeBeforeActive, SetActive);
    }

    protected void SetActive() => isActive = true;

    #endregion
}
