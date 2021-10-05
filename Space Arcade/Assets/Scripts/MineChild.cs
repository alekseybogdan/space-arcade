using UnityEngine;
using Random = UnityEngine.Random;

public class MineChild : MonoBehaviour
{
    private Rigidbody rb;

    public float minSpeed, maxSpeed;
    public float minAngularSpeed, maxAngularSpeed;
    private float speed, angularSpeed, size;

    public GameObject asteroidExplosion;

    private AudioManager _audioManager;

    private GameManager _gameManager;

    private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        size = Random.Range(0.5f, 0.6f);
        transform.localScale *= size;

        speed = Random.Range(minSpeed, maxSpeed);
        speed /= size;
        angularSpeed = Random.Range(minAngularSpeed, maxAngularSpeed);

        float childSpeed = Random.Range(5f, 10f);
        float randomX = Random.Range(-10, 10);
        float randomZ = Random.Range(-10, 10);

        rb.velocity = new Vector3(randomX, 0, randomZ) * childSpeed;
        rb.angularVelocity = Random.insideUnitCircle * angularSpeed;

        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerHealth = player.GetComponent<PlayerHealth>();
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerHealth.Hit();
            _audioManager.PlayAsteroidExplosion();
            Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            _gameManager.UpdateScore((int) (10 * size));
            Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
            _audioManager.PlayAsteroidExplosion();
            Destroy(gameObject);
        }
    }
}