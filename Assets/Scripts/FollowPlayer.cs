using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float minAngle = 0;
    public float maxAngle = 90;
    public Transform joint;
    Vector3 center;
    public bool limitToY = true;

    private void Start()
    {
        center = joint.forward;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 difference = joint.position - Camera.main.transform.position;
        Quaternion rotation = Quaternion.LookRotation(-difference, joint.up);
        joint.forward = ClampVector(-difference, center);

        if (limitToY)
            joint.localEulerAngles = new Vector3(center.x, joint.localEulerAngles.y, center.z);
    }

    Vector3 ClampVector(Vector3 direction, Vector3 center)
    {
        float angle = Vector3.Angle(center, direction);


        if (angle > maxAngle)
        {

            direction.Normalize();
            center.Normalize();
            Vector3 rotation = (direction - center) / angle;
            return (rotation * maxAngle) + center;

        }
        else if (angle < minAngle)
        {

            direction.Normalize();
            center.Normalize();
            Vector3 rotation = (direction - center) / angle;
            return (rotation * minAngle) + center;

        }

        return direction;

    }
}
