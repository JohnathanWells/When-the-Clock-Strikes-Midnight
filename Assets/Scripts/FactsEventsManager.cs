using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactsEventsManager : MonoBehaviour
{
    [System.Serializable]
    public class FactEvent
    {
        public string factKey;
        public int factValue;
        public UnityEngine.Events.UnityEvent OnTrue;
        public UnityEngine.Events.UnityEvent OnFalse;

        public void Execute()
        {
            if (MysteryManager.facts.TryGetValue(factKey, out int val))
            {
                if (val == factValue)
                    OnTrue.Invoke();
                else
                    OnFalse.Invoke();
            }
            else
            {
                return;
            }
        }
    }

    public FactEvent[] factEvents;

    public void ExecuteEvents()
    {
        foreach(var e in factEvents)
        {
            e.Execute();
        }
    }
}
