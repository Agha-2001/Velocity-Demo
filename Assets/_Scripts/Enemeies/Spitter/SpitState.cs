using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitState : SpitterEnemyState
{
    GameObject player;
    Projectile projectile;
    public override void FixedUpdateState(SpitterEnemyController enemy)
    {

    }

    public override void OnTriggerEnterState(SpitterEnemyController enemy, Collider collider)
    {

    }

    public override void StartState(SpitterEnemyController enemy)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        ThrowProjectile(enemy);
    }

    public override void UpdateState(SpitterEnemyController enemy)
    {
        if (enemy.animator.GetCurrentAnimatorStateInfo(0).IsName("Spit") && enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            enemy.SwitchState(enemy.moveState);
        }
    }

    private void ThrowProjectile(SpitterEnemyController e)
    {
        GameObject newProjectile = GameObject.Instantiate(e.projectilePrefab, e.transform.position, e.transform.rotation);
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
        projectileComponent.LaunchProjectile((player.transform.position - e.transform.position).normalized * (e.enemyData.chaseSpeed * 2));

        e.animator.Play("Spit");


    }
}
