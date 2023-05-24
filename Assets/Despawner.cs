using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public GameObject player;
    public Camera MainCamera;

    private float height;
    private float width;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        height = 2f * MainCamera.orthographicSize;
        width = height * MainCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Item":

                
                
                break;
            case "Enemy":
                //Destroy(col.gameObject);
                col.gameObject.SetActive(false);
                break;

            case "Exp":
                Destroy(col.gameObject);
                break;

        }
    }
}
