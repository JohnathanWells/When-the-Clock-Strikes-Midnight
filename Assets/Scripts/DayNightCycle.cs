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
    public AnimationCurve xDirectionalRotation;
    public Light directionalLight;
    Vector3 directionalLightRotation;
    float timePassed = 0;
    HauntedPSX.RenderPipelines.PSX.Runtime.FogVolume fogControl;

    private void Start()
    {
        if (!sceneVolume.TryGet(out fogControl))
        {
            Debug.Log("Volume doesn't have Cathode Ray Tube Volume!");
            Destroy(this);
        }

        directionalLightRotation = directionalLight.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        fogControl.color.value = fogColor.Evaluate(Mathf.InverseLerp(0, dayDuration, timePassed));

        if (timePassed < dayDuration)
        {
            timePassed += Time.deltaTime;

            directionalLightRotation.x = xDirectionalRotation.Evaluate(Mathf.Clamp(Mathf.InverseLerp(0, dayDuration, timePassed), 0, 1));

            directionalLight.transform.rotation = Quaternion.Euler(directionalLightRotation);
        }
    }
}
