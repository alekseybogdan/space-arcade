using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class RocketShip : MonoBehaviour
{
    Rigidbody ship;

    public GameObject rocket;
    public Transform[] rocketsPositions;

    public float speed;

    public GameObject explosionEffect;

    private AudioManager _audioManager;

    private GameManager _gameManager;

    private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject.GetComponent<Rigidbody>();
        ship.freezeRotation = true;

        float randomX = Random.Range(-40f, 40f);

        ship.velocity = new Vector3(randomX, 0, -speed);

        var player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
            _playerHealth = player.GetComponent<PlayerHealth>();

        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine("ShootRockets");
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
        else if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            _gameManager.UpdateScore((int) (20 * speed));
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            _audioManager.PlayAsteroidExplosion();
            Destroy(gameObject);
        }
    }

    IEnumerator ShootRockets()
    {
        for (int i = 0; i < rocketsPositions.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(rocket, rocketsPositions[i].position, Quaternion.identity);
        }
    }
}