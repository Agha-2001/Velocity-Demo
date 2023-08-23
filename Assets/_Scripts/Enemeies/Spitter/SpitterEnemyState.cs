using UnityEngine;

public abstract class SpitterEnemyState
{
    public abstract void StartState(SpitterEnemyController enemy);
    public abstract void UpdateState(SpitterEnemyController enemy);
    public abstract void FixedUpdateState(SpitterEnemyController enemy);
    public abstract void OnTriggerEnterState(SpitterEnemyController enemy, Collider collider);
}
