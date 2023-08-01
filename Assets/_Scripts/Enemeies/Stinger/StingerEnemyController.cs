using UnityEngine;

public class StingerEnemyController : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    [HideInInspector] public StingerEnemyState currentState;
    [HideInInspector] public ChaseState chaseState;
    [HideInInspector] public AttackState attackState;



    private void Start()
    {
        // Initialize the state machine
        chaseState = ScriptableObject.CreateInstance<ChaseState>();
        attackState = ScriptableObject.CreateInstance<AttackState>();

        // Set the initial state to spawn state
        TransitionToState(ScriptableObject.CreateInstance<SpawnState>());
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
        drawTHE();
    }

    public void TransitionToState(StingerEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;
        currentState.EnterState(this);
    }

    public float rayLength = 10f;
    public Color rayColor = Color.red;

    void drawTHE()
    {
        // Get the forward direction of the game object
        Vector3 forwardDirection = transform.forward;

        // Set the starting position of the ray at the game object's position
        Vector3 rayStartPos = transform.position;

        // Set the ending position of the ray using the forward direction and ray length
        Vector3 rayEndPos = rayStartPos + forwardDirection * rayLength;

        // Draw the ray using the Debug.DrawRay method
        Debug.DrawRay(rayStartPos, forwardDirection * rayLength, rayColor);
    }
}
