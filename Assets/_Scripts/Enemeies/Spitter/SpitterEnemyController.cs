using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterEnemyController : MonoBehaviour
{
    SpitterEnemyState currentState;
    [HideInInspector] public SpitState spitState;
    [HideInInspector] public MoveState moveState;
    [HideInInspector] public SpitterSpawnState spawnState;

    public EnemyScriptableObject enemyData;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        spitState = new SpitState();
        moveState = new MoveState();
        spawnState = new SpitterSpawnState();
        currentState = spawnState;

        currentState.StartState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnterState(this, other);
    }

    public void SwitchState(SpitterEnemyState state)
    {
        currentState = state;
        state.StartState(this);
    }
}
