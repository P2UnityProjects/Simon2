using UnityEngine;
using System;

public class ES_Movement : MonoBehaviour
{
    public event Action OnNearTarget = null;
    #region Fields&Properties

    [SerializeField, Header("Movement - Settings :"), Range(.1f, 5)] float collectRange = .2f;
    [SerializeField, Range(1, 100)] float speed = 2;
    [SerializeField, Range(1, 100)] float speedIncrease = 1;

    [SerializeField, Header("Movement - Values :")]
    Transform target = null;


    public bool HaveTarget => target;
    public bool IsNearTarget => HaveTarget ? Vector3.Distance(Position, target.position) < collectRange : false;

    public Vector3 Position => transform.position;

    #endregion

    #region Methods

    private void Update()
    {
        IncreaseSpeed();
        if (IsNearTarget)
            OnNearTarget?.Invoke();
    }

    private void LateUpdate() => MoveToTarget();

    private void OnDestroy()
    {
        OnNearTarget = null;
    }

    public void SetTarget(Transform _target) => target = _target;

    void MoveToTarget()
    {
        if (!HaveTarget) return;
        transform.position = Vector3.MoveTowards(Position, target.position, speed * Time.deltaTime);
    }
    void IncreaseSpeed()
    {
        if (!HaveTarget) return;
        speed += speedIncrease * Time.deltaTime;
    }

    #endregion
}
