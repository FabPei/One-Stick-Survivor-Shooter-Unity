using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
  public Transform player;
  public GameObject playerGameObject;
  public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
        playerGameObject = GameObject.Find("Player");
        player = playerGameObject.transform;
        // Switch to 640 x 480 full-screen
        //Screen.SetResolution(1280, 960, true);
        Application.targetFrameRate = 60;
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x, player.position.y, player.position.z - 10);
    }
}
