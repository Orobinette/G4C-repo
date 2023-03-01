using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{

    /*
    TODO:

    -Make the mouse pick up the object with the highest sorting order
    -Change the sorting orders so that the last picked up item is always on top
    -Some of the things that happen on click can be moved to a seperate function outside of Update to boost performance
    */

    Item item;

    public GameObject selectedObject;
    Vector3 offset;

    SpriteRenderer spriteRenderer;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
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
