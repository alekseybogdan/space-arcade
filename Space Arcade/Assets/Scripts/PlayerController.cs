using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody ship;
    public Transform gunPosition;
    public Transform leftSideGunPosition;
    public Transform rightSidegunPosition;

    public float speed;
    public float tilt;

    public float xMin, xMax, zMin, zMax;
    // Start is called before the first frame update
    void Start()
    {
        ship = gameObject.GetComponent<Rigidbody>();
        ship.velocity = new Vector3(0, 0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(horizontal, 0, vertical) * speed;

        float correctX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float correctZ = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(correctX, 0, correctZ);
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);

        gunPosition.position = transform.position;
        leftSideGunPosition.position = transform.position;
        rightSidegunPosition.position = transform.position;
    }
}
