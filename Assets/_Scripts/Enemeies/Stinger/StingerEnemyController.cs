using UnityEngine;

public class StingerEnemyController : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    [HideInInspector] public StingerEnemyState currentState;
    [HideInInspector] public ChaseState chaseState;
    [HideInInspector] public AttackState attackState;
    [HideInInspector] public SpawnState spawnState;

    [HideInInspector] public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Initialize the state machine
        spawnState = new SpawnState();
        chaseState = new ChaseState();
        attackState = new AttackState();

        currentState = spawnState;
        currentState.StartState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnterState(this, other);
    }

    public void SwitchState(StingerEnemyState newState)
    {
        currentState = newState;
        currentState.StartState(this);
    }
}
