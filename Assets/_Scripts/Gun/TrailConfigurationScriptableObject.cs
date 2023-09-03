using UnityEngine;

[CreateAssetMenu(fileName = "Trail Config", menuName = "Scriptable Objects/Gun/Gun Trail Configuration", order = 4)]
public class TrailConfigurationScriptableObject : ScriptableObject
{
    public Material Material;
    public AnimationCurve WidthCurve;
    public float Duration = 0.5f;
    public float MinVertexDistance = 0.1f;
    public Gradient Color;

    public float MissDistance = 100f;
    public float SimulationSpeed = 100f;
}
