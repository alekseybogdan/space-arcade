using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Transform gun;
    public Transform leftGun;
    public Transform rightGun;

    bool isSecondaryWeaponActive = false;
    float weaponBoostTimer;

    public GameObject laser;

    public float shotDelay;

    private float nextShotTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShotTime && Input.GetButton("Jump"))
        {
            Instantiate(laser, gun.position, Quaternion.identity);
            
            if (isSecondaryWeaponActive)
            {
                Instantiate(laser, leftGun.position, leftGun.rotation);
                Instantiate(laser, rightGun.position, rightGun.rotation);

                weaponBoostTimer -= Time.deltaTime;
            }
            
            nextShotTime = Time.time + shotDelay;
        }
    }

    public IEnumerator ActivateSecondaryGuns(float duration)
    {
        isSecondaryWeaponActive = true;
        yield return new WaitForSeconds(duration);
        isSecondaryWeaponActive = false;
    }
}
