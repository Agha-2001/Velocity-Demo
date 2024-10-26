using UnityEngine;

[CreateAssetMenu(fileName = "Shoot Config", menuName = "Scriptable Objects/Gun/Shoot Configuration", order = 2)]
public class ShootConfigurationScriptableObject : ScriptableObject
{
    public LayerMask HitMask;
    public float FireRate;
    public float SphereRadius;
}
