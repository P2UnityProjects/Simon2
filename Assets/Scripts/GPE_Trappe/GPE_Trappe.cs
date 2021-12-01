using UnityEngine;
using System;
public class GPE_Trappe : MonoBehaviour
{
    public event Action OnContact = null;
    public event Action OnDrop = null;
    public event Action OnReset = null;

    #region Fields&Properties

    [SerializeField, Header("Trappe - Components")] Collider trappeCollider = null;
    [SerializeField] S2_TrappeAnimation trappeAnimation = null;

    [SerializeField, Header("Trappe - Settings :"), Range(.1f, 10)] float timeBeforeDrop = 2;
    [SerializeField, Range(.1f, 10)] float timeBeforeReset = 3;


    float trappeTime = 0;
    bool contact = false;
    bool drop = false;

    public bool IsValid => trappeCollider && trappeAnimation;

    #endregion

    #region Methods
    private void Start() => InitTrappe();
    private void Update()
    {
        if (!IsValid) return;
        UpdateTrappeDrop();
    }

    void InitTrappe()
    {
        if (!IsValid) return;
        OnContact += trappeAnimation.UpdateContactAnimation;
        OnDrop += trappeAnimation.UpdateDropAnimation;
        OnReset += trappeAnimation.UpdateResetAnimation;
    }

    void UpdateTrappeDrop()
    {
        if (!contact) return;
        UpdateDrop();
        UpdateReset();
    }

    void UpdateDrop()
    {
        if (drop) return;
        trappeTime += Time.deltaTime;
        if (trappeTime > timeBeforeDrop)
            TrappeDrop();
    }
    void UpdateReset()
    {
        if (!drop) return;
        trappeTime += Time.deltaTime;
        if (trappeTime > timeBeforeReset)
            TrappeReset();
    }

    void TrappeDrop()
    {
        trappeTime = 0;
        drop = true;
        OnDrop?.Invoke();
    }

    void TrappeReset()
    {
        trappeTime = 0;
        contact = false;
        drop = false;
        OnReset?.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!IsValid || contact) return;
        contact = true;
        OnContact?.Invoke();
    }

    #endregion
}
