using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    List<GameObject> recyclingItems = new List<GameObject>();
    List<GameObject> compostItems = new List<GameObject>();
    List<GameObject> hazardItems = new List<GameObject>();
    List<GameObject> trashItems = new List<GameObject>();

    List<Sprite> spriteList = new List<Sprite>();

    Vector3 itemSpawnPoint = new Vector3();
    Vector3 truckSpawnPoint = new Vector3();

    GameObject truck;
    GameObject item;


    int i;

    void Start() 
    {
        StartCoroutine("SpawnItem");
    }

    void SpawnItem() 
    {
        truck = Instantiate(new GameObject(), truckSpawnPoint, Quaternion.identity);
        while(truck.transform.position.y < 6)
        {
            truck.transform.position = new Vector3(truck.transform.position.x, truck.transform.position.y + 0.1f, 0);
        }
        item = Instantiate(new GameObject(), itemSpawnPoint, Quaternion.identity);
    }
}
