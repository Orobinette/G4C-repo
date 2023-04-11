using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuControls : MonoBehaviour
{
    [SerializeField] GameObject buttonsPanel;
    [SerializeField] GameObject difficultyPanel;

    public void Back() 
    {
        buttonsPanel.SetActive(true);
        difficultyPanel.SetActive(false);
    }

    public void SelectDifficulty()
    {
        buttonsPanel.SetActive(false);
        difficultyPanel.SetActive(true);
    }
    
}
