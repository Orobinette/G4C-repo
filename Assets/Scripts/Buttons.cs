using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] Button button;

    public Sprite defaultSprite;
    public Sprite hoverSprite;

    
    void Update() 
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
        
        if (targetObject)
        {
            button.image.sprite = hoverSprite;
        }
        else
        {
            button.image.sprite = defaultSprite;
        }
    }   
}
