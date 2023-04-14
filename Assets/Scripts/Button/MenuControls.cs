using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuControls : MonoBehaviour
{
    [SerializeField] GameObject buttonsPanel;
    [SerializeField] GameObject difficultyPanel;
    [SerializeField] GameObject tutorialPanel;

    List<GameObject> panelList = new List<GameObject>();

    void Start() 
    {
        panelList.Add(buttonsPanel);
        panelList.Add(difficultyPanel);
        panelList.Add(tutorialPanel);
    }

    public void ChangePanel(GameObject activePanel)
    {
        foreach(GameObject obj in panelList)
        {
            obj.SetActive(false);
        }

        activePanel.SetActive(true);
    }
}
