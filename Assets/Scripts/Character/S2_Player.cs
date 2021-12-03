using UnityEngine;
using System;

[RequireComponent(typeof(S2_CharacterMovement),typeof(S2_CharacterCounter))]
public class S2_Player : MonoBehaviour
{
    public event Action OnDamaged = null;

    [SerializeField] S2_CharacterMovement movement = null;
    [SerializeField] S2_CharacterCounter counter = null;
    [SerializeField] S2_PlayerAnimation playerAnim = null;
    [SerializeField] S2_ActivableUI activableUI = null;

    [SerializeField] S2_Checkpoint checkpoint = null;

    public S2_CharacterMovement GetMovementComponent => movement;
    public S2_CharacterCounter GetCounterComponent => counter;
    public S2_PlayerAnimation PlayerAnim => playerAnim;


    private void Start() => Init();

    void Init()
    {
        movement = GetComponent<S2_CharacterMovement>();
        counter = GetComponent<S2_CharacterCounter>();
      //  counter.OnAttack += playerAnim.UpdateAttackAnimatorParam;

        if (activableUI) activableUI.InitInput();
    }

    public void GetDamaged()
    {
        OnDamaged?.Invoke();
        if (checkpoint)
        {
            movement.Controller.enabled = false;
            transform.position = checkpoint.CheckPointPosition;
            checkpoint.UseCheckPoint();
            movement.Controller.enabled = true;
        }
    }

    public void SetCheckpoint(S2_Checkpoint _checkpoint) => checkpoint = _checkpoint;
}