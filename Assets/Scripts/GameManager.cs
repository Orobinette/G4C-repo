using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> truckList = new List<GameObject>();

    public int score = 0;

    void Start() 
    {
        InvokeRepeating("SpawnTruck", 3f, 5f);
    }

    void SpawnTruck() 
    {
        Instantiate(truckList[Random.Range(0, truckList.Count)]);
    }

}
