using UnityEngine;

public class NavigatorIdleState : NavigatorBaseState
{
    NavigatorController n;
    bool _inHand, _inPlace;

    public override void StartState(NavigatorStateManager navigator)
    {
        navigator.transform.localPosition = Vector3.zero;

        navigator.OnIdle.Invoke();

        n = NavigatorController.instance;

        n.NavLine.positionCount = 0;
        

        _inHand = false;
        _inPlace = false;
    }

    public override void UpdateState(NavigatorStateManager navigator)
    {
       if(navigator.transform.parent != n.Throwpoint.transform.parent)
        {
            _inHand = true;
            
            if(navigator.transform.position !=n.Throwpoint.transform.position)
                _inPlace = true;
        }
    }

    public override void FixedUpdateState(NavigatorStateManager navigator)
    {
        if(_inHand)
        {
            navigator.transform.SetParent(n.Throwpoint.transform);

            if(_inPlace)
                navigator.transform.position = n.Throwpoint.transform.position;
            
            _inHand = false;
            _inPlace = false;
        }

        navigator.transform.Rotate( Vector3.right , 45f * Time.deltaTime);        
    }

    public override void OnTriggerEnterState(NavigatorStateManager navigator, Collider collider)
    {
        
    }

    public override void OnClick(NavigatorStateManager navigator)
    {
        navigator.SwitchState(navigator.thrownState);   
    }
}
