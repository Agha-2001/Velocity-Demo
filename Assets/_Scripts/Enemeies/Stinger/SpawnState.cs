using UnityEngine;

public class SpawnState : StingerEnemyState
{
    public override void StartState(StingerEnemyController enemy)
    {

    }

    public override void UpdateState(StingerEnemyController enemy)
    {
        // Add spawn state update logic here

        // Transition to the chase state after a certain condition is met
        enemy.SwitchState(enemy.chaseState);
    }

    public override void FixedUpdateState(StingerEnemyController enemy)
    {

    }

    public override void OnTriggerEnterState(StingerEnemyController enemy, Collider collider)
    {

    }
}
