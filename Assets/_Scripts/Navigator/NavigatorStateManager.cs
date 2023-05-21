using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigatorStateManager : MonoBehaviour
{
    public CameraScriptableObject PlayerCamObject;

    public GameEvent OnIdle,OnThrown,OnAttract;

    [Header ("State Machine")]
    NavigatorBaseState currentState;
    public NavigatorIdleState idleState = new NavigatorIdleState();
    public NavigatorThrownState thrownState = new NavigatorThrownState();
    public NavigatorAttractState attractState = new NavigatorAttractState();

    void Start()
    {

        currentState = idleState;

        currentState.StartState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    void OnTriggerEnter(Collider other) 
    {
        currentState.OnTriggerEnterState(this,other);    
    }

    public void SwitchState(NavigatorBaseState state)
    {
        currentState = state;
        state.StartState(this);
    }

    public void OnClickNavigate()
    {
        currentState.OnClick(this);
    }
}
