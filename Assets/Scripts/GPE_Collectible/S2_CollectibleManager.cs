using UnityEngine;
using System;

public class S2_CollectibleManager : S2_Singleton<S2_CollectibleManager>
{
    public event Action<int> OnCollection = null;
    public event Action<int> OnCollectibleTotalSet = null;
    #region Fields&Properties

    [SerializeField, Header("Total Collectible : ")] int totalCollectible = 0;
    [SerializeField, Header("Collectible collected : ")] int collectibleCollected = 0;

    #endregion

    #region Methods

    public void AddCollectible(int _collectible = 1)
    {
        totalCollectible += _collectible;
        OnCollectibleTotalSet?.Invoke(totalCollectible);
    }

    public void Collection(int _collectible = 1)
    {
        collectibleCollected += _collectible;
        OnCollection?.Invoke(collectibleCollected);
    }

    #endregion
}
