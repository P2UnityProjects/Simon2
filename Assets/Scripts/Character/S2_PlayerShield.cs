using UnityEngine;

public class S2_PlayerShield : MonoBehaviour
{
    [SerializeField] float shieldTime = 0.5f, currentTime = 0;
    [SerializeField] Vector3 currentShieldScale = Vector3.one, shieldMaxScale = new Vector3(3, 3, 3);

    private void OnEnable()
    {
        S2_World.Instance.TimerManager.AddTimer(shieldTime, SetInactive);
    }
    private void Update()
    {
        UpdateTimer();
        ScaleUpShield();
    }
    private void OnDisable()
    {
        currentTime = 0;
    }

    void ScaleUpShield()
    {
        transform.localScale = Vector3.MoveTowards(currentShieldScale, shieldMaxScale, currentTime);
    }
    void UpdateTimer()
    {
        currentTime += Time.deltaTime;
    }
    public void SetActive()
    {
        gameObject.SetActive(true);
    }
    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}