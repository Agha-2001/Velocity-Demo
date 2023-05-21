using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigatorController : MonoBehaviour
{
    [HideInInspector] public static NavigatorController instance;


    [Header ("Attributes")]
    [Tooltip("The force by which the player is pulled")]
    public float AttractionForce;
    [Tooltip("Speed of navigator when thrown")] 
    public float Speed; 
    [Tooltip("Distance at which the player can catch the navigator")]
    public float DetectionRadius; 


    [HideInInspector] public GameObject Throwpoint;
    [HideInInspector] public Camera PlayerCam; // Might remove afterwards.
    [HideInInspector] public LineRenderer NavLine;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        
        else if(instance != this)
            Destroy(this);
        
        Throwpoint = GameObject.Find("Throwpoint");
        PlayerCam = Camera.main;
        NavLine = GameObject.Find("Nav Line").GetComponent<LineRenderer>();
    }
}
