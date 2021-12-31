using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public float realSeconds;
    public float additionalSeconds;
    public DayNightCycle dayNightManager;
    float count = 0;
    public UnityEngine.Events.UnityEvent OnTimerEnds;

    private void Awake()
    {
        dayNightManager.dayDuration = realSeconds;
        //Temporary solution
        additionalSeconds = (dayNightManager.blendPercentage * dayNightManager.bells[0].length) *
            (dayNightManager.hoursInDay - 1) +
            dayNightManager.lastBells[0].length;
        count = realSeconds + additionalSeconds;
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
