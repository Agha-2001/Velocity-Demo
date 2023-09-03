using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class EnemySpawnSystem : Singleton<EnemySpawnSystem>
{
    [SerializeField] SpawnEnemy[] enemies;
    [SerializeField] float minSpawnDistance;

    BoxCollider spawnBounds;
    List<Vector3> spawnPoints = new List<Vector3>();

    public int activeEnemiesCount = 0;
    public int destroyedEnemiesCount = 0;

    private void Start()
    {
        spawnBounds = GetComponent<BoxCollider>();

        if (spawnBounds == null)
        {
            Debug.LogError("No BoxCollider found on the spawner object.");
            return;
        }

        Array.Sort(enemies);    // enemies list is sorted based on SpawnCost.
        Array.Reverse(enemies);

        foreach (SpawnEnemy enemy in enemies)
        {
            enemy.InitializePool();
        }
    }

    private Stack<SpawnEnemy> CalculateEnemies(int SpawnValue)
    {
        Stack<SpawnEnemy> SelectedEnemies = new Stack<SpawnEnemy>();

        int iterator = 0;

        while (SpawnValue > 0 && iterator < enemies.Length)
        {
            if (SpawnValue >= enemies[iterator].SpawnCost)
            {
                SelectedEnemies.Push(enemies[iterator]);
                SpawnValue -= enemies[iterator].SpawnCost;
            }

            else if (SpawnValue < enemies[iterator].SpawnCost)
            {
                iterator++;
            }
        }

        return SelectedEnemies;
    }

    private void CalculateSpawnPoints(int numPoints)
    {
        Vector3 boundsMin = spawnBounds.bounds.min;
        Vector3 boundsMax = spawnBounds.bounds.max;

        for (int i = 0; i < numPoints; i++)
        {
            Vector3 randomPoint = new Vector3(Random.Range(boundsMin.x, boundsMax.x), Random.Range(boundsMin.y, boundsMax.y), Random.Range(boundsMin.z, boundsMax.z));

            bool isValidSpawn = true;

            foreach (Vector3 existingSpawnPoint in spawnPoints)
            {
                if (Vector3.Distance(randomPoint, existingSpawnPoint) < minSpawnDistance || randomPoint == existingSpawnPoint)
                {
                    isValidSpawn = false;
                    break;
                }
            }

            if (isValidSpawn)
            {
                spawnPoints.Add(randomPoint);
            }

            else if (!isValidSpawn)
            {
                i--;
            }
        }
    }

    public void SpawnEnemies(int SpawnValue)
    {
        activeEnemiesCount = 0;
        destroyedEnemiesCount = 0;

        Stack<SpawnEnemy> temp = CalculateEnemies(SpawnValue);

        CalculateSpawnPoints(temp.Count);

        int i = 0;

        foreach (SpawnEnemy spawn in temp)
        {
            GameObject newEnemy = spawn.SpawnFromPool(spawnPoints[i], Quaternion.identity);

            activeEnemiesCount++;
            i++;
        }
    }

}
