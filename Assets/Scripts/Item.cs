using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    ClickAndDrag clickAndDrag;
    Camera camera;

    [SerializeField] string trashType;
    bool onBin = false;

    void Start() 
    {
        camera = Camera.main;
        clickAndDrag = camera.GetComponent<ClickAndDrag>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == trashType)
        {
            onBin = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        onBin = false;
    }

    public void CheckForBin() 
    {
        if(onBin == true)
        {
            Destroy(this.gameObject);
        }
    }
}
