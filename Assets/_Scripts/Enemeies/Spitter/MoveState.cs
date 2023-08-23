using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : SpitterEnemyState
{
    GameObject player;
    float lastThrowTime;
    public override void FixedUpdateState(SpitterEnemyController enemy)
    {
        Turn(enemy);
        Move(enemy);
    }

    public override void OnTriggerEnterState(SpitterEnemyController enemy, Collider collider)
    {
        // Nothing happens.
    }

    public override void StartState(SpitterEnemyController enemy)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastThrowTime = Time.time;
    }

    public override void UpdateState(SpitterEnemyController enemy)
    {
        if (Time.time - lastThrowTime >= enemy.enemyData.attackCoolDownTime)
        {
            lastThrowTime = Time.time;
            enemy.SwitchState(enemy.spitState);
        }
    }

    void Turn(SpitterEnemyController e)
    {
        Vector3 pos = player.transform.position - e.transform.position;
        Quaternion rot = Quaternion.LookRotation(pos);
        e.transform.rotation = Quaternion.Slerp(e.transform.rotation, rot, e.enemyData.turningSpeed * Time.deltaTime);
    }

    void Move(SpitterEnemyController e)
    {
        e.transform.position += e.transform.forward * e.enemyData.chaseSpeed * Time.deltaTime;
    }
}
