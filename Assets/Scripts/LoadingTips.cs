using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingTips : MonoBehaviour
{
    public List<string> tips= new List<string>();

    void Start() 
    {
        //copy and paste -> tips.Add("");
        tips.Add("Be a clean, green, recycling machine");
        tips.Add("There is no planet B");
        tips.Add("Be part of the solution, not the pollution");
        tips.Add("Say no to styro");
        tips.Add("Razors shouldn't be put in the trash");
        tips.Add("See the about page for more info");
        tips.Add("You can pause by pressing esc");
    }
} 
