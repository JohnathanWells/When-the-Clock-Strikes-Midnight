using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineScript : MonoBehaviour
{
    public MysteryManager.information[] informationDiscovered;
    public string[] messages;
    public int nextMessage = 0;
    public float messageCooldown = 1f;
    float cooldownCount;

    private void Update()
    {
        if (cooldownCount > 0)
        {
            cooldownCount -= Time.deltaTime;
        }
    }

    public void RegisterInformation()
    {
        if (cooldownCount <= 0)
        {
            foreach (var i in informationDiscovered)
            {
                MysteryManager.RegisterInformation(i);
            }

            cooldownCount = messageCooldown;
        }
    }

    public void DisplayMessage()
    {
        if (cooldownCount <= 0)
        {
            SubtitleManager.Instance.DisplayMessage(messages[nextMessage]);

            if (nextMessage + 1 < messages.Length)
            {
                nextMessage++;
            }

            cooldownCount = messageCooldown;
        }
    }
}
