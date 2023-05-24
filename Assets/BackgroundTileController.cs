using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundTileController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject BackgroundTilePrefab;
    public GameObject player;
    private SpriteRenderer sr;
    public float sr_x;
    public float sr_y;

    public Vector2 playerPos;
    public Vector2 chunkPos;
    public Dictionary<Vector2, GameObject> BGs;
    public List<Vector2> chunkPositions;
    void Start()
    {
        Vector2 playerPos = player.transform.position;

        chunkPositions = new List<Vector2>();

        BGs = new Dictionary<Vector2, GameObject>();
        sr = BackgroundTilePrefab.GetComponent<SpriteRenderer>();
        sr_x = sr.bounds.size.x;
        sr_y = sr.bounds.size.y;

        Debug.Log("sr_x: " + sr_x);
        int chunkX = Mathf.RoundToInt(playerPos.x / sr_x);
        int chunkY = Mathf.RoundToInt(playerPos.y / sr_y);

        Vector2 chunkPos = new Vector2(chunkX, chunkY);

        instantiateBG(new Vector2(0,0), (int)sr_x);

        instantiateBG(new Vector2(chunkPos.x + 1, chunkPos.y), (int)sr_x);
        instantiateBG(new Vector2(chunkPos.x + 1, chunkPos.y + 1), (int)sr_x);
        instantiateBG(new Vector2(chunkPos.x + 1, chunkPos.y - 1), (int)sr_x);
        instantiateBG(new Vector2(chunkPos.x - 1, chunkPos.y + 1), (int)sr_x);
        instantiateBG(new Vector2(chunkPos.x - 1, chunkPos.y), (int)sr_x);
        instantiateBG(new Vector2(chunkPos.x - 1, chunkPos.y - 1), (int)sr_x);
        instantiateBG(new Vector2(chunkPos.x, chunkPos.y - 1), (int)sr_x);
        instantiateBG(new Vector2(chunkPos.x, chunkPos.y + 1), (int)sr_x);
        //spawnBG(new Vector2(chunkPos.x + 1, chunkPos.y + 0), (int)sr_x);

        //spawnBG(chunkPos, new Vector2(1, 1));
        //spawnBG(chunkPos, new Vector2(-1, 0));
        //spawnBG(chunkPos, new Vector2(-1, -1));
        //spawnBG(chunkPos, new Vector2(0, -1));
        //spawnBG(chunkPos, new Vector2(0, 1));
        GameObject BackgroundTile1 = Instantiate(BackgroundTilePrefab, chunkPos, this.transform.rotation);


        //Vector2 chunkPos = new Vector2(chunkX, chunkY);

        //chunks.Add(chunkPos, chunk);
    }

    public void instantiateBG(Vector2 chunkPos, int chunksize)
    {
        Vector2 chunkposReal = new Vector2(chunkPos.x * chunksize, chunkPos.y * chunksize);

        //Debug.Log("Vector2 chunkposReal: " + chunkposReal);

        GameObject BackgroundTile1 = Instantiate(BackgroundTilePrefab, chunkposReal, this.transform.rotation);

        BGs.Add(chunkposReal, BackgroundTile1);
    }

    public void createChunkPositionsList(Vector2 currentOnChunk)
    {
        chunkPositions.Clear();
        chunkPositions.Add(currentOnChunk);
        chunkPositions.Add(new Vector2(currentOnChunk.x + 1, currentOnChunk.y));
        chunkPositions.Add(new Vector2(currentOnChunk.x + 1, currentOnChunk.y + 1));
        chunkPositions.Add(new Vector2(currentOnChunk.x, currentOnChunk.y + 1));
        chunkPositions.Add(new Vector2(currentOnChunk.x + 1, currentOnChunk.y - 1));
        chunkPositions.Add(new Vector2(currentOnChunk.x - 1, currentOnChunk.y + 1));
        chunkPositions.Add(new Vector2(currentOnChunk.x - 1, currentOnChunk.y));
        chunkPositions.Add(new Vector2(currentOnChunk.x - 1, currentOnChunk.y - 1));
        chunkPositions.Add(new Vector2(currentOnChunk.x, currentOnChunk.y - 1));
        
    }

    public Vector2 multiplyVector2(Vector2 vec)
    {
        Vector2 vec2 = new Vector2(vec.x * 60, vec.y * 60);
        return vec2;
    }
    public void updateChunks()
    {
        List<Vector2> keys = new List<Vector2>(BGs.Keys);

        //List<Vector2> keysNotInChunkPositions = new List<Vector2>();
        //Debug.Log("keys " + keys);
        var keysNotInChunkPositions = keys.Except(chunkPositions);

        //Debug.Log("keys "+ keys);
        var chunkPositionsNotInKeys = chunkPositions.Except(keys);

        int i = 0;
        foreach (Vector2 key in keysNotInChunkPositions)
        {


            BGs[key].gameObject.transform.position = multiplyVector2(chunkPositionsNotInKeys.ElementAt(i));

            BGs.Add(chunkPositionsNotInKeys.ElementAt(i), BGs[key].gameObject);
            BGs.Remove(key);
            //Debug.Log(i);
            i++;
            //if (!chunkPositions.Contains(key))
            //{
            //    keysNotInChunkPositions.Add(key);
            //    //BGs[key].gameObject.transform.position = 
            //}
        }


    }
    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        //Check if still on same BG
        Vector2 currentOnChunk = new Vector2(Mathf.RoundToInt(playerPos.x / sr_x), Mathf.RoundToInt(playerPos.y / sr_y));

        if (currentOnChunk.x != chunkPos.x || currentOnChunk.y != chunkPos.y)
        {
            createChunkPositionsList(currentOnChunk);

           updateChunks();
            //method
            chunkPos = currentOnChunk;
        }
    }
}
