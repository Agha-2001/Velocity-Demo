using System;
using UnityEngine;

[Serializable]
public class SpawnEnemy : IComparable<SpawnEnemy>
{
    public string Name;
    public int SpawnCost;
    public GameObject EnemyPrefab;

    public int CompareTo(SpawnEnemy other)
    {
        return SpawnCost.CompareTo(other.SpawnCost);
    }
}
