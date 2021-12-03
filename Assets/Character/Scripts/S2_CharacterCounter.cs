using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_CharacterCounter : MonoBehaviour
{
    public event Action OnAttack = null;

    [SerializeField] LayerMask toCounterLayer = 0;
    [SerializeField] float shieldRadius = 5;

    private void Start()
    {
        S2_InputManager.Instance.BindAction(S2_ButtonEvent.SHIELD, DetectDangerGPE);
    }
    void DetectDangerGPE(bool _bool)
    {
        OnAttack?.Invoke();
        //bool _hit = false;
        if (_bool)
        {
       
            //_hit = Physics.SphereCast(transform.position, shieldRadius, transform.forward, out RaycastHit _hitInfo, 0.1f, toCounterLayer);
            Collider[] touchtab = Physics.OverlapSphere(transform.position, shieldRadius, toCounterLayer);
            if (touchtab.Length == 0) return;
            for (int i = 0; i < touchtab.Length; i++)
            {
         
                // if (!_hit) return;
                GameObject _gameO = touchtab[i].transform.gameObject;
                if (!_gameO) return;
                  S2_GPERocket _proj = _gameO.GetComponent<S2_GPERocket>();
                if (!_proj) return;
                _proj.SetTarget(_proj.GetLauncher().transform);
                _proj.SetIsCountered(true);

           

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, shieldRadius);
    }

    private void OnDestroy()
    {
        S2_InputManager.Instance.UnBindAction(S2_ButtonEvent.SHIELD, DetectDangerGPE);
    }

}
