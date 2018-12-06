using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAim : MonoBehaviour {

    //another way to accomplish this task
    //   public float speed = 5f;

    //   // Use this for initialization
    //void Start () {

    //}

    //   private void Update()
    //   {
    //       Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //       float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //       Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //       transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    //   }

    // Update is called once per frame
    public void Update()
    {
        //creates a variable to hold the transform position of the main camera's relationship
        //to the screen pointer
        var pos = Camera.main.WorldToScreenPoint(transform.position);

        //creates a variable to designate direction based on mouse position minus pos variable
        var dir = Input.mousePosition - pos;

        //creates a variable to hold the angle of an arc tangent of f - the angle in radians whose tangent is f
        //gets the direction of x and y of the mouse position and converts it to a degree and stores it as an angle
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //this worked but only was off by 270 degrees, subtracting 90 or adding 270 (degrees) made it work
        transform.rotation = Quaternion.AngleAxis(angle + 270, Vector3.forward);

    }
}
