using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody rb;

    public GameObject explosionEffect;

    private AudioManager _audioManager;

    private GameManager _gameManager;

    private PlayerHealth _playerHealth;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        var player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.GetComponent<Transform>();
            _playerHealth = player.GetComponent<PlayerHealth>();
        }

        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        transform.LookAt(target);

        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerHealth.Hit();
            _audioManager.PlayAsteroidExplosion();
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Laser") || other.CompareTag("Missile"))
        {
            Destroy(other.gameObject);
            _gameManager.UpdateScore((int)(10 * speed));
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            _audioManager.PlayAsteroidExplosion();
            Destroy(gameObject);
        }
    }
}