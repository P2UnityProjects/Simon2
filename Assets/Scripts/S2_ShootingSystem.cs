using System.Collections.Generic;
using UnityEngine;

public class S2_ShootingSystem : MonoBehaviour
{
	#region Fields & Properties
    bool isShooting = false;
	[SerializeField] float shootingRate = 1;
	[SerializeField] Vector3 spawnLocation = Vector3.zero;
	[SerializeField] S2_GPEProjectile projectileType = null;
	List<S2_GPEProjectile> spawnedProjectiles = new List<S2_GPEProjectile>();
    #endregion

    #region Methods
    private void Start()
    {
        InvokeRepeating("Shoot", .1f, shootingRate);
    }
    void Shoot()
    {
		if (!isShooting) return;
		spawnedProjectiles.Add(Instantiate(projectileType, transform.position + spawnLocation, Quaternion.identity));
        Debug.Log("shoot!");
    }

    public void UpdateShootingStatus(bool _isShooting) => isShooting = _isShooting;
	#endregion
	
}
