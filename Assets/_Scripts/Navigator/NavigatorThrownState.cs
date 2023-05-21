using UnityEngine;

public class NavigatorThrownState : NavigatorBaseState
{
    NavigatorController n;
    Vector3 _destination;

    public override void StartState(NavigatorStateManager navigator)
    {
        navigator.OnThrown.Invoke();

        n = NavigatorController.instance;

        navigator.transform.SetParent(null);     

        /*RaycastHit hitInfo;
        Ray ray;           

        ray = n.PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out hitInfo , 3000f))
        {   
            _destination = hitInfo.point;
        }*/

        _destination = navigator.PlayerCamObject.GetHitPoint(Camera.main,3000f).point;
    }

    public override void UpdateState(NavigatorStateManager navigator)
    {
        n.NavLine.positionCount = 2;
        n.NavLine.SetPosition(0, n.Throwpoint.transform.position);
        n.NavLine.SetPosition(1, navigator.transform.position);
    }

    public override void FixedUpdateState(NavigatorStateManager navigator)
    {
        navigator.transform.position = Vector3.MoveTowards(navigator.transform.position, _destination, n.Speed * Time.deltaTime);  
    }

    public override void OnTriggerEnterState(NavigatorStateManager navigator, Collider collider)
    {
        
    }

    public override void OnClick(NavigatorStateManager navigator)
    {
        navigator.SwitchState(navigator.attractState);
    }
}