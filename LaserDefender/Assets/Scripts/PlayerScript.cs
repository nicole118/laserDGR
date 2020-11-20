using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //can arrage the speed from unity directly
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] GameObject laserPreFab;
    [SerializeField] float laserSpeed = 15f;
    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    Coroutine firingCoroutine;
    bool CoroutineStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        setupMoveBoundaries();
        //StartCoroutine(PrintAndWait());
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Fire();

    }

    //coroutine example
    private IEnumerator FireContinuously()
    {
        while (true)
        {
            //creates an instance (a copy of the prefab) at the position of the laser ship
            //creates a copy of an object
            GameObject laser = Instantiate(laserPreFab, transform.position, quaternion.identity) as GameObject;

            //add velocity in the y-axis
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);

            yield return new WaitForSeconds(0.2F);
        }
    }

    //sets the borders according to the main camera
    private void setupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        //x = 0, according to camera view
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

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



    private void Fire()
    {
        if (!CoroutineStarted)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                firingCoroutine = StartCoroutine(FireContinuously());
                CoroutineStarted = true;

            }

            if (Input.GetButtonUp("Fire1"))
            {
                StopCoroutine(firingCoroutine);
                CoroutineStarted = false;
            }
        }
    }
}
