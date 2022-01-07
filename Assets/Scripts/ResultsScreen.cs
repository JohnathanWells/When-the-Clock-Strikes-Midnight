using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultsScreen : MonoBehaviour
{
    public Image curtainImage;
    public float selectionFadeInTime;
    public string[] suspectIdentities;

    [Header("UI - Selection")]
    public Transform suspectsParent;
    public Toggle suspectPrefab;
    private Toggle[] suspects;
    private TextMeshProUGUI[] suspectNames;

    [Header("Conditions")]
    public Conditions[] conditions;
    public bool thereIsCorrectAnswer = true;
    public string defaultMessage;

    [Header("UI - Results")]
    public Image coverImage;
    public TextMeshProUGUI result;
    public float timeBeforeQuit;
    public float resultsFadeInTime;

    [System.Serializable]
    public class Conditions
    {
        [System.Serializable]
        public class ConditionVariables
        {
            public string key;
            public enum condition { EQUAL, NOT_EQUAL, MORE_THAN, LESS_THAN, MORE_EQUAL_THAN, LESS_EQUAL_THAN};
            public int value;
            public condition relationship;

            public bool GetStatus()
            {
                if (MysteryManager.facts.TryGetValue(key, out int val))
                {
                    switch (relationship)
                    {
                        case condition.EQUAL:
                            return (value == val);
                        case condition.NOT_EQUAL:
                            return (value != val);
                        case condition.LESS_EQUAL_THAN:
                            return (value <= val);
                        case condition.LESS_THAN:
                            return (value < val);
                        case condition.MORE_EQUAL_THAN:
                            return (value >= val);
                        case condition.MORE_THAN:
                            return (value > val);
                        default:
                            return true;
                    }
                }
                else
                    return false;
            }
        }

        public string name;
        public ConditionVariables[] conditions;
        public enum conditionType { AND, OR };
        public conditionType conditionLogicGate;
        [TextArea(4, 10)]
        public string message;
        public bool stackable = true;
        public int priority = 0;

        public bool GetCondition()
        {
            foreach (var c in conditions)
            {
                //Debug.Log(name + "-" + c.key + "=" + c.value + "?" + MysteryManager.facts[c.key]);
                if (c.GetStatus())
                {
                    if (conditionLogicGate == conditionType.OR)
                        return true;
                }
                else if (conditionLogicGate == conditionType.AND)
                {
                    return false;
                }
            }

            if (conditionLogicGate == conditionType.AND)
                return true;
            else
                return false;
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SpawnSelections();
    }

    public void SpawnSelections()
    {
        suspects = new Toggle[suspectIdentities.Length];
        suspectNames = new TextMeshProUGUI[suspectIdentities.Length];

        for (int n = 0; n < suspectIdentities.Length; n++)
        {
            suspects[n] = Instantiate(suspectPrefab, suspectsParent);
            suspectNames[n] = suspects[n].GetComponentInChildren<TextMeshProUGUI>();
            suspectNames[n].text = suspectIdentities[n];
        }

        StartCoroutine(fadeIn());
    }

    public void CheckResults()
    {
        result.text = string.Empty;

        if (thereIsCorrectAnswer)
        {
            int highestPriority = int.MinValue;
            foreach (var c in conditions)
            {
                if (c.GetCondition())
                {
                    Debug.Log(c.name);
                    if (c.stackable && c.priority >= highestPriority)
                    {
                        result.text += c.message + "\n\n\n";
                        highestPriority = c.priority;
                    }    
                    else if (c.priority >= highestPriority)
                    {
                        result.text = c.message;
                        highestPriority = c.priority;
                    }
                }
            }
        }
        else
            result.text = defaultMessage;

        StartCoroutine(fadeOut());
    }

    public void LogSelection()
    {
        for (int n = 0; n < suspectIdentities.Length; n++)
        {
            string key = string.Format("{0}_selected", suspectIdentities[n]); 
            if (!MysteryManager.facts.ContainsKey(key))
            {
                MysteryManager.facts.Add(key, ((suspects[n].isOn) ? 1 : 0));
            }
            else
            {
                MysteryManager.facts[key] = ((suspects[n].isOn) ? 1 : 0);
            }
        }
    }

    IEnumerator fadeOut()
    {
        /*coverImage.gameObject.SetActive(true);
        float count = 0;
        Color col;
        col = coverImage.color;
        Color col2 = result.color;
        while (count < resultsFadeInTime)
        {
            col.a = Mathf.InverseLerp(0, resultsFadeInTime, count);
            coverImage.color = col;
            col2.a = col.a;
            result.color = col2;
            yield return null;
            count += Time.deltaTime;
        }
        col.a = 1;
        coverImage.color = col;
        col2.a = col.a;
        result.color = col2; */       
        
        coverImage.gameObject.SetActive(true);
        float count = 0;
        Color col;
        col = coverImage.color;
        while (count < resultsFadeInTime)
        {
            col.a = Mathf.InverseLerp(0, resultsFadeInTime, count);
            coverImage.color = col;
            yield return null;
            count += Time.deltaTime;
        }
        col.a = 1;
        coverImage.color = col;
        count = 0;
        col = result.color;

        while (count < resultsFadeInTime)
        {
            col.a = Mathf.InverseLerp(0, resultsFadeInTime, count);
            result.color = col;
            yield return null;
            count += Time.deltaTime;
        }
        col.a = 1;
        result.color = col;        

        yield return new WaitForSeconds(timeBeforeQuit);

        Application.Quit();
    }

    IEnumerator fadeIn()
    {
        curtainImage.gameObject.SetActive(true);
        float count = resultsFadeInTime;
        Color col;
        col = curtainImage.color;
        while (count > 0)
        {
            col.a = Mathf.InverseLerp(0, resultsFadeInTime, count);
            curtainImage.color = col;
            yield return null;
            count -= Time.deltaTime;
        }
        col.a = 0;
        curtainImage.color = col;

        yield return null;
        curtainImage.gameObject.SetActive(false);
    }
}
