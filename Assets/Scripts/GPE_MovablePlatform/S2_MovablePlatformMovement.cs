using System;
using UnityEngine;

public class S2_MovablePlatformMovement : MonoBehaviour
{
    public event Action OnReachGoal = null;

    [SerializeField] Transform target = null;
    [SerializeField] Vector3 startPosition = Vector3.zero;
    [SerializeField] float moveSpeed = 20, goalDist = 0.1f;
    [SerializeField] bool moveToGoal = true, isMoving = false;
    [SerializeField] S2_Player player = null;

    public bool IsValid => target;
    public Vector3 CurrentPosition => transform.position;
    public Vector3 TargetPosition => moveToGoal ? target.position : startPosition;

    private void Start() => Init();
    private void Update() => Move();
    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<S2_Player>();
        if (!player) return;
        player.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        player = other.GetComponent<S2_Player>();
        if (!player) return;
        Transform _playerTransform = player.transform;
        Vector3 _offset = _playerTransform.position;
        gameObject.transform.DetachChildren();
        _playerTransform.position = _offset;
    }
    private void OnDestroy() => OnReachGoal = null;
    private void OnDrawGizmos()
    {
        if (!IsValid) return;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(CurrentPosition, TargetPosition);
    }

    void Init()
    {
        startPosition = transform.position;
    }
    public void StartMove()
    {
        isMoving = true;
    }
    void Move()
    {
        if (!isMoving) return;
        Vector3 _position = Vector3.MoveTowards(CurrentPosition, TargetPosition, moveSpeed * Time.deltaTime);
        transform.position = _position;
        CheckDistance();
    }
    void CheckDistance()
    {
        if (Vector3.Distance(CurrentPosition, TargetPosition) < goalDist)
        {
            isMoving = false;
            moveToGoal = !moveToGoal;
            OnReachGoal?.Invoke();
        }
    }
}