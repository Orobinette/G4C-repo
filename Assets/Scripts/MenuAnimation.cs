using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuAnimation : MonoBehaviour
{
/*********
*VARIABLES
**********/

    GameObject gameControllerObj;
    GlobalVariables globalVariables;

    [SerializeField] TMP_Text highScoreText;

    GameObject truck;
    [SerializeField] GameObject truckPrefab;
    [SerializeField] List<Sprite> truckSprites = new List<Sprite>();
    int truckType; // value for truckSprites
    SpriteRenderer renderer;
    Rigidbody2D rb;

    Vector3 spawnPoint; 
    Vector3 direction;
    Vector3 speed = new Vector3(8f, 0f, 0f);


/*********
*FUNCTIONS
**********/

    void Start() 
    {
        InvokeRepeating("SpawnTruck", 0f, Random.Range(3f, 5f));

        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();
        highScoreText.text = "HighScore: " + globalVariables.highScore.ToString();
    }

    void FixedUpdate() 
    {
        
        if(truck != null)
        {
            rb.MovePosition(rb.transform.position + Vector3.Scale(direction, speed) * Time.fixedDeltaTime);

            if(truck.transform.position.x >= Mathf.Abs(10f))
            {
                Destroy(truck);
            }
        }
        
    }

    void SpawnTruck() 
    {
        truckType = Random.Range(0, 7);
        if(truckType < 4)
        {
            spawnPoint = new Vector3(10f, -4f, 0f);
            direction = new Vector3(-1f, -0f, 0f);
        }
        else 
        {
            spawnPoint = new Vector3(-10f, -4f, 0f);
            direction = new Vector3(1f, 0f, 0f);
        }

        truck = Instantiate(truckPrefab, spawnPoint, Quaternion.identity);
        renderer = truck.GetComponent<SpriteRenderer>();
        rb = truck.GetComponent<Rigidbody2D>();
        renderer.sprite = truckSprites[truckType];
    }
}
