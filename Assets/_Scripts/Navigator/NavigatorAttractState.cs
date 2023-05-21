using UnityEngine;

public class NavigatorAttractState : NavigatorBaseState
{
    NavigatorController n;
    PlayerController player;
    Vector3 direction;
    public override void StartState(NavigatorStateManager navigator)
    {
        navigator.OnAttract.Invoke();

        n = NavigatorController.instance;
        player = PlayerController.instance;

        player.Rb.isKinematic = true;
    }

    public override void UpdateState(NavigatorStateManager navigator)
    {
        player.Rb.isKinematic = false;

        Vector3 CurrentPosition = navigator.transform.position;
        Vector3 PlayerPosition = player.Rb.position;        

       if(Vector3.Distance(PlayerPosition,CurrentPosition) < n.DetectionRadius)
            navigator.SwitchState(navigator.idleState);

        n.NavLine.positionCount = 2;
        n.NavLine.SetPosition(0, n.Throwpoint.transform.position);
        n.NavLine.SetPosition(1, navigator.transform.position);

        direction = CurrentPosition - PlayerPosition;
    }

    public override void FixedUpdateState(NavigatorStateManager navigator)
    {
        player.Rb.AddForce(direction * n.AttractionForce * Time.deltaTime);
    }

    public override void OnTriggerEnterState(NavigatorStateManager navigator, Collider collider)
    {
        
            
    }

    public override void OnClick(NavigatorStateManager navigator)
    {
        navigator.SwitchState(navigator.idleState);
    }
}
