using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Camera camera;

    public Transform truckTrans;
    public Rigidbody2D rb;

    //Scripting Variables
    float acceleration = 0;
    float minAcceleration = 0;
    float maxAcceleration = 5;
    
    bool moving = false;
 
    
    void Update () 
    {
        if(gameManager.game_state == 0)
        {
            moving = false;
            
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                moving = true;
                Accelerate(0.02f);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                moving = true;
                Accelerate(-0.02f); 
            }
            else
            {
                acceleration = 0;
            }

            if (Input.GetKey(KeyCode.LeftArrow) && moving == true || Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, 0, 0.5f);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && moving == true || Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -0.5f);
            }  
            if(Input.GetKeyUp("e"))
            {
                gameManager.SwitchGameState(1);
            }

            



            //camera.transform.position = new Vector3(truckTrans.position.x, truckTrans.position.y, -10);
        }    
    }    
    
    
    void FixedUpdate()
    {
        transform.Translate(0, acceleration * Time.deltaTime, 0, Space.Self);
    }
    
    void Accelerate(float ramp) 
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
