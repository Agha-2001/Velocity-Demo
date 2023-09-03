using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnEnemy : IComparable<SpawnEnemy>
{
    public string Name;
    public int SpawnCost;
    public GameObject EnemyPrefab;

    private Queue<GameObject> pool = new Queue<GameObject>();

    public void InitializePool()
    {
        // Initialize the pool with a default size or as needed
        for (int i = 0; i < 4; i++) // You can adjust the initial pool size as needed
        {
            CreateNewEnemy();
        }
    }

    private void CreateNewEnemy()
    {
        GameObject obj = GameObject.Instantiate(EnemyPrefab);
        obj.SetActive(false);
        EnemyHealth enemyHealth = obj.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.OnDeath += HandleEnemyDeath;
        }

        pool.Enqueue(obj);
    }

    public GameObject SpawnFromPool(Vector3 position, Quaternion rotation)
    {
        if (pool.Count <= 0)
        {
            // If the pool is empty, create a new enemy
            CreateNewEnemy();
        }

        GameObject enemyToSpawn = pool.Dequeue();

        enemyToSpawn.SetActive(true);
        enemyToSpawn.transform.position = position;
        enemyToSpawn.transform.rotation = rotation;

        return enemyToSpawn;
    }

    private void HandleEnemyDeath(GameObject deadEnemy)
    {
        EnemySpawnSystem.GetInstance().activeEnemiesCount--;
        EnemySpawnSystem.GetInstance().destroyedEnemiesCount++;

        pool.Enqueue(deadEnemy);
        deadEnemy.SetActive(false);
    }

    public int CompareTo(SpawnEnemy other)
    {
        return SpawnCost.CompareTo(other.SpawnCost);
    }
}
