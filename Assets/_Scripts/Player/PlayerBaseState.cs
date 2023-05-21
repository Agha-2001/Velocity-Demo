using UnityEngine;

public abstract class PlayerBaseState 
{
    public abstract void StartState(PlayerStateManager player);
    public abstract void UpdateState(PlayerStateManager player);
    public abstract void FixedUpdateState(PlayerStateManager player);
}
