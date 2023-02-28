using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{

/*********
*VARIABLES
**********/

    //Script References
    [SerializeField] ObsGameManager gameManager;

    //Component References
    public Transform truckTrans;
    public Rigidbody2D rb;

    //Scripting Variables
    float acceleration = 0;
    float minAcceleration = 0;
    float maxAcceleration = 5;
    float ramp = 0.02f;

    bool moving = false;


/**********
*FUNCTIONS
***********/
    
    //Built-In
    void Update () 
    {
        if(gameManager.game_state == 0)
        {
            //Setup
            moving = false;
            
            //Acceleration
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
            {
                moving = true;
                Accelerate();
            }
            else
            {
                Decelerate();
            }

            //Turning
            if (Input.GetKey(KeyCode.LeftArrow) && moving == true || Input.GetKey("a") && moving == true)
            {
                transform.Rotate(0, 0, 0.5f);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && moving == true || Input.GetKey("d") && moving == true)
            {
                transform.Rotate(0, 0, -0.5f);
            }  
            if(Input.GetKeyUp("e"))
            {
                gameManager.SwitchGameState(1);
            }

        }    
        else if (gameManager.game_state == 1) 
        {
            acceleration = 0f; //Prevents acceleration Glitch
        }
    }    
    
    
    void FixedUpdate()
    {
        transform.Translate(0, acceleration * Time.deltaTime, 0, Space.Self);
    }
    
    //Custom Functions
    void Accelerate() 
    {
        acceleration += ramp;
        if(acceleration < minAcceleration)
        {
            acceleration = minAcceleration;
        }
        else if(acceleration > maxAcceleration)
        {
            acceleration = maxAcceleration;
        }    
    }
    
    void Decelerate() 
    {
        acceleration -= ramp;
        if(acceleration < minAcceleration)
        {
            acceleration = minAcceleration;
        }
        else if(acceleration > maxAcceleration)
        {
            acceleration = maxAcceleration;
        }
    }
}
