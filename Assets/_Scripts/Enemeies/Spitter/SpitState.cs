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
        enemy.SwitchState(enemy.moveState);
    }

    public override void UpdateState(SpitterEnemyController enemy)
    {

    }

    private void ThrowProjectile(SpitterEnemyController e)
    {
        GameObject newProjectile = GameObject.Instantiate(e.projectilePrefab, e.transform.position, e.transform.rotation);
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
        projectileComponent.LaunchProjectile((player.transform.position - e.transform.position).normalized * (e.enemyData.chaseSpeed * 2));
    }
}
