using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuControls : MonoBehaviour
{
    [SerializeField] Buttons buttons;

    [SerializeField] List<GameObject> panelList = new List<GameObject>();

    public void ChangePanel(GameObject activePanel)
    {
        foreach(GameObject obj in panelList)
        {
            obj.SetActive(false);
        }

        activePanel.SetActive(true);
    }
}
