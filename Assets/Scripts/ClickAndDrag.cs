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

    static List<GameObject> activeItems = new List<GameObject>();

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

    public void UpdateItems(string action, GameObject obj) 
    {
        if(action == "add")
        {
            activeItems.Add(obj);
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, activeItems.Count);
        }
        else if (action == "remove")
        {
            activeItems.Remove(obj);
            foreach(GameObject item in activeItems) 
            {
                item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, activeItems.Count);
            }
        }
        else
        {
            activeItems = new List<GameObject>();
        }
    }   
}
