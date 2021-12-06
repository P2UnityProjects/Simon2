using UnityEngine;

public class S2_KillZone : MonoBehaviour
{
    [SerializeField, Header("Kill Zone - Components :")] Collider killzone = null;

    public bool IsValid => killzone;

    private void OnTriggerEnter(Collider other)
    {
        S2_Player _player = other.GetComponent<S2_Player>();
        if (!_player) return;
        _player.GetDamaged();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red - new Color(0, 0, 0, .8f);
        Gizmos.DrawCube(transform.position, killzone.bounds.size);
    }
}