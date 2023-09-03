using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerEnemyController : MonoBehaviour
{
    SeekerEnemyState currentState;
    [HideInInspector] public SeekerSpawnState spawnState;
    [HideInInspector] public LaunchState launchState;
    [HideInInspector] public ChargeUpState chargeUpState;

    public EnemyScriptableObject enemyData;
    public ParticleSystem charge;

    [HideInInspector] public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        spawnState = new SeekerSpawnState();
        launchState = new LaunchState();
        chargeUpState = new ChargeUpState();

        currentState = spawnState;

        currentState.StartState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void FixedUpdateState()
    {
        currentState.FixedUpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    public void SwitchState(SeekerEnemyState state)
    {
        currentState = state;
        currentState.StartState(this);
    }
}
