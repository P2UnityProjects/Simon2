using UnityEngine;

public static class S2_AnimParamsChara 
{
    public const string MOVE_PARAM = "isMoving";
    public const string ATTACK_PARAM = "attack";

    public static readonly int moveParam = Animator.StringToHash(MOVE_PARAM);
    public static readonly int attackParam = Animator.StringToHash(ATTACK_PARAM);
}