using UnityEngine;

public class EnergySphere : S2_Collectible
{
    #region Fields&Properties

    [SerializeField, Header("EnergySphere - Components :")] ES_Movement movement = null;

    bool collected = false;

    public ES_Movement Movement => movement;

    public bool IsValid => IsValidCollectible && movement;

    #endregion

    #region Methods

    protected override void InitCollectible()
    {
        if (!IsValid) return;
        movement.OnNearTarget += GetCollected;
        S2_CollectibleManager.Instance?.AddCollectible();
    }
    protected override void GetCollected()
    {
        if (!IsValid || collected) return;
        collected = true;
        S2_CollectibleManager.Instance?.Collection();
        Destroy(gameObject, .1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        S2_Player _player = other.GetComponent<S2_Player>();
        if (!_player) return;
        movement.SetTarget(_player.transform);
    }

    #endregion

}
