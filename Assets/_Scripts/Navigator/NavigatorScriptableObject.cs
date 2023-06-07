using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Navigator Object", menuName = "Scriptable Objects/Navigator/Navigator Object", order =1)]
public class NavigatorScriptableObject : ScriptableObject
{
    public GameObject ModelPrefab;
    public Vector3 SpawnPoint;
    public Vector3 SpawnRotation;
    [Tooltip("The force by which the player is pulled")]
    public float AttractionForce;
    [Tooltip("Speed of navigator when thrown")] 
    public float Speed; 
    [Tooltip("Distance at which the player can catch the navigator")]
    public float DetectionRadius; 
    GameObject Throwpoint;
    LineRenderer NavLine;
    GameObject Model;

    public void Spawn(Transform parent)
    {
        Model = Instantiate(ModelPrefab);
        Model.transform.SetParent(parent,false);
        Model.transform.localPosition = SpawnPoint;
        Model.transform.localRotation = Quaternion.Euler(SpawnRotation);

        
    }
}
