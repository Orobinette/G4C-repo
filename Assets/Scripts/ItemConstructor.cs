using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConstructor : MonoBehaviour
{
/********
*Variables
*********/

    //Object References
    GameObject gameControllerObj;
    GlobalVariables globalVariables;

    [SerializeField] GameObject itemPref;
    SpriteRenderer spriteRenderer;

    //Scripting Variables
    List<Vector3> spawnPoints = new List<Vector3>() {new Vector3(6f, 0f, 0f), new Vector3(-6f, 0f, 0f), new Vector3(0f, 2.5f, 0f), new Vector3(0f, -2.5f, 0f)};
    private Vector3 offset = new Vector3();
    int index; //index of trash types in lists [recycling, hazard, trash, compost]
    List<string> trashTypes = new List<string>() {"recycling", "hazard", "trash", "compost"}; 

    List<List<Sprite>> itemList = new List<List<Sprite>>();
    List<Sprite> spriteList = new List<Sprite>();

    [SerializeField] List<Sprite> recyclingSprites = new List<Sprite>();
    [SerializeField] List<Sprite> hazardSprites = new List<Sprite>();
    [SerializeField] List<Sprite> trashSprites = new List<Sprite>();
    [SerializeField] List<Sprite> compostSprites = new List<Sprite>();

    [SerializeField] List<Sprite> easyRecyclingSprites = new List<Sprite>();
    [SerializeField] List<Sprite> easyHazardSprites = new List<Sprite>();
    [SerializeField] List<Sprite> easyTrashSprites = new List<Sprite>();
    [SerializeField] List<Sprite> easyCompostSprites = new List<Sprite>();

    Item item;


/*********
*FUNCTIONS
*********/

    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();

        /*
        trashTypes.Add("recycling");
        trashTypes.Add("hazard");
        trashTypes.Add("trash");
        trashTypes.Add("compost");
        */

        index = Random.Range(0, 4);
        item = this.gameObject.GetComponent<Item>();
        item.trashType = trashTypes[index];

        /*
        spawnPoints.Add(new Vector3(5f, 0f, 0f));
        spawnPoints.Add(new Vector3(-5f, 0f, 0f));
        spawnPoints.Add(new Vector3(0f, 2.5f, 0f));
        spawnPoints.Add(new Vector3(0f, -2.5f, 0f));
        */

        if(globalVariables.difficulty == "easy")
        {
            itemList.Add(easyRecyclingSprites);
            itemList.Add(easyHazardSprites);
            itemList.Add(easyTrashSprites);
            itemList.Add(easyCompostSprites);
        }
        else
        {
            itemList.Add(recyclingSprites);
            itemList.Add(hazardSprites);
            itemList.Add(trashSprites);
            itemList.Add(compostSprites);
        }

        spriteList = itemList[index];

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteList[Random.Range(0, spriteList.Count)];

        offset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f);
        this.gameObject.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)] + offset;
    }
}
