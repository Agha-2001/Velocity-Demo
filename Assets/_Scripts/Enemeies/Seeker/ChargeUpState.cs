using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeUpState : SeekerEnemyState
{
    float currentTime;
    GameObject player;
    ParticleSystem chargeEffect;
    public override void FixedUpdateState(SeekerEnemyController enemy)
    {

    }

    public override void OnTriggerEnter(SeekerEnemyController enemy, Collider collider)
    {

    }

    public override void StartState(SeekerEnemyController enemy)
    {
        enemy.charge.Play(true);

        currentTime = 0f;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(SeekerEnemyController enemy)
    {
        enemy.animator.Play("Fly");

        Turn(enemy);

        if (currentTime >= enemy.enemyData.attackCoolDownTime)
        {
            enemy.charge.Stop(true);
            enemy.SwitchState(enemy.launchState);
        }

        currentTime += Time.deltaTime;
    }

    void Turn(SeekerEnemyController e)
    {
        Vector3 pos = player.transform.position - e.transform.position;
        Quaternion rot = Quaternion.LookRotation(pos);
        e.transform.rotation = Quaternion.Slerp(e.transform.rotation, rot, e.enemyData.turningSpeed * Time.deltaTime);
    }
}
