using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryManager : MonoBehaviour
{
    [System.Serializable]
    public class information
    {
        public string name;
        public int value;
    }

    public string[] possibleCulprits;

    public static Dictionary<string, int> facts = new Dictionary<string, int>();

    public void DecideCulprit()
    {
        int val = Random.Range(0, possibleCulprits.Length);

        if (facts.ContainsKey("culprit"))
        {
            facts["culprit"] = val;
        }
        else
        {
            facts.Add("culprit", val);
        }
    }

    public static void RegisterInformation(information foo)
    {
        if (facts.ContainsKey(foo.name))
        {
            facts[foo.name] = foo.value;
        }
        else
        {
            facts.Add(foo.name, foo.value);
        }
    }
}
