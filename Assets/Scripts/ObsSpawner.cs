using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform player;
    
    [Tooltip("Distance between difficulty increases")]
    public float diffIncrease = 250f;
    [Tooltip("Amount of time in seconds to decrease the spawn rate each difficulty level")]
    public float diffIncreaseRate = .25f;
    [HideInInspector] 
    public float difficulty = 0f; //Called by other scripts to change displays by difficulty

    public float timeBetweenWaves = 3f;
    private float timeToSpawn = 2f;

    public GameObject[] powerUps;
    public float powerUpInterval;


    void Update() {
        //Spawns the blocks in waves
        if (Time.time >= timeToSpawn)
        {
            SpawnPowerUp();
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
        }

        //Increase difficulty over time
        if (player.position.z >= diffIncrease)
        {
            //reset diffIncrease to next interval
            diffIncrease = diffIncrease + diffIncrease;
            timeBetweenWaves = timeBetweenWaves - diffIncreaseRate;
            difficulty = difficulty++;
        }

/*        if (player.position.z >= powerUpInterval)
        {
            powerUpInterval += player.position.z;
            if(player.position.z >= 20f) 
            {
                SpawnPowerUp(); 
            }
        }*/
    }

    
    void SpawnBlocks()
    {
        int prevIndex = -1;
        int randomIndex = Random.Range(0, spawnPoints.Length);

        if(randomIndex == prevIndex)
        {
            randomIndex = Random.Range(0, spawnPoints.Length);
        }
        else if (randomIndex != prevIndex)
        {
            prevIndex = randomIndex;

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (randomIndex != i)
                {
                    GameObject obstacle = ObjectPooler.sharedInstance.GetPooledObject();
                    if(obstacle != null)
                    {
                        obstacle.transform.position = spawnPoints[i].position;
                        obstacle.transform.rotation = Quaternion.identity;
                        obstacle.SetActive(true);
                    }
                }
            }
        }
    }


    public void SpawnPowerUp()
    {
        int randomPowerUp = Random.Range(0, powerUps.Length);
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        Vector3 spawnPostion = new Vector3(spawnPoints[randomSpawnPoint].position.x, 1.5f, spawnPoints[randomSpawnPoint].position.z);
        Instantiate(powerUps[randomPowerUp], spawnPostion, Quaternion.identity);
    }
}
