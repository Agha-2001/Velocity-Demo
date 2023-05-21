using UnityEngine;

public abstract class NavigatorBaseState 
{
     public abstract void StartState(NavigatorStateManager navigator);
     public abstract void UpdateState(NavigatorStateManager navigator);
     public abstract void FixedUpdateState(NavigatorStateManager navigator);
     public abstract void OnTriggerEnterState(NavigatorStateManager navigator, Collider collider);
     public abstract void OnClick(NavigatorStateManager navigator);
     
}
