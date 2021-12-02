using UnityEngine;
[RequireComponent(typeof(S2_CharacterMovement),typeof(S2_CharacterCounter))]
public class S2_Player : MonoBehaviour
{
    [SerializeField] S2_CharacterMovement movement = null;
    [SerializeField] S2_CharacterCounter counter = null;

    public S2_CharacterMovement GetMovementComponent => movement;
    public S2_CharacterCounter GetCounterComponent => counter;
    private void Start()
    {
        Init();
    }

    void Init()
    {
        movement = GetComponent<S2_CharacterMovement>();
        counter = GetComponent<S2_CharacterCounter>();
    }
}