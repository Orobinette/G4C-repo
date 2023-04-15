using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClickAndDrag : MonoBehaviour
{
    Item item;

    public GameObject selectedObject;
    Vector3 offset;

    SpriteRenderer spriteRenderer;

    GameObject bin;

    GameObject gameControllerObj;
    GlobalVariables globalVariables;

    GameObject levelManagerObj;
    Tutorials tutorials;

    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();

        levelManagerObj = GameObject.FindWithTag("LevelController");
        tutorials = levelManagerObj.GetComponent<Tutorials>();

    }


    void Update() 
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.tag == "item")
            {
                selectedObject = targetObject.transform.gameObject;

                spriteRenderer = selectedObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 1;
                offset = selectedObject.transform.position - mousePosition;

                item = selectedObject.GetComponent<Item>();
                
            }
        }
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
            spriteRenderer.sortingOrder = 2;

            item.CheckForBin();
        }
    }
}
