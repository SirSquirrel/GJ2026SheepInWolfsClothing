using UnityEngine;
using System.Collections.Generic;

public class enemySpawnScript : MonoBehaviour
{
    public GameObject wolfPrefab;
    public GameObject tigerPrefab;
    public bool tigerSpawning = false;
    public float timeUntilTigerSpawnAllowed = 20;
    public GameObject poacherPrefab;
    public bool poacherSpawning = false;
    public float timeUntilPoacherSpawnAllowed = 50f;
    public GameObject dragonPrefab;
    public bool dragonSpawning = false;
    public float timeUntilDragonSpawnAllowed = 50f;
    public float timeUntilWolfSpawnAllowed = 0;
    public float enemyTimer = 0f;
    public float timeTillEnemySpawn = 10f;
    public float minTimeTillEnemySpawn = 3f;
    public List<GameObject> enemiesCurrentlySpawning = new List<GameObject>();
    public List<GameObject> spawnPoints = new List<GameObject>();
    public float timeDifferentialFromEnemySpawnTimer = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemiesCurrentlySpawning.Add(wolfPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer += Time.deltaTime;
        if (enemyTimer > timeTillEnemySpawn)
        {
            //check for enemies to add to spawn list over time
            if (!tigerSpawning && GameManager._instance.survivalTime > timeUntilTigerSpawnAllowed)
            {
                enemiesCurrentlySpawning.Add(tigerPrefab);
                tigerSpawning = true;
            }
            if (!poacherSpawning && GameManager._instance.survivalTime > timeUntilPoacherSpawnAllowed)
            {
                enemiesCurrentlySpawning.Add(poacherPrefab);
                poacherSpawning = true;
            }
            if (!dragonSpawning && GameManager._instance.survivalTime > timeUntilDragonSpawnAllowed)
            {
                enemiesCurrentlySpawning.Add(dragonPrefab);
                dragonSpawning = true;
            }

            SpawnEnemy();
            enemyTimer = 0;
            //increase spawn rate over time
            if(timeTillEnemySpawn > minTimeTillEnemySpawn)
            {
                timeTillEnemySpawn -= timeDifferentialFromEnemySpawnTimer;       
            }
        }
    }

    void SpawnEnemy()
    {
        int enemyIntToSpawn = Random.Range(0,enemiesCurrentlySpawning.Count);
        GameObject enemyToSpawn = enemiesCurrentlySpawning[enemyIntToSpawn];
        int spawnPointInt = Random.Range(0,spawnPoints.Count);
        GameObject spawnPoint = spawnPoints[spawnPointInt];

        GameObject newEnemy = new GameObject();

        newEnemy = Instantiate(enemyToSpawn, spawnPoint.transform.position, Quaternion.identity);
        newEnemy.transform.position = newEnemy.transform.position + new Vector3(0,0,-1);
    }
}
