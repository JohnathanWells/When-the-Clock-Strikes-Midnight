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

    [Header("Sound")]
    public int startHour = 8;
    public int hoursInDay = 12;
    [Tooltip("The percentage that must pass in a clip before playing the next"), Range(0, 1)]
    public float blendPercentage = 1;
    public AudioClip[] bells;
    public AudioSource source;
    int currentHour = 0;


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

            int newHour = Mathf.FloorToInt(startHour + ((timePassed / dayDuration) * (hoursInDay - startHour)));
            Debug.Log(newHour);

            if (newHour != currentHour)
            {
                currentHour = newHour;
                RingBells();
            }
        }
    }

    void RingBells()
    {
        StartCoroutine(ringBells(currentHour + hoursInDay));
    }

    IEnumerator ringBells(int times)
    {
        source.Stop();

        for (int n = 0; n < times; n++)
        {
            int clipSelected = Random.Range(0, bells.Length);
            //source.clip = bells[clipSelected];
            //source.Play();
            source.PlayOneShot(bells[clipSelected]);
            yield return new WaitForSeconds(bells[clipSelected].length * blendPercentage);
        }

    }
}
