using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

/*********
*VARIABLES
**********/

    //Object and Class References
    [SerializeField] GameManager gameManager;

    //Self References
    public Transform playerTrans;
    public Rigidbody2D rb;
    public SpriteRenderer playerRender;

    //Script Variables
    float speed = 5f; 
    Vector3 movement = new Vector3 (0, 0, 0); //The direction the player is moving

    public bool on_truck = false;


/*********
*FUNCTIONS
**********/

    //Built-In Functions
    void Update()
    {
        if(gameManager.game_state == 1) // While Walking
        {
            movement = new Vector3(0, 0, 0); //Lines 36-60: Movement controls in all directions
        
            if(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
            {
                movement.y += 1;

            }
            if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            {
                movement.x -= 1;

            }
            if(Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
            {
                movement.y -= 1;

            }
            if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            {
                movement.x += 1;
            }

            if(Input.GetKeyUp("e") && on_truck == true)
            {
                gameManager.SwitchGameState(0);
            }
        }
    }

    void FixedUpdate () //Apply movement
    {
        rb.MovePosition(rb.transform.position + movement * speed * Time.fixedDeltaTime);
    }

    //Collisions
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "LoadingZone")
        {
            on_truck = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.name == "LoadingZone")
        {
            on_truck = false;
        }
    }
}
