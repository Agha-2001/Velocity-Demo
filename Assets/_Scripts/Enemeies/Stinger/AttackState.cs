using UnityEngine;

public class AttackState : StingerEnemyState
{
    bool coolingDown;
    float currentTime;
    public override void StartState(StingerEnemyController enemy)
    {
        coolingDown = true;
        currentTime = 0f;
        enemy.animator.Play("sting");
    }

    public override void UpdateState(StingerEnemyController enemy)
    {
        if (coolingDown)
        {

            currentTime += Time.deltaTime;

            if (currentTime >= enemy.enemyData.attackCoolDownTime)
                coolingDown = false;
        }

        else if (!coolingDown)
        {
            enemy.SwitchState(enemy.chaseState);
        }

    }

    public override void FixedUpdateState(StingerEnemyController enemy)
    {

    }

    public override void OnTriggerEnterState(StingerEnemyController enemy, Collider collider)
    {

    }
}
