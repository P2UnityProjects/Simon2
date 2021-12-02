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
        S2_GPERocket _rocket = Cast<S2_GPERocket>(_hitInfo.transform.gameObject)

    }

}
