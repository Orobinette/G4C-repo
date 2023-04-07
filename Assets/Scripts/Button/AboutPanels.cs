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
        panelList[i].SetActive(false);
        if(i < panelList.Count - 1)
        {
            i++;
        }
        else
        {
            i = 0;
        }
        panelList[i].SetActive(true);
    }

    public void Back() 
    {
        panelList[i].SetActive(false);
        if(i > 0)
        {
            i--;
        }
        else
        {
            i = panelList.Count - 1;
        }
        panelList[i].SetActive(true);
    }
}
