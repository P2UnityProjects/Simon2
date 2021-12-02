using UnityEngine;

public class S2_Checkpoint : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField] Collider checkpointCollider = null;

    public bool IsValid => checkpointCollider;

    #endregion

    #region Methods

    private void OnTriggerEnter(Collider other)
    {
        S2_Player _player = other.GetComponent<S2_Player>();
        if (!_player) return;

    }

    #endregion
}
