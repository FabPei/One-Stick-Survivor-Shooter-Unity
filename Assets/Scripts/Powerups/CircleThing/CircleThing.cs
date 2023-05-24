using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleThing : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = GameObject.Find("PlayerFollower").transform;
        player = GameObject.FindWithTag("Player");
        //this.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = player.transform.position;
        this.transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), 50 * Time.deltaTime);
        //this.transform.Rotate(20 * Time.deltaTime, zAngle, player.transform.position);
    }
}
