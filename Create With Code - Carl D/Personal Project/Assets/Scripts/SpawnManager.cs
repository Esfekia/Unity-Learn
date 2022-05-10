using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Our enemies and powerup gameobjects
    public GameObject[] enemies;
    public GameObject powerup;

    //Location variables for spawning for enemies and powerup
    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 11.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = 0.75f;

    //Spawner Timer Variables
    private float powerupSpawnTime = 10.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomEnemy()
    {
        //Random X coordinate
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        //Pick a random enemy from our array
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }
    void SpawnPowerup()
    {
        //Random X coordinate
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        //Random Z coordinate for powerup
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);

    }
}
