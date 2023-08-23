using UnityEngine;

public abstract class SeekerEnemyState
{
    public abstract void StartState(SeekerEnemyController enemy);
    public abstract void UpdateState(SeekerEnemyController enemy);
    public abstract void FixedUpdateState(SeekerEnemyController enemy);
    public abstract void OnTriggerEnter(SeekerEnemyController enemy, Collider collider);
}
