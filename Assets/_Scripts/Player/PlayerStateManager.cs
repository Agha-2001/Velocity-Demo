using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    [Header ("State Machine")]
    PlayerBaseState currentState;
    public PlayerStaticState staticState = new PlayerStaticState();
    public PlayerMoveState moveState = new PlayerMoveState();

    void Start()
    {
        currentState = staticState;
        
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

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.StartState(this);
    }
}
