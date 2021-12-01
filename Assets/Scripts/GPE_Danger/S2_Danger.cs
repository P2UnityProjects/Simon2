using UnityEngine;

public abstract class S2_Danger : S2_GPE
{
    #region Fields&Properties

    [SerializeField] protected bool isActive = true;
    [SerializeField] protected float timeBeforeActive = 1;
    [SerializeField] LayerMask playerMask = 0;

    #endregion

    #region Methods

    virtual protected void Start() => Init();

    virtual protected void Init()
    {
        if (!isActive) return;  //To Do
            //TimerManager.Add(SetActive, timeBeforeActive);
    }

    protected void SetActive() => isActive = true;

    #endregion
}
