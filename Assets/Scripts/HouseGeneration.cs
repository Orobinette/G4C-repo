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
    static int startPoint = 0; static int endPoint = startPoint + 17;

    bool spawnableRow = false;

    void Start()
    {
        GenerateHouses();
    }

    void GenerateHouses() 
    {
        for(x = startPoint; x < endPoint; x++)
        {
            if(x % 4 == 0)
            {
                spawnableRow = false;
            }
            else 
            {
                spawnableRow = true;
            }

            for(y = startPoint; y < endPoint; y++)
            {
                if(x % 2 == 1 && y % 2 == 1)
                {
                    grid.SetTile(new Vector3Int(x, y, 0), tileList[Random.Range(0, tileList.Count)]);
                }
                else if (x % 4 != 0 && y % 4 != 0)
                {
                    if(Random.Range(0, 2) == 0)
                    {
                        grid.SetTile(new Vector3Int(x, y, 0), tileList[Random.Range(0, tileList.Count)]);
                    }
                    else 
                    {
                        grid.SetTile(new Vector3Int(x, y, 0), roadTile);
                    }
                }
                else 
                {
                    grid.SetTile(new Vector3Int(x, y, 0), roadTile);
                }
            }
        }
    }
}


