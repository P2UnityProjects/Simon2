using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class S2_MovablePlatformBehaviour : MonoBehaviour
{
    public event Action OnStop = null, OnWait = null, OnMove = null;

    [SerializeField] MeshRenderer meshRenderer = null;
    [SerializeField] Color colorStop = Color.red, colorWait = Color.yellow, colorMove = Color.green;
    [SerializeField] float timeStop = 2, timeWait = 1, startOffset = 0;

    public bool IsValid => meshRenderer;

    private void Start()
    {
        Init();
    }
    private void OnDestroy()
    {
        OnStop = null;
        OnWait = null;
        OnMove = null;
    }

    void Init()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        OnStop += () => S2_TimerManager.Instance.AddTimer(timeStop, SetWait);
        OnWait += () => S2_TimerManager.Instance.AddTimer(timeWait, SetMove);

        if (!IsValid) return;
        S2_TimerManager.Instance.AddTimer(startOffset, SetStop);
    }

    public void SetStop()
    {
        SetColor(colorStop);
        OnStop?.Invoke();
    }
    void SetWait()
    {
        SetColor(colorWait);
        OnWait?.Invoke();
    }
    void SetMove()
    {
        SetColor(colorMove);
        OnMove?.Invoke();
    }
    void SetColor(Color _color)
    {
        if (!IsValid) return;
        meshRenderer.material.color = _color;
    }
}