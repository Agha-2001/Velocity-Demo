using UnityEngine;

public class NavigatorThrownState : NavigatorBaseState
{
    NavigatorController n;
    Vector3 _destination;

    bool stop;

    public override void StartState(NavigatorStateManager navigator)
    {
        navigator.OnThrown.Invoke();

        stop = false;

        n = NavigatorController.GetInstance();

        navigator.transform.SetParent(null);

        _destination = Camera.main.transform.forward;
    }

    public override void UpdateState(NavigatorStateManager navigator)
    {
        n.NavLine.positionCount = 2;
        n.NavLine.SetPosition(0, n.Throwpoint.transform.position);
        n.NavLine.SetPosition(1, navigator.transform.position);
    }

    public override void FixedUpdateState(NavigatorStateManager navigator)
    {
        if (!stop)
            navigator.transform.position = navigator.transform.position + _destination * n.Speed * Time.deltaTime;
        //navigator.transform.position = Vector3.MoveTowards(navigator.transform.position, _destination, n.Speed * Time.deltaTime);  
    }

    public override void OnTriggerEnterState(NavigatorStateManager navigator, Collider collider)
    {
        if (collider.CompareTag("Arena"))
            stop = true;
    }

    public override void OnClick(NavigatorStateManager navigator)
    {
        navigator.SwitchState(navigator.attractState);
    }
}