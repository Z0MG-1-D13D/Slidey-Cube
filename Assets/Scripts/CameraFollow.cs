using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static Vector3 camOffset = new Vector3 (0f, 1.5f, -5f);

    public Transform target;

    public float smoothSpeed = 0.150f;
    //public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + camOffset;
        Vector3 smoothedPostion = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPostion;
    }
}
