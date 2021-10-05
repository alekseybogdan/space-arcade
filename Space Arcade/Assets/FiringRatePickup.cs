using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringRatePickup : MonoBehaviour
{
    public float duration;
    Rigidbody rb;
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
            other.gameObject.GetComponent<PlayerGun>().StartCoroutine("BoostFiringRate", duration);
            Destroy(gameObject);
        }
    }
}