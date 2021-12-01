using System;
using System.Collections.Generic;
using UnityEngine;

public class S2_TimerManager : S2_Singleton<S2_TimerManager>
{
    List<S2_Timer> timers = new List<S2_Timer>();

    private void Update() => UpdateTimer();

    void UpdateTimer()
    {
        float _deltaTime = Time.deltaTime;
        for (int i = 0; i < timers.Count; i++)
        {
            S2_Timer _timer = timers[i];
            if (_timer.UpdateTimer(_deltaTime))
            {
                RemoveTimer(_timer);
                i--;
            }
        }
    }

    public void AddTimer(S2_Timer _timer)
    {
        timers.Add(_timer);
    }
    public void AddTimer(float _maxTime, Action _callback, bool _isLoop = false)
    {
        S2_Timer _timer = new S2_Timer(_maxTime, _callback, _isLoop);
        timers.Add(_timer);
    }
    public void RemoveTimer(S2_Timer _timer)
    {
        timers.Remove(_timer);
    }
}