using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedButton : MonoBehaviour
{
    GameObject gameControllerObj;
    GlobalVariables globalVariables;

    [SerializeField] Buttons buttons;

    [SerializeField] Sprite unlockedSprite;
    [SerializeField] Sprite unlockedHoverSprite;

    [SerializeField] Button button;
    [SerializeField] string thisButton;

    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();

        CheckLock();
    }

    void CheckLock() 
    {
        if(thisButton == "normal")
        {
            if(globalVariables.normalUnlocked == true) 
            {
                button.image.sprite = unlockedSprite;
                buttons.defaultSprite = unlockedSprite;
                buttons.hoverSprite = unlockedHoverSprite;
                button.onClick.AddListener(delegate {buttons.SetDifficulty("normal");});
                button.onClick.AddListener(delegate {buttons.ChangeScene("loadingScene");});
            }
        }
    }
}
