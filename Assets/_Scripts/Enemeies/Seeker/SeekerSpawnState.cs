using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerSpawnState : SeekerEnemyState
{

    public override void FixedUpdateState(SeekerEnemyController enemy)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(SeekerEnemyController enemy, Collider collider)
    {
        throw new System.NotImplementedException();
    }

    public override void StartState(SeekerEnemyController enemy)
    {
        enemy.SwitchState(enemy.chargeUpState);
    }

    public override void UpdateState(SeekerEnemyController enemy)
    {
        throw new System.NotImplementedException();
    }
}
