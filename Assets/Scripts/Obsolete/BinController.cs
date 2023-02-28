using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinController : MonoBehaviour
{
    /*
    TODO

    -Fix loading bin into truck conditions
    */


/*********
*VARIABLES
**********/
    
    //Self references
    [SerializeField] Transform binTrans; //Transform
    [SerializeField] SpriteRenderer binRenderer; //Sprite Renderer
    [SerializeField] List<Sprite> spriteList = new List<Sprite>(); //Possible Sprites

    //Object References
    GameObject gameManagerObj; ObsGameManager gameManager; //GameManager References
    GameObject playerObj; PlayerMovement playerMovement; //Player References

    //Script Variables
    bool pickup = false; //0 = false, 1 = true
    bool grabbable = false; //Whether or not the player is touching the bin




/*********
*FUNCTIONS
**********/

    //Built-In Functions

    void Start() 
    {
        //Establish object and script references
        playerObj = GameObject.Find("Player");
        playerMovement = playerObj.GetComponent<PlayerMovement>(); //Player Obj

        gameManagerObj = GameObject.Find("GameManager");
        //gameManager = gameManagerObj.GetComponent<GameManager>(); //GameManager Obj

        //Bin Construction
        this.gameObject.tag = "bin"; 
        
        binRenderer.sprite = spriteList[Random.Range(0, 2)];
    }
    
    void Update()
    {
        if(Input.GetKeyUp("space"))
        {
            Pickup();
        }
    }
    
    //Collision Functions

    void OnCollisionStay2D(Collision2D other) //Colliding w/ player
    {
        if(other.gameObject.name == "Player")
        {
            grabbable = true;
        }
    }
    void OnCollisionExit2D(Collision2D other) //Not colliding w/ player
    {
        if(other.gameObject.name == "Player")  
        {
            grabbable = false;
        }  
    }
    void OnTriggerStay2D(Collider2D other) //If putdown on truck by player
    {
        if(pickup == false && gameManager.game_state == 1 && other.gameObject.name == "Loading Zone") 
        {
            Destroy(this.gameObject);
            gameManager.ChangeScore(1);
        }
    }

    //Custom Functions

    void Pickup() //When space is pressed while out of truck
    {
        if(gameManager.game_state == 1) 
        {
            if(pickup == false && grabbable == true) //Pickup
            {
                binTrans.parent = playerMovement.playerTrans;
                pickup = true;
            }
            else if(pickup == true) //Putdown
            {
                binTrans.parent = null;
                pickup = false;
            }
        }
    }
}
