using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupAnimation : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public string subtractiveModifier;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] AObjs;
        Dictionary<string, Transform> BObjs = new Dictionary<string, Transform>();

        AObjs = A.GetComponentsInChildren<Transform>();

        foreach (var b in B.GetComponentsInChildren<Transform>())
        {
            BObjs.Add(b.name + subtractiveModifier, b);
        }

        foreach (var a in AObjs)
        {
            if (BObjs.TryGetValue(a.name, out Transform val))
            {
                a.localPosition = val.localPosition;
                a.localEulerAngles = val.localEulerAngles;
                a.localScale = val.localScale;
            }
        }
    }
}
