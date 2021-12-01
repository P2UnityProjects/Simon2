using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class S2_Tapis : MonoBehaviour
{
    [SerializeField] S2_Player player = null;
    [SerializeField] float moveSpeed = 20;

    public bool IsValid => player;

    private void Update() => MovePlayer();
    private void OnTriggerEnter(Collider other)
    {
        S2_Player _player = other.GetComponent<S2_Player>();
        if (!_player) return;
        player = _player;
    }
    private void OnTriggerExit(Collider other)
    {
        S2_Player _player = other.GetComponent<S2_Player>();
        if (!_player) return;
        player = null;
    }

    void MovePlayer()
    {
        if (!IsValid) return;
        Vector3 _moveOffset = transform.forward * Time.deltaTime * moveSpeed;
        player.transform.position += _moveOffset;
    }
}