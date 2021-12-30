using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public float realSeconds;
    public DayNightCycle dayNightManager;
    float count = 0;
    public UnityEngine.Events.UnityEvent OnTimerEnds;

    private void Awake()
    {
        dayNightManager.dayDuration = realSeconds;
        count = realSeconds;
    }

    private void Update()
    {
        if (count > 0)
        {
            count -= Time.deltaTime;
        }
        else
        {
            OnTimerEnds.Invoke();
        }
    }
}
