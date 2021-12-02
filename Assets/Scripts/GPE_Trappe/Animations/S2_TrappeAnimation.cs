using UnityEngine;

public class S2_TrappeAnimation : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField] Animator trappeAnimator = null;

    public bool IsValid => trappeAnimator;

    #endregion

    #region Methods

    public void UpdateContactAnimation()
    {
        if (!IsValid) return;
        trappeAnimator.SetTrigger(S2_TrappeAnimationParameters.ContactParam);
    }
    public void UpdateDropAnimation()
    {
        if (!IsValid) return;
        trappeAnimator.SetTrigger(S2_TrappeAnimationParameters.DropParam);
    }
    public void UpdateResetAnimation()
    {
        if (!IsValid) return;
        trappeAnimator.SetTrigger(S2_TrappeAnimationParameters.ResetParam);
    }

    #endregion
}
