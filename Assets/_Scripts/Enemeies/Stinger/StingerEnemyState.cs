using UnityEngine;

public abstract class StingerEnemyState
{
    public abstract void StartState(StingerEnemyController enemy);
    public abstract void UpdateState(StingerEnemyController enemy);
    public abstract void FixedUpdateState(StingerEnemyController enemy);
    public abstract void OnTriggerEnterState(StingerEnemyController enemy, Collider collider);
}
