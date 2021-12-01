using UnityEngine;

[RequireComponent(typeof(S2_AimingSystem), typeof(S2_ShootingSystem))]
public abstract class S2_GPEEnnemie : S2_GPE
{
	#region Fields & Properties
	S2_AimingSystem aimingSystem = null;
	S2_ShootingSystem shootingSystem = null;
    int life = 1;

    public S2_AimingSystem AimingSystem => aimingSystem;
    public S2_ShootingSystem ShootingSystem => shootingSystem;
    #endregion

    #region Methods
    protected void Start()
    {
        Init();
    }
    protected void Init()
    {
        aimingSystem = GetComponent<S2_AimingSystem>();
        shootingSystem = GetComponent<S2_ShootingSystem>();

        aimingSystem.OnTargetAimed += shootingSystem.UpdateShootingStatus;
    }
    #endregion
}
