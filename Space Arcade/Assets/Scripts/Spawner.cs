using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject explosiveAsteroid;
    public GameObject healthPickup;
    public GameObject weaponBoostPickup;
    public GameObject firingRateBoostPickup;
    public GameObject missileShip;

    public float healthPickupSpawnDelay;
    private float nextHealthPickupSpawnTime;
    
    public float weaponBoostPickupSpawnDelay;
    private float nextWeaponBoostPickupSpawnTime;
    
    public float firingRatePickupSpawnDelay;
    private float nextFiringRatePickupSpawnTime;
    
    public float asteroidSpawnDelay;
    private float nextAsteroidSpawnTime;

    public float explosiveAsteroidSpawnDelay;
    private float nextExplosiveAsteroidSpawnTime;
    
    public float missileShipSpawnDelay;
    private float nextMissileShipSpawnTime;

    private float rightSide;

    public string difficulty;
    // Start is called before the first frame update
    void Start()
    {
        rightSide = transform.localScale.x / 2;
        nextHealthPickupSpawnTime = healthPickupSpawnDelay;
        nextWeaponBoostPickupSpawnTime = weaponBoostPickupSpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObjectsOfDifficulty(difficulty);
        
        if (Time.time > nextHealthPickupSpawnTime)
        {
            SpawnObject(healthPickup);
            nextHealthPickupSpawnTime = Time.time + healthPickupSpawnDelay;
        }
        
        if (Time.time > nextWeaponBoostPickupSpawnTime)
        {
            SpawnObject(weaponBoostPickup);
            nextWeaponBoostPickupSpawnTime = Time.time + weaponBoostPickupSpawnDelay;
        }
        
        if (Time.time > nextFiringRatePickupSpawnTime)
        {
            SpawnObject(firingRateBoostPickup);
            nextFiringRatePickupSpawnTime = Time.time + firingRatePickupSpawnDelay;
        }
    }

    void SpawnObject(GameObject objectToSpawn)
    {
        float randomX = Random.Range(-rightSide, rightSide);
        var pos = new Vector3(randomX, 0, transform.position.z);
        Instantiate(objectToSpawn, pos, objectToSpawn.transform.rotation);
    }

    void SpawnObjectsOfDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                if (Time.time > nextAsteroidSpawnTime)
                {
                    SpawnObject(asteroid);
                    nextAsteroidSpawnTime = Time.time + asteroidSpawnDelay;
                }

                break;
            case "medium":
                if (Time.time > nextAsteroidSpawnTime)
                {
                    SpawnObject(asteroid);
                    nextAsteroidSpawnTime = Time.time + asteroidSpawnDelay;
                }
                if (Time.time > nextExplosiveAsteroidSpawnTime)
                {
                    SpawnObject(explosiveAsteroid);
                    nextExplosiveAsteroidSpawnTime = Time.time + explosiveAsteroidSpawnDelay;
                }

                break;
            case "hard":
                if (Time.time > nextMissileShipSpawnTime)
                {
                    SpawnObject(missileShip);
                    nextMissileShipSpawnTime = Time.time + missileShipSpawnDelay;
                }

                break;
        }
    }
}
