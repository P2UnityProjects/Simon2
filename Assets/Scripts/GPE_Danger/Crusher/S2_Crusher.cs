using UnityEngine;
using System;

public class S2_Crusher : S2_Danger
{
    public event Action OnCrush = null;
    public event Action OnRecover = null;

    #region Fields&Properties

    [SerializeField, Header("Crusher - Components :")] Collider crushCollider = null;
    [SerializeField] S2_CrusherAnimation crusherAnimation = null;

    [SerializeField, Header("Crusher - Settings :")] float timeBeforeCrush = 2;
    [SerializeField] float timeBeforeRecover = 1;

    [SerializeField, Header("Crusher - Values :")] bool isCrushing = false;
    [SerializeField] float crushTime = 0;
    public bool IsValid => crushCollider && crusherAnimation;

    #endregion

    #region Methods
    protected override void Start()
    {
        base.Start();
        if (!IsValid) return;
        OnCrush += crusherAnimation.UpdateCrushAnimation;
        OnRecover += crusherAnimation.UpdateRecoverAnimation;
    }
    private void Update()
    {
        if (!isActive || !IsValid) return;
        UpdateCrushState(Time.deltaTime);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = (isCrushing ? Color.red : Color.white) - new Color(0, 0, 0, .8f);
        Gizmos.DrawCube(crushCollider.bounds.center, crushCollider.bounds.size);
    }

    void UpdateCrushState(float _deltaTime)
    {
        crushTime += _deltaTime;
        if (crushTime > (isCrushing ? timeBeforeRecover : timeBeforeCrush))
        {
            crushTime = 0;
            isCrushing = !isCrushing;
            if (isCrushing)
                OnCrush?.Invoke();
            else
                OnRecover?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isCrushing) return;
        Debug.Log("Trigger");
        //TODO Player
    }

    #endregion
}
