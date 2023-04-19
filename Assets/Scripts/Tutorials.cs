using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorials : MonoBehaviour
{
    int tutorialType; //Index of tutorial types

    //Item Lists
    List<List<GameObject>> trashTypes = new List<List<GameObject>>(); //List of itemLists
    List<GameObject> itemList = new List<GameObject>(); //List of items that changes depending on the tutorial type
    [SerializeField] List<string> tutorialTypes = new List<string>(); //recycling, trash, hazard, compost

    [SerializeField] List<GameObject> recyclingItems = new List<GameObject>();
    [SerializeField] List<GameObject> compostItems = new List<GameObject>();
    [SerializeField] List<GameObject> hazardItems = new List<GameObject>();
    [SerializeField] List<GameObject> trashItems = new List<GameObject>();

    List<List<GameObject>> popupTypes = new List<List<GameObject>>();
    List<GameObject> popupList = new List<GameObject>();
    [SerializeField] GameObject htpPanel;
    [SerializeField] GameObject endPanel;

    [SerializeField] List<GameObject> recyclingPopups = new List<GameObject>();
    [SerializeField] List<GameObject> compostPopups = new List<GameObject>();
    [SerializeField] List<GameObject> hazardPopups = new List<GameObject>();
    [SerializeField] List<GameObject> trashPopups = new List<GameObject>();

    //Sprites
    [SerializeField] List<Sprite> truckSprites = new List<Sprite>();

    SpriteRenderer itemRenderer;
    SpriteRenderer truckRenderer;

    [SerializeField] GameObject panelBackground;

    //SpawnPoints
    Vector3 itemSpawnPoint = new Vector3();
    Vector3 truckSpawnPoint = new Vector3();

    //GameObject
    GameObject truck;
    [SerializeField] GameObject truckPref;
    Rigidbody2D truckRB;
    GameObject itemObj; 

    [SerializeField] GameObject exitButton;

    //Classes
    public Item item;

    GameObject gameControllerObj;
    GlobalVariables globalVariables;
    ClickAndDrag clickAndDrag;

    public int index;

    IEnumerator Start() 
    {
        index = 0;

        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();
        clickAndDrag = this.gameObject.GetComponent<ClickAndDrag>();

        //Set tutorialType to whatever tutorial the player is in (trash, compost, etc.)
        for(int i = 0; i < tutorialTypes.Count; i++) 
        {
            if(globalVariables.tutorialType == tutorialTypes[i]) 
            {
                tutorialType = i;
            }
        }

        //Add item lists to trashTypes list
        trashTypes.Add(recyclingItems);
        trashTypes.Add(hazardItems);
        trashTypes.Add(trashItems);
        trashTypes.Add(compostItems);

        //Add popup lists to popupTypes list
        popupTypes.Add(recyclingPopups);
        popupTypes.Add(hazardPopups);
        popupTypes.Add(trashPopups);
        popupTypes.Add(compostPopups);

        itemList = trashTypes[tutorialType]; //Assign correct set of item to itemList
        popupList = popupTypes[tutorialType]; //Assign correct set of popups to popupList

        itemSpawnPoint = new Vector3(0f, 0f, 0f);
        truckSpawnPoint = new Vector3(8f, -6f, 0f);

        yield return new WaitForSeconds(1.5f);
        HowToPlay();
        DisableCursor();
    }

    public void SpawnItem() 
    {
        if(index < itemList.Count) 
        {
            DisableCursor();

            if(item != null) 
            {
                Destroy(itemObj);
            }
            itemObj = Instantiate(itemList[index], itemSpawnPoint, Quaternion.identity);

            StartCoroutine("PopUpDelay");
        }
        else 
        {
            EndTutorialPopup();
        }
    }

    public void HowToPlay() 
    {
        if(htpPanel.activeInHierarchy == false) 
        {
            htpPanel.SetActive(true);
            panelBackground.SetActive(true);
        }
        else 
        {
            htpPanel.SetActive(false);
            exitButton.SetActive(true);
            panelBackground.SetActive(false);
            SpawnItem();
        }
    }

    public void EndTutorialPopup() 
    {
        if(endPanel.activeInHierarchy == false) 
        {
            exitButton.SetActive(false);
            endPanel.SetActive(true);
            panelBackground.SetActive(true);
        }
    }

    public void PopUp() 
    {
        if(panelBackground.activeInHierarchy == false) 
        {
            popupList[index].SetActive(true);
            panelBackground.SetActive(true);
        }
    }
    public void ClosePopUp() 
    {
        popupList[index].SetActive(false);
        panelBackground.SetActive(false);

        EnableCursor();
    }
    IEnumerator PopUpDelay() 
    {
        yield return new WaitForSeconds(1.5f);
        PopUp();
    }

    public void EnableCursor() 
    {
        clickAndDrag.enabled = true;
    }
    public void DisableCursor() 
    {
        clickAndDrag.enabled = false;
    }

    public void EndTutorial()  
    {
        SceneManager.LoadScene("StartScene");
    }
}
