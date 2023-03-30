using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
/*********
*VARIABLES
*********/

    [SerializeField] Button button;

    public Sprite defaultSprite;
    public Sprite hoverSprite;


/*********
*FUNCTIONS
**********/

    public void Hovering()
    {
        button.image.sprite = hoverSprite;
    }
    public void NotHovering() 
    {
        button.image.sprite = defaultSprite;
    }
}

