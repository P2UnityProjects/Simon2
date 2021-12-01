using System;

public class S2_Timer
{
    public event Action OnCallBack = null;

    bool isLoop = false;
    float maxTime = 0, currentTime = 0;

    public S2_Timer(float _maxTime, Action _callback, bool _isLoop)
    {
        maxTime = _maxTime;
        OnCallBack = _callback;
        isLoop = _isLoop;
    }

    public bool UpdateTimer(float _deltaTime)
    {
        currentTime += _deltaTime;
        if (currentTime > maxTime)
        {
            currentTime = 0;
            OnCallBack?.Invoke();
            return !isLoop;
        }
        return false;
    }

    public void DestroyTimer()
    {
        OnCallBack = null;
    }
}