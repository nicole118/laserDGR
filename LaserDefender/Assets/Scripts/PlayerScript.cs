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
        private void Move()
        {

            //var is used as a generic variable. VS will set its type according to its value.

            // the variable deltaX will be updated with the input that will happen on the x-axis, left and right
            var deltaX = Input.GetAxis("Horizontal");
            var newXPos = transform.position.x + deltaX;

            //the x-position (left or right direction) will be updated according to the variable 'newXPos'
            //Y position will stay the same
            transform.position = new Vector2(newXPos, transform.position.y);
        }
    }
}
