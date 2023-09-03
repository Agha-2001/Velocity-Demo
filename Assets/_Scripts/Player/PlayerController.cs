using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public static PlayerController instance;

    [Header("Attributes")]
    [Tooltip("Highest speed the player can reach")]
    public float MaxSpeed;

    [Header("References")]
    [HideInInspector] public Rigidbody Rb;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(this);

        Rb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Rb.velocity = Vector3.ClampMagnitude(Rb.velocity, MaxSpeed);
    }
}
