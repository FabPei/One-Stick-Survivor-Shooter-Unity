using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawn : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGameObject = GameObject.Find("Player");
        player = playerGameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x, player.position.y, player.position.z - 10);
    }
}
