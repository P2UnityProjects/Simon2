using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_CharacterCounter : MonoBehaviour
{
    [SerializeField] LayerMask toCounterLayer = 0;
    [SerializeField] float shieldRadius = 5;

    void DetectDangerGPE()
    {
        bool _hit = Physics.SphereCast(transform.position, shieldRadius, transform.forward, out RaycastHit _hitInfo, 0.1f, toCounterLayer);
        if (!_hit) return;
        GameObject _gameO = _hitInfo.transform.gameObject;
       // S2_GPEProjectile _proj = _gameO as S2_GPEProjectile;

    }

}
