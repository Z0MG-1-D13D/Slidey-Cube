using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShrink : MonoBehaviour
{
    public float duration;
    [Range(0, 1)]
    public float modifier;
    public GameObject cubeMesh;
    public GameObject pickupEffect;


    private void LateUpdate()
    {
        if (transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(Pickup(col));
        }
        //if overlapping with obstacle, re place power up at obstacles position and disable obstacle
        if (col.CompareTag("Obstacle"))
        {
            transform.position = new Vector3(col.transform.position.x, transform.position.y, col.transform.position.z);
            //transform.position = col.transform.position;
            col.gameObject.SetActive(false);
        }
    }


    IEnumerator Pickup(Collider player)
    {
        //effect
        player.transform.localScale *= modifier;
        CameraFollow.camOffset.y *= modifier;
        CameraFollow.camOffset.z *= modifier;

        GameObject VFX = Instantiate(pickupEffect, new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), transform.rotation);

        cubeMesh.SetActive(false);

        yield return new WaitForSeconds(duration);

        //reverse effect
        player.transform.localScale /= modifier;
        CameraFollow.camOffset.y /= modifier;
        CameraFollow.camOffset.z /= modifier;

        Destroy(VFX);
        Destroy(gameObject);
    }
}
