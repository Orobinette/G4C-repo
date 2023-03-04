using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField] List<Sprite> spriteList = new List<Sprite>();
    [SerializeField] List<Vector3> spawnPointList = new List<Vector3>();
    [SerializeField] List<Vector3> itemSpawnPoints = new List<Vector3>();
    [SerializeField] List<GameObject> itemList = new List<GameObject>();
    [SerializeField] List<Vector3> directionList = new List<Vector3>();

    [SerializeField] Transform trans;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;
    Vector3 direction;

    Vector3 spawnPoint;
    GameObject item;
    int orientation;

    Vector3 speedModifier = new Vector3(80, 80, 80);

    // Start is called before the first frame update
    void Start()
    {
        orientation = Random.Range(0, 4);

        directionList.Add(new Vector3(0f, 1f, 0f));
        directionList.Add(new Vector3(0f, -1f, 1f));
        directionList.Add(new Vector3(-1f, 0f, 0f));
        directionList.Add(new Vector3(1f, 0f, 0f));

        spawnPointList.Add(new Vector3(7f, -6f, 0f));
        spawnPointList.Add(new Vector3(-7f, 6f, 0f));
        spawnPointList.Add(new Vector3(10f, 4f, 0f));
        spawnPointList.Add(new Vector3(-10f, -4f, 0f));

        itemSpawnPoints.Add(new Vector3(4f, 0f, 0f));
        itemSpawnPoints.Add(new Vector3(-4f, 0f, 0f));
        itemSpawnPoints.Add(new Vector3(0f, 2f, 0f));
        itemSpawnPoints.Add(new Vector3(0f, -2f, 0f));


        spriteRenderer.sprite = spriteList[orientation];
        trans.localScale = new Vector3(1f, 1f, 1f);
        trans.position = spawnPointList[orientation];
        direction = directionList[orientation];
        item = itemList[Random.Range(0, itemList.Count)];

        StartCoroutine("DropOffItem");
    }

    IEnumerator DropOffItem()
    {
        if(item != null)
        {
            Instantiate(item, itemSpawnPoints[orientation], Quaternion.identity);
        }
        for(var i = 0; i < 10; i++)
        {
            rb.AddForce(Vector3.Scale(direction, speedModifier));
        }

        yield return new WaitForSeconds(1.5f);
        
        Destroy(this.gameObject);
    }
}
