using UnityEngine;

public class S2_ActivableUI : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField, Header("Activable UI - Components :")] S2_DeathCountUI deathCountUI = null;
    [SerializeField] S2_CollectibleCountUI collectibleCountUI = null;

    [SerializeField, Header("Activable UI - Settings :")] float timeBeforeHide = 3;

    S2_Timer timerUI = null;

    public bool IsValid => collectibleCountUI && deathCountUI;

    #endregion

    #region Methods

    private void Start()
    {
        if (!IsValid) return;
        timerUI = new S2_Timer(timeBeforeHide, HideUI, false);
        S2_TimerManager.Instance.AddTimer(timerUI);
    }

    public void InitInput()
    {
        if (!IsValid) return;
        S2_InputManager.Instance?.BindAction(S2_ButtonEvent.ACTIVABLE_UI, ShowUI);
    }


    void ShowUI(bool _action)
    {
        if (!_action) return;

        deathCountUI.gameObject.SetActive(true);
        collectibleCountUI.gameObject.SetActive(true);
        if (timerUI != null)
            S2_TimerManager.Instance.RemoveTimer(timerUI);

        timerUI = new S2_Timer(timeBeforeHide, HideUI, false);

        S2_TimerManager.Instance.AddTimer(timerUI);
    }

    void HideUI()
    {
        deathCountUI.gameObject.SetActive(false);
        collectibleCountUI.gameObject.SetActive(false);
    }
    #endregion
}
