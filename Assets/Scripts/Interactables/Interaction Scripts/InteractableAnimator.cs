using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAnimator : MonoBehaviour
{
    [System.Serializable]
    public class IntValue
    {
        public string name;
        public int value;
    }
    [System.Serializable]
    public class FloatValue
    {
        public string name;
        public float value;
    }
    [System.Serializable]
    public class BoolValue
    {
        public string name;
        public bool value;
    }

    public Animator animator;

    public IntValue[] defaultIntValues;
    public FloatValue[] defaultFloatValues;
    public BoolValue[] defaultBoolValues;

    public void Init()
    {
        foreach (var i in defaultIntValues)
        {
            animator.SetInteger(i.name, i.value);
        }
        foreach (var f in defaultFloatValues)
        {
            animator.SetFloat(f.name, f.value);
        }
        foreach (var b in defaultBoolValues)
        {
            animator.SetBool(b.name, b.value);
        }
    }

    public void SetAnimatorBooleanTrue(string booleanName)
    {
        Debug.Log("Door animation has been set to true.");
        animator.SetBool(booleanName, true);
    }
    public void SetAnimatorBooleanFalse(string booleanName)
    {
        animator.SetBool(booleanName, false);
    }
}
