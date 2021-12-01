using UnityEngine;

public abstract class S2_Collectible : MonoBehaviour
{
    [SerializeField] protected Collider collectibleCollider = null;


    public bool IsValidCollectible => collectibleCollider;


    virtual protected void Start() => InitCollectible();

    protected abstract void InitCollectible();
    protected abstract void GetCollected();
}
