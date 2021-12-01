using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(S2_GPEEnnemie))]
public class S2_ShootingSystem : MonoBehaviour
{
    #region Fields & Properties
    [SerializeField] S2_GPEEnnemie owner = null;

    bool isShooting = false;
	[SerializeField] float shootingRate = 1;
	[SerializeField] Vector3 spawnLocation = Vector3.zero;
	[SerializeField] S2_GPEProjectile projectileType = null;
	List<S2_GPEProjectile> spawnedProjectiles = new List<S2_GPEProjectile>();
    #endregion

    #region Methods
    private void Start() => Init();

    void Init()
    {
        owner = GetComponent<S2_GPEEnnemie>();

        InvokeRepeating("Shoot", .1f, shootingRate);
    }

    void Shoot()
    {
        if (!owner) return;
        /*if (!isShooting) return;*/ //! TODO: isShooting is always false (UpdateShootingStatus doesn't get invoked)
        S2_GPEProjectile _spawned = Instantiate(projectileType, transform.position + spawnLocation, transform.rotation);
        _spawned.SetTarget(owner.Target);
        spawnedProjectiles.Add(_spawned);
        Debug.Log("shoot!");
    }

    public void UpdateShootingStatus(bool _isShooting) => isShooting = _isShooting;
	#endregion
}
