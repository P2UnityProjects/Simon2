using UnityEngine;

[RequireComponent(typeof(S2_MovablePlatformMovement), typeof(S2_MovablePlatformBehaviour))]
public class S2_MovablePlatform : MonoBehaviour
{
    [SerializeField] S2_MovablePlatformMovement movablePlatformMovement = null;
    [SerializeField] S2_MovablePlatformBehaviour movablePlatformBehaviour = null;

    public bool IsValid => movablePlatformMovement && movablePlatformBehaviour;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        movablePlatformMovement = GetComponent<S2_MovablePlatformMovement>();
        movablePlatformBehaviour = GetComponent<S2_MovablePlatformBehaviour>();
        if (!IsValid) return;
        movablePlatformMovement.OnReachGoal += movablePlatformBehaviour.SetStop;
        movablePlatformBehaviour.OnMove += movablePlatformMovement.StartMove;
    }
}