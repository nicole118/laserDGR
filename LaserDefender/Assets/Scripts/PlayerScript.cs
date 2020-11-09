using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //can arrage the speed from unity directly
    [SerializeField] float movementSpeed = 10f;

    float xMin, xMax, yMin, yMax;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setupMoveBoundaries();
            Move();
    }

    //sets the borders according to the main camera
    private void setupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        //x = 0, according to camera view
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

    }

    //move the player
    private void Move()
    {
        //var is used as a generic variable. VS will set its type according to its value.

        //this will get the difference of the x-axis and y-axis that the player moves
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime;

        //the new position will be the current position of x (transform.position.x) + the diffence of x (deltaX)
        var newXPos = transform.position.x + deltaX;
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //the new position will be the current position of y (transform.position.y) + the diffence of y (deltaY)
        var newYPos = transform.position.y + deltaY;
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        //transfrom.position = current position of player
        //Vectior2 = a point in 2d space   ||   Vector3 = a point in 3d space

        //the x-position and y-positionwill be updated according to these 2 variables.
        transform.position = new Vector2(newXPos, newYPos);
    }
}
