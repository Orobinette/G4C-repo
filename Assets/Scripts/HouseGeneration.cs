using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HouseGeneration : MonoBehaviour
{
    [SerializeField] Tilemap grid;

    [SerializeField] List<Tile> tileList = new List<Tile>();
    [SerializeField] RuleTile roadTile;

    int x; int y;
    static int start = -3; static int end = start + 8;

    bool evenColumn = false;

    // Start is called before the first frame update
    void Start()
    {
        GenerateHouses();
    }

    void GenerateHouses() 
    {
        for(x = start; x < end; x++) //Go through every x coord
        {
            if(x % 2 == 0)
            {
                evenColumn = true;
            }
            else 
            {
                evenColumn = false;
            }

            for(y = start; y < end; y++) //Go through every y coord
            {
                /*
                if(y % 2 == 0 && evenColumn == true) //If on an even space
                {
                    grid.SetTile(new Vector3Int(x, y, 0), tileList[Random.Range(0, 4)]); //Spawn random house
                }
                else 
                {
                    grid.SetTile(new Vector3Int(x, y, 0), roadTile);
                }
                */
                if(Random.Range(0, 3) == 2) 
                {
                    grid.SetTile(new Vector3Int(x, y, 0), tileList[Random.Range(0, 4)]);
                }
                else 
                {
                    grid.SetTile(new Vector3Int(x, y, 0), roadTile);
                }
            } 
        }
    }
}
