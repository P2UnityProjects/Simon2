using UnityEngine;

public static class S2_CrusherAnimationParameters
{
    public const string CRUSH_PARAM = "crush";
    public const string RECOVER_PARAM = "recover";

    public static readonly int CrushParam = Animator.StringToHash(CRUSH_PARAM);
    public static readonly int RecoverParam = Animator.StringToHash(RECOVER_PARAM);
}
