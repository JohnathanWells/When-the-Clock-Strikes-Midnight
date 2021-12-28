using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using HauntedPSX;

public class DayNightCycle : MonoBehaviour
{
    public Gradient fogColor;
    public float dayDuration = 12;
    public VolumeProfile sceneVolume;
    float timePassed = 0;
    HauntedPSX.RenderPipelines.PSX.Runtime.FogVolume fogControl;

    private void Start()
    {
        if (!sceneVolume.TryGet(out fogControl))
        {
            Debug.Log("Volume doesn't have Cathode Ray Tube Volume!");
            Destroy(this);
        }


    }

    // Update is called once per frame
    void Update()
    {
        fogControl.color.Override(fogColor.Evaluate(Mathf.InverseLerp(0, dayDuration, timePassed)));

        if (timePassed < dayDuration)
        {
            timePassed += Time.deltaTime;
        }
    }
}
