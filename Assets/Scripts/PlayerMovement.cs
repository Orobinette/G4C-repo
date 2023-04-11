using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

/*********
*VARIABLES
**********/

    //Self References
    [SerializeField] Rigidbody2D rb;

    //Script Variables
    float speed = 5f; 
    Vector3 movement = new Vector3 (0, 0, 0); //The direction the player is moving
    List<GameObject> collisionList = new List<GameObject>();
    public GameObject heldItem;
    Vector3 offset = new Vector3();


/*********
*FUNCTIONS
**********/


    //Built-In Functions
    void Start() 
    {
        offset = new Vector3(1f, 0f, 0f);
    }

    void Update()
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

        if(Input.GetKeyDown("e") && collisionList[collisionList.Count] != null)
        {
            SwapItem(collisionList[collisionList.Count]);
        }
    }

    void FixedUpdate ()
    {
        rb.MovePosition(rb.transform.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        collisionList.Add(other.gameObject);
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        foreach(GameObject _object in collisionList)
        {
            if(_object == other)
            {
                collisionList.Remove(_object);
            }
        }
    }   

    void SwapItem(GameObject item)
    {
        heldItem.transform.parent = null;
        heldItem = item;
        heldItem.transform.position = new Vector3(transform.position.x + offset.x, transform.position.y, 0f);
        heldItem.transform.SetParent(this.transform);
    }

    void FlipSprite()
    {
        //sprite.flip
        offset = new Vector3(-offset.x, 0f, 0f);
    }
}
