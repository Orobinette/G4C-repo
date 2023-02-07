using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public Transform truckTrans;
    public Rigidbody2D rb;

    //Scripting Variables
    float acceleration = 0;
    float minAcceleration = 0;
    float maxAcceleration = 5;
    float ramp = 0.02f;

    bool moving = false;
 
    
    void Update () 
    {
        if(gameManager.game_state == 0)
        {
            moving = false;
            
            if (Input.GetKey(KeyCode.UpArrow) )
            {
                moving = true;
                Accelerate();
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moving = true;
                Accelerate(); 
            }
            else
            {
                acceleration = 0;
            }

            if (Input.GetKey(KeyCode.LeftArrow) && moving == true)
            {
                transform.Rotate(0, 0, 0.5f);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && moving == true)
            {
                transform.Rotate(0, 0, -0.5f);
            }  
            if(Input.GetKeyUp("e"))
            {
                gameManager.SwitchGameState(1);
            }

        }    
    }    
    
    
    void FixedUpdate()
    {
        transform.Translate(0, acceleration * Time.deltaTime, 0, Space.Self);
    }
    
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
    
}
