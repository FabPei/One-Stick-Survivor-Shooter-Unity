using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Short : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<SpriteRenderer>().material.mainTextureOffset = new Vector2((Time.time * speed) % 1, 0f);
    }
}
