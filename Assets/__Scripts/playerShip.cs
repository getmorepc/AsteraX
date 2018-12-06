using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShip : MonoBehaviour {

    //for movement system
    public float shipSpeed; //float variable to store the player's movement speed
    private Rigidbody rb2d; //store a rigidbody2d component to allow for physics

    //for weapons system
    public GameObject bulletPrefab; //for weapons system
    public Transform bulletSpawn; //location of the Bullet Spawn
    public float bulletSpeed;

    //for tilt
    public float torque;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody>();

        //for weapons system to anchor to empty game object bulletAnchor
        GameObject bulletAnchor;
        bulletAnchor = new GameObject("bulletAnchor");
	}

    //FixedUpdate is called at a fixed interval and is independent of frame rate. For physics code

    private void FixedUpdate()
    {
        //for movement system
        //store the current horizontal input in the variable
        float moveHorizontal = Input.GetAxis("Horizontal");
        //store the current vertial input in the variable
        float moveVertical = Input.GetAxis("Vertical");
        //use the two stored floats to create a new Vector2 variable movement
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //call the addforce function of our rigidbody2d rb2d supplying movement multipies by speed to move our player
        rb2d.AddForce(movement * shipSpeed);

        //for tilt
        float turn = Input.GetAxis("Horizontal");
        rb2d.AddTorque(torque * transform.up * turn);

    }
    // Update is called once per frame
    void Update () {

        //if loop for weapons system for Mouse 0, left mouse key
        if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();
            }

        }

    //fire function to create bullet prefab, manage and destroy
    void Fire()
    {
        //Create the bullet
        var bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        bullet.transform.parent = GameObject.Find("bulletAnchor").transform;

        //add velocity to the bullet
        bulletSpeed = 6;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;

        //Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);

    }
    
}
