using UnityEngine;
using UnityEngine.UI;

public class S2_DeathCountUI : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField, Header("UI - Components")] Text deathText = null;
    [SerializeField, Header("Death Count UI - Values :")] int deathCount = 0;

    public bool IsValid => deathText;

    #endregion

    #region Methods

    private void Start() => InitDeathUI();

    void InitDeathUI()
    {
        if (!IsValid) return;
        S2_World.Instance.Player.OnDamaged += AddDeath;
    }

    public void AddDeath()
    {
        deathCount++;
        if (!IsValid) return;
        deathText.text = $"{deathCount}";
    }

    #endregion
}
