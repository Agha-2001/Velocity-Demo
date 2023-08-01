using UnityEngine;

public abstract class StingerEnemyState : ScriptableObject
{
    public abstract void EnterState(StingerEnemyController enemy);
    public abstract void UpdateState(StingerEnemyController enemy);
    public abstract void FixedUpdateState(StingerEnemyController enemy);
    public abstract void ExitState(StingerEnemyController enemy);
}
