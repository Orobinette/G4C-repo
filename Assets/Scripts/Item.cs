using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    GameObject gameControllerObj;
    GlobalVariables globalVariables;

    GameManager gameManager;
    GameObject gameManagerObj;
    ClickAndDrag clickAndDrag;
    Tutorials tutorials;
    Camera camera;

    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite easySprite;

    public string trashType;
    bool onCorrectBin = false;
    bool onBin = false;

    void Start() 
    {
        camera = Camera.main;

        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();

        gameManagerObj = GameObject.FindWithTag("LevelController");
        gameManager = gameManagerObj.GetComponent<GameManager>();
        clickAndDrag = gameManagerObj.GetComponent<ClickAndDrag>();

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        /*
        if(globalVariables.difficulty == "easy")
        {
            spriteRenderer.sprite = easySprite;
        }
        */

        if(SceneManager.GetActiveScene().name == "RecyclingTutorial") 
        {
            tutorials = gameManagerObj.GetComponent<Tutorials>();
        }

        clickAndDrag.UpdateItems("add", this.gameObject);
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
            if(SceneManager.GetActiveScene().name == "RecyclingTutorial") 
            {
                if(onCorrectBin == true)
                {
                    tutorials.index++;
                    tutorials.SpawnItem();
                }
                else
                {
                    this.gameObject.transform.position = Vector3.zero;
                    tutorials.PopUp();
                    return;
                }
            }
            else 
            {
                if(onCorrectBin == true)
                {
                    gameManager.ChangeScore(1);
                }
                else 
                {
                    gameManager.ChangeScore(-1);
                }
            }
            Despawn();
        }
    }

    void Despawn() 
    {
        clickAndDrag.UpdateItems("remove", this.gameObject);
        Destroy(this.gameObject);
    }
}
