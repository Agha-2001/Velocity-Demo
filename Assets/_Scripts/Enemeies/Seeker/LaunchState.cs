using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchState : SeekerEnemyState
{
    GameObject player;
    PlayerHealth playerHealth;
    public override void FixedUpdateState(SeekerEnemyController enemy)
    {

    }

    public override void OnTriggerEnter(SeekerEnemyController enemy, Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(1);
            enemy.SwitchState(enemy.chargeUpState);
            // Handle player collision here
        }
        else if (collider.gameObject.CompareTag("Arena"))
        {
            enemy.SwitchState(enemy.chargeUpState);
        }
    }

    public override void StartState(SeekerEnemyController enemy)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerHealth = player.GetComponent<PlayerHealth>();
    }

    public override void UpdateState(SeekerEnemyController enemy)
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) < enemy.enemyData.avoidanceDistance)
        {
            playerHealth.TakeDamage(1);
            enemy.SwitchState(enemy.chargeUpState);
        }

        if (!DetectObstacle(enemy))
        {
            Move(enemy);
        }

        else if (DetectObstacle(enemy))
        {
            enemy.SwitchState(enemy.chargeUpState);
        }
    }

    void Move(SeekerEnemyController e)
    {
        e.transform.position += e.transform.forward * e.enemyData.chaseSpeed * Time.deltaTime;
    }

    bool DetectObstacle(SeekerEnemyController e)
    {
        if (Physics.Raycast(e.transform.position, e.transform.forward, out RaycastHit hit, e.enemyData.avoidanceDistance, e.enemyData.enemyMask))
        {
            if (hit.collider)
                return true;
        }

        return false;
    }
}
