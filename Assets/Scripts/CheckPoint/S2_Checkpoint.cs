using UnityEngine;

public class S2_Checkpoint : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField] Collider checkpointCollider = null;

    public bool IsValid => checkpointCollider;

    public Vector3 CheckPointPosition => transform.position;

    #endregion

    #region Methods

    public void UseCheckPoint()
    {
        //LastCameraOffset
    }
    


    private void OnTriggerEnter(Collider other)
    {
        S2_Player _player = other.GetComponent<S2_Player>();
        if (!_player) return;
        _player.SetCheckpoint(this);
    }

    #endregion
}
