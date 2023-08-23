using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterSpawnState : SpitterEnemyState
{
    public override void FixedUpdateState(SpitterEnemyController enemy)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnterState(SpitterEnemyController enemy, Collider collider)
    {
        throw new System.NotImplementedException();
    }

    public override void StartState(SpitterEnemyController enemy)
    {
        enemy.SwitchState(enemy.moveState);
    }

    public override void UpdateState(SpitterEnemyController enemy)
    {

    }
}
