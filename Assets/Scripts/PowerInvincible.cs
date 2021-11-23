using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInvincible : MonoBehaviour
{
    public float duration;
    public GameObject cubeMesh;
    public GameObject pickupEffect;

    public float playerAlpha;
    //public Material playerMat;


    private void LateUpdate()
    {
        if(transform.position.y < -1)
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
        //get PlayerCollision script and disable it
        PlayerCollision playerCollision = player.GetComponent<PlayerCollision>();
        Material playerMat = player.GetComponent<MeshRenderer>().material;

        //effect
        playerCollision.playerIsGod = true;
        playerMat.color = new Color(playerMat.color.r, playerMat.color.g, playerMat.color.b, playerAlpha);

        GameObject VFX = Instantiate(pickupEffect, transform.position, transform.rotation);

        cubeMesh.SetActive(false);

        yield return new WaitForSeconds(duration);

        //reverse effect
        playerCollision.playerIsGod = false;
        playerMat.color = new Color(playerMat.color.r, playerMat.color.g, playerMat.color.b);

        Destroy(VFX);
        Destroy(gameObject);
    }
}