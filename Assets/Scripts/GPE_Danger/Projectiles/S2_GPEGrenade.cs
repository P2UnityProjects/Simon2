using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_GPEGrenade : S2_GPEProjectile
{
    [SerializeField] Vector3 spawnLocationOffset = new Vector3(0, 10, 0);
    [SerializeField] Vector3 spawnLocation = Vector3.zero;
    [SerializeField] Vector3 endLocation = Vector3.zero;
    [SerializeField] float explosionRadius = 3;
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
        endLocation = target.position - Vector3.up * 5;
    }

    void FallOnTarget()
    {
        if(!target)
        {
            Destroy(gameObject);
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, endLocation, Time.deltaTime * fallSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<S2_GPEGrenade>()) return;


        Collider[] touchtab = Physics.OverlapSphere(transform.position, explosionRadius, playerLayer);
        Debug.Log($"touchtab size : {touchtab.Length}");
        //if (touchtab.Length == 0) Destroy(this.gameObject);
        for (int i = 0; i < touchtab.Length; i++)
        {
            // if (!_hit) return;
            GameObject _gameO = touchtab[i].transform.gameObject;
            if (!_gameO) return;
            S2_Player _player = _gameO.GetComponent<S2_Player>();
            if (!_player) return;
            _player.GetDamaged();
        }
        Destroy(this.gameObject);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
