using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBarrier : MonoBehaviour
{   
    private GameObject playerGO;
    public Transform player;
    private float size = 1.0f;
    private BasicVariables basicVariables;

    int CircleSize;
    // Start is called before the first frame update
    public void Init(int size) {
    CircleSize = size;
    }


    void Start()
    {
        playerGO = GameObject.Find("Player");
        basicVariables = this.GetComponent<BasicVariables>();
        player = playerGO.transform;
        transform.position = new Vector3 (player.position.x, player.position.y, player.position.z);
        size = basicVariables.size;
        this.transform.localScale *= basicVariables.size;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (size != basicVariables.size) { 
        
            this.transform.localScale *= basicVariables.size;
            size = basicVariables.size;
        }
        transform.position = new Vector3 (player.position.x, player.position.y, player.position.z);

        //Debug.Log(player.position.x);
    }

    //private void OnTriggerEnter2D(Collider2D col) {
    //    switch(col.tag) {
    //        case "Enemy":
    //            Destroy(col.gameObject);
    //            break;

    //    }
    //    }
}
