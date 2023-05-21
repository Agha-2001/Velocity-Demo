using UnityEngine;

public class PlayerStaticState : PlayerBaseState
{
    PlayerController p;
    float _velocity;

    public override void StartState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        _velocity = p.Rb.velocity.magnitude;

        if(_velocity > 0)
            player.SwitchState(player.moveState);
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        
    }
}
