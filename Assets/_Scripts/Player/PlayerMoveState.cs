using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    PlayerController p;
    bool _clamp;
    public override void StartState(PlayerStateManager player)
    {
        p = PlayerController.instance;

        _clamp = false;
    }

    public override void UpdateState(PlayerStateManager player)
    {/*
        if(p.Rb.velocity.magnitude > p.MaxSpeed)
            _clamp = true;
        else if(p.Rb.velocity.magnitude <= p.MaxSpeed - 20f)
            _clamp = false;

        if(p.Rb.velocity.magnitude <= 0)
            player.SwitchState(player.staticState);*/
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        //if(_clamp)
        //{
            p.Rb.velocity = Vector3.ClampMagnitude(p.Rb.velocity, p.MaxSpeed);
        //}
    }
}
