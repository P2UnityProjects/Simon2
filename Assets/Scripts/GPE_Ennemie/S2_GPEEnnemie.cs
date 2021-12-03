using UnityEngine;

[RequireComponent(typeof(S2_AimingSystem), typeof(S2_ShootingSystem), typeof(Animator))]
public abstract class S2_GPEEnnemie : S2_GPE
{
	#region Fields & Properties
	protected S2_AimingSystem aimingSystem = null;
	protected S2_ShootingSystem shootingSystem = null;
    protected Animator animatorController = null;
    protected Transform target = null;
    protected int life = 1;

    public S2_AimingSystem AimingSystem => aimingSystem;
    public S2_ShootingSystem ShootingSystem => shootingSystem;
    public Transform Target => target;
    #endregion

    #region Methods
    protected void Start() => Init();

    protected virtual void Init()
    {
        aimingSystem = GetComponent<S2_AimingSystem>();
        shootingSystem = GetComponent<S2_ShootingSystem>();
        animatorController = GetComponent<Animator>();

        //aimingSystem.OnTargetAimed += shootingSystem.UpdateShootingStatus;
        aimingSystem.OnTriggerDetectionAnim += TriggerDetectionAnim;
    }
    public void SetTarget(Transform _target) => target = _target;
    protected void TriggerDetectionAnim(bool _isDetecting) => animatorController.SetBool("isDetecting", _isDetecting);
    #endregion
}
