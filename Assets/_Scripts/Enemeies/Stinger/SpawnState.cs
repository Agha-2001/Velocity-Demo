using UnityEngine;

public class SpawnState : StingerEnemyState
{
    public override void EnterState(StingerEnemyController enemy)
    {
        // Add spawn state logic here
        Debug.Log("Entering Spawn State");
    }

    public override void UpdateState(StingerEnemyController enemy)
    {
        // Add spawn state update logic here

        // Transition to the chase state after a certain condition is met
        enemy.TransitionToState(enemy.chaseState);
    }

    public override void FixedUpdateState(StingerEnemyController enemy)
    {
           
    }

    public override void ExitState(StingerEnemyController enemy)
    {
        
    }

}
