using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    ClickAndDrag clickAndDrag;
    GameManager gameManager;
    Camera camera;

    [SerializeField] string trashType;
    bool onCorrectBin = false;
    bool onBin = false;

    void Start() 
    {
        camera = Camera.main;
        clickAndDrag = camera.GetComponent<ClickAndDrag>();
        gameManager = camera.GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.name == trashType)
        {
            onCorrectBin = true;
        }
        else if(other.name != trashType)
        {
            onCorrectBin = false;
        }
        if(other.tag == "bin")
        {
            onBin = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "bin")
        {
            onCorrectBin = false;
            onBin = false;
        }
    }

    public void CheckForBin() 
    {
        if(onBin == true)
        {
            if(onCorrectBin == true)
            {
                gameManager.score ++;
            }
            else 
            {
                gameManager.score --;
            }
            Destroy(this.gameObject);
        }
        Debug.Log(gameManager.score);
    }
}
