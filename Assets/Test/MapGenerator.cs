using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

using UnityEngine.Pool;

public class MapGenerator : MonoBehaviour
{
    // The size of each chunk of the map
    public int chunkSize = 16;

    // The prefabs for each type of terrain
    public GameObject grassTile;
    public GameObject waterTile;
    public GameObject mountainTile;
    public MapChunkScript mapChunk;
    public GameObject chunkHolder;

    public GameObject PoolingController;

    public ObjectPool<Tile2> tile2Pool;

    // The player object
    public GameObject player;

    // A dictionary to store the chunks of the map
    Dictionary<Vector2, MapChunkScript> chunks;

    void Start()
    {
        // Initialize the dictionary
        chunks = new Dictionary<Vector2, MapChunkScript>();

        // Generate the initial chunk of the map
        GenerateChunk(Vector2.zero);
        GenerateChunk(new Vector2(1,0));
        GenerateChunk(new Vector2(1, 1));
        GenerateChunk(new Vector2(-1, 0));
        GenerateChunk(new Vector2(-1, -1));
        GenerateChunk(new Vector2(0, -1));
        GenerateChunk(new Vector2(0, 1));

        tile2Pool = PoolingController.GetComponent<PoolingController>().tile2Pool;

    }

    void Update()
    {
        // Get the player's position
        Vector2 playerPos = player.transform.position;

        // Calculate the player's chunk position
        int chunkX = Mathf.FloorToInt(playerPos.x / chunkSize);
        int chunkY = Mathf.FloorToInt(playerPos.y / chunkSize);
        Vector2 chunkPos = new Vector2(chunkX, chunkY);

        // Check if the player has moved outside the current chunk
        if (!chunks.ContainsKey(chunkPos))
        {

            //Debug.Log(chunkPos);
            // Generate the new chunk
           // Debug.Log(new Vector2(Mathf.FloorToInt((playerPos.x + 16) / chunkSize), Mathf.FloorToInt((playerPos.y + 16) / chunkSize)));
            GenerateChunk(chunkPos);

            

            //if (!chunks.ContainsKey(new Vector2(Mathf.FloorToInt((playerPos.x + 16) / chunkSize), Mathf.FloorToInt((playerPos.y + 16) / chunkSize))))
            //{

            //    GenerateChunk(new Vector2(Mathf.FloorToInt((playerPos.x + 16) / chunkSize), Mathf.FloorToInt((playerPos.y + 16) / chunkSize)));
            //}
            //if (!chunks.ContainsKey(new Vector2(Mathf.FloorToInt((playerPos.x - 16) / chunkSize), Mathf.FloorToInt((playerPos.y + 16) / chunkSize))))
            //{
            //    GenerateChunk(new Vector2(Mathf.FloorToInt((playerPos.x - 16) / chunkSize), Mathf.FloorToInt((playerPos.y + 16) / chunkSize)));
            //}
            //if (!chunks.ContainsKey(new Vector2(Mathf.FloorToInt((playerPos.x + 16) / chunkSize), Mathf.FloorToInt((playerPos.y - 16) / chunkSize))))
            //{
            //    GenerateChunk(new Vector2(Mathf.FloorToInt((playerPos.x + 16) / chunkSize), Mathf.FloorToInt((playerPos.y - 16) / chunkSize)));
            //}
            //if (!chunks.ContainsKey(new Vector2(Mathf.FloorToInt((playerPos.x - 16) / chunkSize), Mathf.FloorToInt((playerPos.y - 16) / chunkSize))))
            //{
            //    GenerateChunk(new Vector2(Mathf.FloorToInt((playerPos.x - 16) / chunkSize), Mathf.FloorToInt((playerPos.y - 16) / chunkSize)));
            //}
            //if (!chunks.ContainsKey(new Vector2(Mathf.FloorToInt((playerPos.x - 16) / chunkSize), Mathf.FloorToInt((playerPos.y) / chunkSize))))
            //{
            //    GenerateChunk(new Vector2(Mathf.FloorToInt((playerPos.x - 16) / chunkSize), Mathf.FloorToInt((playerPos.y) / chunkSize)));
            //}
            //if (!chunks.ContainsKey(new Vector2(Mathf.FloorToInt((playerPos.x + 16) / chunkSize), Mathf.FloorToInt((playerPos.y) / chunkSize))))
            //{
            //    GenerateChunk(new Vector2(Mathf.FloorToInt((playerPos.x + 16) / chunkSize), Mathf.FloorToInt((playerPos.y) / chunkSize)));
            //}
            //if (!chunks.ContainsKey(new Vector2(Mathf.FloorToInt((playerPos.x) / chunkSize), Mathf.FloorToInt((playerPos.y - 16) / chunkSize))))
            //{
            //    GenerateChunk(new Vector2(Mathf.FloorToInt((playerPos.x) / chunkSize), Mathf.FloorToInt((playerPos.y - 16) / chunkSize)));
            //}
            //if (!chunks.ContainsKey(new Vector2(Mathf.FloorToInt((playerPos.x) / chunkSize), Mathf.FloorToInt((playerPos.y + 16) / chunkSize))))
            //{
            //    GenerateChunk(new Vector2(Mathf.FloorToInt((playerPos.x) / chunkSize), Mathf.FloorToInt((playerPos.y + 16) / chunkSize)));
            //}
            //DestroyChunks();
        }
        if (!chunks.ContainsKey(new Vector2(chunkX + 1, chunkY + 1)))
        {

            GenerateChunk(new Vector2(chunkX + 1, chunkY + 1));
        }
        if (!chunks.ContainsKey(new Vector2(chunkX + 1, chunkY - 1)))
        {
            GenerateChunk(new Vector2(chunkX + 1, chunkY - 1));
        }
        if (!chunks.ContainsKey(new Vector2(chunkX - 1, chunkY + 1)))
        {
            GenerateChunk(new Vector2(chunkX - 1, chunkY + 1));
        }
        if (!chunks.ContainsKey(new Vector2(chunkX + 1, chunkY)))
        {
            GenerateChunk(new Vector2(chunkX + 1, chunkY));
        }
        if (!chunks.ContainsKey(new Vector2(chunkX, chunkY + 1)))
        {
            GenerateChunk(new Vector2(chunkX, chunkY + 1));
        }
        if (!chunks.ContainsKey(new Vector2(chunkX - 1, chunkY)))
        {
            GenerateChunk(new Vector2(chunkX - 1, chunkY));
        }
        if (!chunks.ContainsKey(new Vector2(chunkX, chunkY - 1)))
        {
            GenerateChunk(new Vector2(chunkX, chunkY - 1));
        }
        if (!chunks.ContainsKey(new Vector2(chunkX - 1, chunkY - 1)))
        {
            GenerateChunk(new Vector2(chunkX - 1, chunkY - 1));
        }
    }

    void GenerateChunk(Vector2 chunkPos)
    {
        // Create a new MapChunk object
        MapChunkScript chunk = new MapChunkScript(chunkSize);
        //chunk = Instantiate(chunk);
        // Generate the map data for the chunk
        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                // Calculate the world position of the tile
                int worldX = (int)(chunkPos.x * chunkSize + x);
                int worldY = (int)(chunkPos.y * chunkSize + y);

                // Generate a Perlin noise value at the tile position
                float value = Mathf.PerlinNoise((float)worldX / 10, (float)worldY / 10);

                if (value < 0.3f)
                {
                    // 30% chance of grass
                    var myTile2 = tile2Pool.Get();
                    myTile2.type = TileType.Grass;
                    myTile2.prefab = grassTile;
                    chunk.tiles[x, y] = myTile2;

                   // chunk.tiles[x, y] = new Tile2(TileType.Grass, grassTile);
                }
                else if (value < 0.6f)
                {
                    // 30% chance of water

                    var myTile2 = tile2Pool.Get();
                    myTile2.type = TileType.Water;
                    myTile2.prefab = waterTile;
                    chunk.tiles[x, y] = myTile2;

                    chunk.tiles[x, y] = new Tile2(TileType.Water, waterTile);
                }
                else
                {
                    // 40% chance of mountain
                    chunk.tiles[x, y] = new Tile2(TileType.Mountain, mountainTile);
                }
            }
        }

        // Add the chunk to the dictionary and instantiate its tiles
        //chunkPos = new Vector2(chunkPos.x * 16, chunkPos.y * 16);
        chunks.Add(chunkPos, chunk);
        Vector2 playpos = player.transform.position;
        int chunkX = Mathf.FloorToInt(playpos.x / chunkSize);
        int chunkY = Mathf.FloorToInt(playpos.y / chunkSize);
        //Debug.Log("normalized: " + playpos.normalized);
        //Debug.Log(new Vector2(chunkX * 16, chunkY * 16));
        playpos = new Vector2(chunkX * chunkSize, chunkY * chunkSize);
        Tilemap tl = new Tilemap();
        Debug.Log("playpos:" + playpos);
        Debug.Log("chunkPos:" + chunkPos);
        GameObject ch = Instantiate(chunkHolder, new Vector2(chunkPos.x * chunkSize, chunkPos.y * chunkSize), this.transform.rotation);
        ch.name = chunkPos.ToString();
        chunk.InstantiateTiles(transform, new Vector2(chunkPos.x * chunkSize, chunkPos.y * chunkSize), ch, tl);
    }
    void DestroyChunks()
    {
        // Get a list of the chunk keys
        List<Vector2> keys = new List<Vector2>(chunks.Keys);

        // Destroy all the chunks except the one at the player's position
        foreach (Vector2 key in keys)
        {
            Debug.Log("Keys: " + key);
            Debug.Log(chunks[key].gameObject);
            Vector2 playepos = player.transform.position;
            if (key != playepos)
            {
                if (chunks[key].gameObject != null)
                {
                    Debug.Log("does exit");
                
                Destroy(chunks[key].gameObject);
                chunks.Remove(key);
                }
            }
        }
    }
}

// A class to represent a chunk of the map
//public class MapChunk : MonoBehaviour
//{
//    // The size of the chunk
//    public int size;

//    // An array to store the tiles in the chunk
//    public Tile2[,] tiles;

//    public MapChunk(int size)
//    {
//        this.size = size;
//        tiles = new Tile2[size, size];
//    }

//    // Instantiate the prefabs for each tile in the chunk
//    public void InstantiateTiles(Transform parent, Vector2 playpos)
//    {
//        for (int x = 0; x < size; x++)
//        {
//            for (int y = 0; y < size; y++)
//            {
//                Tile2 tile = tiles[x, y];
//                GameObject prefab = tile.prefab;
//                if (prefab != null)
//                {
//                    // Instantiate the prefab and set its position
//                    GameObject instance = GameObject.Instantiate(prefab);
//                    //playpos = playpos.normalized;
//                    //playpos = new Vector2(playpos.x * 16, playpos.y * 16);
//                    instance.transform.position = new Vector3(Mathf.FloorToInt(x + playpos.x), Mathf.FloorToInt(y + playpos.y), 0);
//                    //instance.transform.position = new Vector3(Mathf.FloorToInt(x + parent.position.x), Mathf.FloorToInt(y + parent.position.y), 0);
//                    //Debug.Log(instance.transform.position);
//                    instance.transform.parent = parent;
//                }
//            }
//        }
//    }
//}

// A class to represent a single tile in the map
public class Tile2 : MonoBehaviour
{
    // The type of terrain for the tile
    public TileType type;

    // The prefab to use for the tile
    public GameObject prefab;

    public Tile2(TileType type, GameObject prefab)
    {
        this.type = type;
        this.prefab = prefab;
    }
}

// An enum to represent the different types of terrain
public enum TileType
{
    Grass,
    Water,
    Mountain
}