using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera.main.transform.position = player.transform.position;
        this.transform.position = Camera.main.transform.position;

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("ChunkHolder")) { 
            //col.gameObject.SetActive(false);
            col.gameObject.GetComponent<ChunkHolder>().DeactivateChild();
        }
        //Debug.Log(col.gameObject.name);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ChunkHolder"))
        {
            //col.gameObject.SetActive(false);
            col.gameObject.GetComponent<ChunkHolder>().ActivateChild();
        }
        //col.gameObject.SetActive(true);
    }
    //void OnCollisionExit2D(Collision2D col)
    //{

    //    Debug.Log(col.gameObject.name);
    //}
}
