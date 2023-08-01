using UnityEngine;

public class ChaseState : StingerEnemyState
{
    GameObject player;   
    public override void EnterState(StingerEnemyController enemy)
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(StingerEnemyController enemy)
    {
        if(Vector3.Distance(enemy.transform.position,player.transform.position) <= enemy.enemyData.attackRadius)
            enemy.TransitionToState(enemy.attackState);
    }

    public override void FixedUpdateState(StingerEnemyController enemy)
    {
        Pathfinding(enemy);
        Move(enemy);
    }

    public override void ExitState(StingerEnemyController enemy)
    {
        
    }

    void Turn(StingerEnemyController e)
    {
        Vector3 pos = player.transform.position - e.transform.position;
        Quaternion rot = Quaternion.LookRotation(pos);
        e.transform.rotation = Quaternion.Slerp(e.transform.rotation, rot, e.enemyData.turningSpeed * Time.deltaTime);
    }

    void Move(StingerEnemyController e)
    {
        e.transform.position += e.transform.forward * e.enemyData.chaseSpeed * Time.deltaTime;
    }

    void Pathfinding(StingerEnemyController e)
    {
        RaycastHit hit;
        Vector3 rayCastOffset = Vector3.zero;

        Vector3 LEFT = e.transform.position - e.transform.right * e.enemyData.avoidanceDistance;
        Vector3 RIGHT = e.transform.position + e.transform.right * e.enemyData.avoidanceDistance;
        Vector3 UP = e.transform.position + e.transform.up * e.enemyData.avoidanceDistance;
        Vector3 DOWN = e.transform.position - e.transform.up * e.enemyData.avoidanceDistance;

        // for direction
        if (Physics.Raycast(LEFT, e.transform.forward, out hit, e.enemyData.avoidanceDistance, e.enemyData.enemyMask))
            rayCastOffset += Vector3.right;
        else if (Physics.Raycast(RIGHT, e.transform.forward, out hit, e.enemyData.avoidanceDistance, e.enemyData.enemyMask))
            rayCastOffset -= Vector3.right;
        else if (Physics.Raycast(UP, e.transform.forward, out hit, e.enemyData.avoidanceDistance, e.enemyData.enemyMask))
            rayCastOffset -= Vector3.up;
        else if (Physics.Raycast(DOWN, e.transform.forward, out hit, e.enemyData.avoidanceDistance, e.enemyData.enemyMask))
            rayCastOffset += Vector3.up;
        
        // for height
        if (Physics.Raycast(e.transform.position, e.transform.up, out hit, e.enemyData.avoidanceDistance, e.enemyData.enemyMask))
        rayCastOffset -= Vector3.up;
        else if (Physics.Raycast(e.transform.position, -e.transform.up, out hit, e.enemyData.avoidanceDistance, e.enemyData.enemyMask))
        rayCastOffset += Vector3.up;

        // Avoidance behavior
        if (rayCastOffset != Vector3.zero)
        {
            // Check if there are other enemies nearby
            Collider[] nearbyEnemies = Physics.OverlapSphere(e.transform.position, e.enemyData.avoidanceRadius, e.enemyData.enemyMask);

            foreach (Collider enemyCollider in nearbyEnemies)
            {
                if (enemyCollider != e.GetComponent<Collider>()) // Avoid self-collision
                {
                    Vector3 avoidanceDirection = e.transform.position - enemyCollider.transform.position;
                    avoidanceDirection.Normalize();
                    rayCastOffset += avoidanceDirection;
                }
            }
        }

        if (rayCastOffset != Vector3.zero)
            e.transform.Rotate(rayCastOffset * e.enemyData.turningSpeed * Time.deltaTime);
        else
            Turn(e);
    }
    

}
