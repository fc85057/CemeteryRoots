using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;

    public float nextSpawnTime = 0f;
    public float spawnCounter = 10f;

    List<GameObject> enemies;

    private void Start()
    {
        enemies = new List<GameObject>();
        SpawnEnemy();
    }

    private void Update()
    {
        if (Time.time > nextSpawnTime && enemies.Count < 12)
            SpawnEnemy();
    }

    void SpawnEnemy()
    {
        int numberOfEnemies = Random.Range(0, 4);

        for (int i = 0; i <= numberOfEnemies; i++)
        {
            int enemyType = Random.Range(0, enemyTypes.Length);
            int spawnPoint = Random.Range(-25, 26);
            Vector3 spawnLocation = new Vector3(spawnPoint, -1.75f);

            // GameObject newEnemy = Instantiate(enemyTypes[enemyType], spawnPoints[spawnPoint]);
            GameObject newEnemy = Instantiate(enemyTypes[enemyType], spawnLocation, Quaternion.identity);
            enemies.Add(newEnemy);

        }

        nextSpawnTime = Time.time + spawnCounter;

        if (spawnCounter > 3f)
            spawnCounter -= .1f;
    }

    public void RemoveEnemy(GameObject enemyToRemove)
    {
        enemies.Remove(enemyToRemove);
        Destroy(enemyToRemove, 1f);
    }

}
