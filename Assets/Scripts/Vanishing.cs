using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanishing : MonoBehaviour
{
    public Renderer renderer;
    public AnimationCurve fadingCurve;
    public float minDistance;
    public float maxDistance;
    public float maxVisibleTime;
    public LayerMask solidLayers;
    [SerializeField]
    float timeSeen = 0;
    [SerializeField]
    bool seen = false;
    public bool disableOnHide;
    Color col;

    private void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        if (!seen && pos.x >= 0 && pos.x <= Screen.width 
            && pos.y >= 0 && pos.y <= Screen.height 
            && ((!Physics.Raycast(Camera.main.transform.position, (transform.position - Camera.main.transform.position).normalized, solidLayers)
            && (transform.position - Camera.main.transform.position).magnitude <= maxDistance)
            || (transform.position - Camera.main.transform.position).magnitude <= minDistance))
        {
            seen = true;
            col = renderer.material.GetColor("_MainColor");
            timeSeen = maxVisibleTime;
        }

        if (seen)
        {
            //col.a = Mathf.Min(
            //    fadingCurve.Evaluate(Mathf.InverseLerp(0, maxVisibleTime, maxVisibleTime - timeSeen)), 
            //    fadingCurve.Evaluate(Mathf.InverseLerp(minDistance, maxDistance, (transform.position - Camera.main.transform.position).magnitude)),
            //    col.a);
            col.a = Mathf.Min(
                Mathf.InverseLerp(0, maxVisibleTime, timeSeen), 
                Mathf.InverseLerp(minDistance, maxDistance, (transform.position - Camera.main.transform.position).magnitude),
                col.a);

            //renderer.material.color = col;
            renderer.material.SetColor("_MainColor", col);
            timeSeen -= Time.deltaTime;

            if (col.a <= 0 && disableOnHide)
            {
                gameObject.SetActive(false);
            }
        }
    }


}
