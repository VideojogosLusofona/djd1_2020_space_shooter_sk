using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[]  spawnPoints;
    [SerializeField] private float        firstSpawnTime = 4.0f;
    [SerializeField] private float        nextSpawnTime = 2.0f;
    [SerializeField] private GameObject[] enemyPrefab;

    float   timer;

    void Start()
    {
        timer = firstSpawnTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            timer = nextSpawnTime;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        int enemy = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemy], spawnPoints[spawnPoint].position, spawnPoints[spawnPoint].rotation);
    }
}
