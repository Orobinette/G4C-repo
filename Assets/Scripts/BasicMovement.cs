using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] Camera camera;
    
    [SerializeField] Transform trans;
    [SerializeField] Rigidbody2D rb;

    int acceleration = 0;


    void Update()
    {
        acceleration = 0;
        
        if(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            acceleration = 2;
        }
        if(Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            acceleration = -2;
        }
        if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 0.75f);
        }
        if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -0.75f);
        }

        camera.transform.position = new Vector3(trans.position.x, trans.position.y, camera.transform.position.z);
    }


    void FixedUpdate ()
    {
        //Move the player in the movement direction (1 or -1) * it's walking speed
        transform.Translate(0, acceleration * Time.deltaTime, 0, Space.Self);
    }
    
}
