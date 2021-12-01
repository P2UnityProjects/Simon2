using UnityEngine;

public class S2_CrusherAnimation : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField] Animator crusherAnimator = null;

    public bool IsValid => crusherAnimator;

    #endregion

    #region Methods

    public void UpdateCrushAnimation()
    {
        if (!IsValid) return;
        crusherAnimator.SetTrigger(S2_CrusherAnimationParameters.CrushParam);
    }
    public void UpdateRecoverAnimation()
    {
        if (!IsValid) return;
        crusherAnimator.SetTrigger(S2_CrusherAnimationParameters.RecoverParam);
    }

    #endregion
}
