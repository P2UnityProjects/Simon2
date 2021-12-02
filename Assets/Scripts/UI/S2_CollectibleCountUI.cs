using UnityEngine;
using UnityEngine.UI;
using System;

public class S2_CollectibleCountUI : MonoBehaviour
{
    public event Action OnUIUpdate = null;
    #region Fields&Properties

    [SerializeField, Header("UI - Components :")] Text collectibleText = null;


    [SerializeField] int currentCollectible = 0;
    [SerializeField] int maxCollectible = 0;

    public bool IsValid => collectibleText;

    #endregion

    #region Methods

    private void Start() => InitCollectibleUI();

    void InitCollectibleUI()
    {
        if (!IsValid) return;
        OnUIUpdate += UpdateUI;
        S2_CollectibleManager.Instance.OnCollectibleTotalSet += UpdateMaxCollectible;
        S2_CollectibleManager.Instance.OnCollection += UpdateCurrentCollectible;
    }

    void UpdateMaxCollectible(int _maxCollectible)
    {
        maxCollectible = _maxCollectible;
        OnUIUpdate?.Invoke();
    }
    void UpdateCurrentCollectible(int _collectible)
    {
        currentCollectible = _collectible;
        OnUIUpdate?.Invoke();
    }

    void UpdateUI()
    {
        if (!IsValid) return;
        collectibleText.text = $"{currentCollectible} / {maxCollectible}";
    }
    #endregion
}
