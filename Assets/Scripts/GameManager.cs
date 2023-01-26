using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

/*********
*VARIABLES
**********/

    //Object References
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject binPrefab;

    //Class References
    [SerializeField] TruckMovement truckMovement;
    [SerializeField] PlayerMovement playerMovement;

    //Script Variables
    public int score = 0;
    [HideInInspector] public int game_state; //0 = drive, 1 = walk

    Vector3 offset = new Vector3(-1, 0, 0); //Spawn point of player from truck 

    int adjustment = 1;


/*********
*FUNCTIONS
**********/

    //Built-In Functions
    void Start() 
    {
        game_state = 0; 

        for(var i = 0; i <= 5; i++) //Spawn 5 bins
        {
            Instantiate(binPrefab, new Vector3(Random.Range(0, 5), Random.Range(0, 5), 0), Quaternion.identity);
        }
    }

    //Custom Functions
    public void SwitchGameState(int new_state) //Switch Between Driving and Walking (parameter = the new state)
    {
        game_state = new_state; 

        if(game_state == 0)
        {
            //Establish Constrainss
            truckMovement.rb.constraints = RigidbodyConstraints2D.None;
            playerMovement.rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            //Despawn Player
            playerMovement.playerRender.enabled = false;
            playerMovement.playerTrans.parent = truckMovement.truckTrans;
        }
        if(game_state == 1)
        {
            //Establish Constraints
            truckMovement.rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
            playerMovement.rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            //Spawn in player
            playerMovement.playerTrans.parent = null;
            playerMovement.playerTrans.position = truckMovement.truckTrans.position - offset; 
            playerMovement.playerTrans.rotation = Quaternion.identity;
            playerMovement.playerRender.enabled = true;
        }
    }

    public void ChangeScore(int adjustment) 
    {
        score += adjustment;
        scoreText.text = score.ToString();
    }
}
