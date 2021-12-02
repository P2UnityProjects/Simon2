using UnityEngine;
using System;
public class GPE_Trappe : MonoBehaviour
{
    public event Action OnContact = null;
    public event Action OnDrop = null;
    public event Action OnReset = null;

    #region Fields&Properties

    [SerializeField, Header("Trappe - Components")] Collider trappeCollider = null;
    [SerializeField] Collider trappeCollision = null;
    [SerializeField] S2_TrappeAnimation trappeAnimation = null;
    [SerializeField] SkinnedMeshRenderer mesh = null;

    [SerializeField, Header("Trappe - Settings :"), Range(.1f, 10)] float timeBeforeDrop = 2;
    [SerializeField, Range(.1f, 10)] float timeBeforeReset = 3;

    [SerializeField] Color normalColor = Color.white;
    [SerializeField] Color contactColor = Color.yellow;
    [SerializeField] Color dropColor = Color.red;

    float trappeTime = 0;
    bool contact = false;
    bool drop = false;

    public bool IsValid => trappeCollider && trappeCollision && trappeAnimation && mesh;

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
        if (!drop || !IsValid) return;
        trappeTime += Time.deltaTime;
        if (trappeTime > timeBeforeReset)
            TrappeReset();
    }

    void TrappeDrop()
    {
        if (!IsValid) return;
        trappeCollision.enabled = false;
        trappeTime = 0;
        drop = true;
        OnDrop?.Invoke();
        SetTrappeColor(dropColor);
    }

    void TrappeReset()
    {
        if (!IsValid) return;
        trappeCollision.enabled = true;
        trappeTime = 0;
        contact = false;
        drop = false;
        OnReset?.Invoke();
        SetTrappeColor(normalColor);
    }

    void SetTrappeColor(Color _color)
    {
        if (!IsValid) return;
        mesh.material.color = _color;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!IsValid || contact) return;
        S2_Player _player = other.GetComponent<S2_Player>();
        if (!_player) return;
        SetTrappeColor(contactColor);
        contact = true;
        OnContact?.Invoke();
        Debug.Log("Trappe : Detect player !");   //TODO Player interaction
    }

    #endregion
}
