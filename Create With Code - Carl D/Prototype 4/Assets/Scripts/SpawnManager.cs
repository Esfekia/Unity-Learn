using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(5);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Enemy Wave Spawner
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i=0; i<enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    
    
    //Random Spawn Point Generator
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 6, spawnPosY);

        return randomPos;
    }


}
