using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealthPickup : MonoBehaviour
{
    public int healthPoints;
    private Rigidbody rb;
    public float speed = 20f, angularSpeed = 5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -speed);
        rb.angularVelocity = Random.insideUnitCircle * angularSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().ApplyHealth(healthPoints);
            Destroy(gameObject);
        }
    }
}
