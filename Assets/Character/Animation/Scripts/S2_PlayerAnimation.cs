using UnityEngine;

public class S2_PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator = null;
    public bool IsValid => playerAnimator;

    public void UpdateAttackAnimatorParam()
    {
        if (!IsValid) return;
        playerAnimator.SetTrigger(S2_AnimParamsChara.ATTACK_PARAM);
    }
    public void UpdateIsMovingAnimatorParam(bool _state)
    {
        if (!IsValid) return;
        playerAnimator.SetBool(S2_AnimParamsChara.MOVE_PARAM, _state);
    }
}
