using UnityEngine;

public static class S2_TrappeAnimationParameters 
{
    public const string CONTACT_PARAM = "contact";
    public const string DROP_PARAM = "drop";
    public const string RESET_PARAM = "reset";

    public static readonly int ContactParam = Animator.StringToHash(CONTACT_PARAM);
    public static readonly int DropParam = Animator.StringToHash(DROP_PARAM);
    public static readonly int ResetParam = Animator.StringToHash(RESET_PARAM);
}
