using UnityEngine;

public class AttackState : StingerEnemyState
{
    MeshRenderer mRend;
    Color original;
    bool coolingDown;
    float currentTime;
    public override void EnterState(StingerEnemyController enemy)
    {
        mRend = enemy.GetComponent<MeshRenderer>();
        
        original = mRend.material.color;
        mRend.material.color = Color.white;

        coolingDown = true;
        currentTime = 0f;
    }

    public override void UpdateState(StingerEnemyController enemy)
    {
        if(coolingDown)
        {
            currentTime += Time.deltaTime;

            if(currentTime >= enemy.enemyData.attackCoolDownTime)
                coolingDown = false;
        }

        else if(!coolingDown)
        {
            enemy.TransitionToState(enemy.chaseState);
        }
            
    }

    public override void FixedUpdateState(StingerEnemyController enemy)
    {
        
    }

    public override void ExitState(StingerEnemyController enemy)
    {
        mRend.material.color = original;
    }
}
