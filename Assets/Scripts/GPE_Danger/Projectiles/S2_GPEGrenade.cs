using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_GPEGrenade : S2_GPEProjectile
{
    [SerializeField] Vector3 spawnLocationOffset = new Vector3(0, 10, 0);
    [SerializeField] Vector3 spawnLocation = Vector3.zero;
    [SerializeField] float fallSpeed = 2;
    [SerializeField] LayerMask playerLayer = 0;

    private void Start()
    {
        Init();
    }
    void Update()
    {
        FallOnTarget();
    }

    void Init()
    {
        spawnLocation = target.position + spawnLocationOffset;
        transform.position = spawnLocation;
    }

    void FallOnTarget()
    {
        if(!target)
        {
            Destroy(gameObject);
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * fallSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("tutut");
        
        Destroy(this.gameObject);

    }

   
}
