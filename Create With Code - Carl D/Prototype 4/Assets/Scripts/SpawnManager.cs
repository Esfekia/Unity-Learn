using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9.0f;

    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(1);
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();
        }

    }
    //Powerup Spawner
    void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, GeneratePowerUpPosition(), powerUpPrefab.transform.rotation);
    }
    //Random Spawn Point Generator for Powerups
    private Vector3 GeneratePowerUpPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosY);

        return randomPos;
    }
    //Enemy Wave Spawner
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i=0; i<enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    //Random Spawn Point Generator for Powerups

    //Random Spawn Point Generator for Enemies
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 6, spawnPosY);

        return randomPos;
    }


}
