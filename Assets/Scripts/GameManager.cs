using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool dragging = false;

    public GameObject selectedObject;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && dragging == false)
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                dragging = true;
            }
        }
        else if (dragging == true)
        {
            dragging = false;
            selectedObject = null;
        }

        if(selectedObject != null)
        {
            selectedObject.transform.position = new Vector3(mousePosition);
        }
    }
}
