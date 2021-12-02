using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator = null;
    public bool IsValid => playerAnimator;

    public void UpdateAttackAnimatorParam(bool _bool)
    {
        if (!IsValid) return;
        playerAnimator.SetTrigger(S2_AnimParamsChara.ATTACK_PARAM);
    }
}
