using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "Scriptable Objects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public float chaseSpeed;
    public float turningSpeed;
    public LayerMask enemyMask;
    public float avoidanceRadius;
    public float avoidanceDistance;
    public float attackRadius;
    public float attackCoolDownTime;
    // Add any other public data specific to the enemy here
}
