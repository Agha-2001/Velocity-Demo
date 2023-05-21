using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Camera object", menuName = "Scriptable Objects/Camera/Camera Object", order =1)]
public class CameraScriptableObject : ScriptableObject
{
    public float CameraSensitivity;
    public float CameraShake;
    public float MinFOV;
    public float MaxFOV;
    

    public void CastDebugArray(Camera cam, Color rayColor, float RayDistance)
    {
        Ray CameraRay;
        CameraRay = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Debug.DrawRay(CameraRay.origin, CameraRay.direction * RayDistance, rayColor);
    }

    public RaycastHit GetHitPoint(Camera cam, float RayDistance)
    {
        Ray ray;
        RaycastHit HitObject;

        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Physics.Raycast(ray.origin, ray.direction, out HitObject, RayDistance);
        
        return HitObject;
    }
}
