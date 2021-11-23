using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotation : MonoBehaviour
{
    public Transform objectToRotate;
    public float rotateSpeed;


    private void FixedUpdate()
    {
        objectToRotate.Rotate(0f, rotateSpeed, 0f, Space.World);
    }
}
