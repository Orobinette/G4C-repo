using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] Button button;

    [SerializeField] Sprite hoverSprite;
    [SerializeField] Sprite defaultSprite;

    
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
