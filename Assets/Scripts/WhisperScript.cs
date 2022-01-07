using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhisperScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    public float minTime;
    public float maxTime;
    public bool acceptRepeats = false;
    float timer = 0;
    int lastClipInd = -1;

    private void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        if (timer <= 0)
        {
            int clipInd;
            do
            {
                clipInd = Random.Range(0, (clips.Length - 1));

            } while (clipInd == lastClipInd && !acceptRepeats);

            source.PlayOneShot(clips[clipInd]);

            timer = clips[clipInd].length + Random.Range(minTime, maxTime);

            lastClipInd = clipInd;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
