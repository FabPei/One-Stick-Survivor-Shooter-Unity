using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Pool;

public class MapChunkScript : MonoBehaviour
{
    // The size of the chunk
    public int size;

    // An array to store the tiles in the chunk
    public Tile2[,] tiles;
    public ObjectPool<Tile2> tile2Pool;
    public GameObject grassTile;
    public GameObject waterTile;
    public GameObject mountainTile;

    public MapChunkScript(int size)
    {
        this.size = size;
        tiles = new Tile2[size, size];
    }

    // Instantiate the prefabs for each tile in the chunk
    public void InstantiateTiles(Transform parent, Vector2 playpos, GameObject ch, Tilemap tl)
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Tile2 tile = tiles[x, y];
                GameObject prefab = tile.prefab;
                if (prefab != null)
                {
                    // Instantiate the prefab and set its position
                    //var Tile2Prefab = tile2Pool.Get();

                    GameObject instance = GameObject.Instantiate(prefab);

                    instance.transform.position = new Vector3(Mathf.FloorToInt(x + playpos.x), Mathf.FloorToInt(y + playpos.y), 0);
                    

                    instance.transform.parent = ch.transform;

                }
            }
        }
    }
}
