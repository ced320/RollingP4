using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        spawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            spawnEnemyWave(waveNumber);
        }
    }

    private Vector3 GenerateSpawnPosition() 
    {
        float randomX = Random.RandomRange(-spawnRange, spawnRange);
        float randomZ = Random.RandomRange(-spawnRange, spawnRange);
        return new Vector3(randomX, 0, randomZ);
    }

    private void spawnEnemyWave(int enemiesToSpawn) 
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        { 
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
