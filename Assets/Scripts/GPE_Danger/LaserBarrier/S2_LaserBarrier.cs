using UnityEngine;

public class S2_LaserBarrier : S2_Danger
{
    #region Fields&Properties

    [SerializeField, Header("Laser Barrier - Components :")] Collider laserCollider = null;

    [SerializeField, Header("Laser Barrier - Settings :"), Range(.1f, 20)] float laserActiveTime = 2;
    [SerializeField, Range(.1f, 20)] float laserInactiveTime = 2;

    [SerializeField, Header("Laser Barrier - Values :")] bool laserActive = true;
    [SerializeField] float laserTime = 0;

    public bool IsValid => laserCollider;

    #endregion

    #region Methods

    private void Update()
    {
        if (!isActive ||!IsValid) return;
        UpdateLaserBarrierState(Time.deltaTime);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = (laserActive && isActive ? Color.red : Color.white) - new Color(0, 0, 0, .8f);
        Gizmos.DrawCube(laserCollider.bounds.center, laserCollider.bounds.size);
    }

    void UpdateLaserBarrierState(float _deltaTime)
    {
        laserTime += _deltaTime;
        if (laserTime > (laserActive ? laserActiveTime : laserInactiveTime))
        {
            laserTime = 0;
            laserActive = !laserActive;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!laserActive || !isActive) return;
        S2_Player _player = other.GetComponent<S2_Player>();
        if (!_player) return;
        Debug.Log("Laser Barrier : Detect player !");   //TODO Player interaction
    }


    #endregion
}
