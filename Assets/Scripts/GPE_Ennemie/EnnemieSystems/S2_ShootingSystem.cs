using System.Collections.Generic;
using UnityEngine;

public class S2_ShootingSystem : S2_EnnemieSystem
{
    #region Fields & Properties
    bool isShooting = false;
	[SerializeField] float shootingRate = 1;
	[SerializeField] Vector3 spawnLocation = Vector3.zero;
	[SerializeField] S2_GPEProjectile projectileType = null;
	List<S2_GPEProjectile> spawnedProjectiles = new List<S2_GPEProjectile>();
    #endregion

    #region Methods
    protected override void Init()
    {
        base.Init();

        InvokeRepeating("Shoot", .1f, shootingRate);
    }

    void Shoot()
    {
        if (!owner || !isShooting || !owner.Target) return;
        S2_GPEProjectile _spawned = Instantiate(projectileType, transform.position + spawnLocation, transform.rotation);
        _spawned.SetTarget(owner.Target);
        spawnedProjectiles.Add(_spawned);
        Debug.Log("shoot!");
    }

    public void UpdateShootingStatus(bool _isShooting) => isShooting = _isShooting;
	#endregion
}
