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
        activeItems = new List<GameObject>();

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
            spriteRenderer.sortingLayerName = "topItem";
        }
        
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject.GetComponent<SpriteRenderer>().sortingLayerName = "item";
            selectedObject = null;

            item.CheckForBin();
        }
    }

    public void UpdateItems(string action, GameObject obj) 
    {
        if(action == "add")
        {
            activeItems.Add(obj);
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, activeItems.Count);
            obj.GetComponent<SpriteRenderer>().sortingOrder = activeItems.Count;
        }
        else if (action == "remove")
        {
            activeItems.Remove(obj);

            if(activeItems.Count != 0) 
            {
                for(int _i = 0; _i < activeItems.Count; _i++) 
                {
                    activeItems[_i].transform.position = new Vector3(activeItems[_i].transform.position.x, activeItems[_i].transform.position.y, activeItems.Count);
                    activeItems[_i].GetComponent<SpriteRenderer>().sortingOrder = _i;
                }
            }

            Destroy(obj);
        }
        else
        {
            activeItems = new List<GameObject>();
        }
    }   
}
