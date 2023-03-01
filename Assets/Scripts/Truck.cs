using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField] List<Sprite> spriteList = new List<Sprite>();
    [SerializeField] List<Vector3> spawnPointList = new List<Vector3>();
    [SerializeField] List<GameObject> itemList = new List<GameObject>();
    [SerializeField] List<Vector3> directionList = new List<Vector3>();

    [SerializeField] Transform trans;
    [SerializeField] SpriteRenderer spriteRenderer;
    Vector3 direction;

    Vector3 spawnPoint;
    GameObject item;
    int orientation;

    // Start is called before the first frame update
    void Start()
    {
        orientation = Random.Range(0, 4);
        spriteRenderer.sprite = spriteList[orientation];
        trans.position = spawnPointList[orientation];
        direction = directionList[orientation];

        
        item = itemList[Random.Range(0, itemList.Count)];

        StartCoroutine("DropOffItem");
    }

    IEnumerator DropOffItem()
    {
        if(item != null)
        {
            Instantiate(item, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }

        yield return new WaitForSeconds(1f);
        
        Destroy(this.gameObject);
    }
}
