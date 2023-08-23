using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f;

    private Vector3 initialVelocity;

    public void LaunchProjectile(Vector3 velocity)
    {
        initialVelocity = velocity;
    }

    private void Start()
    {
        Destroy(gameObject, 15f);
    }

    private void Update()
    {
        // Move the projectile manually using the initial velocity
        transform.position += initialVelocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(1);
            // Handle player collision here
        }
        else if (other.gameObject.CompareTag("Arena"))
        {
            Destroy(gameObject);
        }
    }
}
