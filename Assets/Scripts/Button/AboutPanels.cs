using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutPanels : MonoBehaviour
{
    [SerializeField] List<GameObject> panelList = new List<GameObject>();
    int i;

    void Start() 
    {
        i = 0;
        panelList[i].SetActive(true);
    }

    public void Forward() 
    {
        if(i < panelList.Count)
        {
            panelList[i].SetActive(false);
            i++;
            panelList[i].SetActive(true);
        }
    }

    public void Back() 
    {
        if(i > 0)
        {
            panelList[i].SetActive(false);
            i--;
            panelList[i].SetActive(true);
        }
    }
}
