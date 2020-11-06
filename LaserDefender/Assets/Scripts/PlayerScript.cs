using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    //move the player
    private void Move()
    {
        //var is used as a generic variable. VS will set its type according to its value.

        //this will get the difference of the x-axis and y-axis that the player moves
        var deltaX = Input.GetAxis("Horizontal");
        var deltaY = Input.GetAxis("Vertical");

        //the new position will be the current position of x (transform.position.x) + the diffence of x (deltaX)
        var newXPos = transform.position.x + deltaX;
        //the new position will be the current position of y (transform.position.y) + the diffence of y (deltaY)
        var newYPos = transform.position.y + deltaY;

        //transfrom.position = current position of player
        //Vectior2 = a point in 2d space   ||   Vector3 = a point in 3d space

        //the x-position and y-positionwill be updated according to these 2 variables.
        transform.position = new Vector2(newXPos, newYPos);
    }
}
