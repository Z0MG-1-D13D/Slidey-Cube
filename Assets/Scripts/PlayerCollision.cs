using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool playerIsGod = false;

    public PlayerMovement movement;
    public Transform player;
    private GameManager gameManager;
    private Score score;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        score = FindObjectOfType<Score>();
    }


    void OnCollisionEnter(Collision collisionInfo)
    {
        //End game if hit obstacle
        if (collisionInfo.collider.tag == "Obstacle" && !playerIsGod)
        {
            collisionInfo.gameObject.GetComponent<AudioSource>().Play();
            movement.enabled = false;
            gameManager.gameHasEnded = true;
            score.enabled = false;
        }

        //Updates the high score
        if (PlayerPrefs.GetFloat("HighScore") <= player.position.z)
        {
            PlayerPrefs.SetFloat("HighScore", player.position.z);
            gameManager.newHighScore = true;
        }
    }
}
