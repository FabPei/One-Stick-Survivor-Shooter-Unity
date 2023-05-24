using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHolder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateChild()
    {
        
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

    }
    public void ActivateChild()
    {
       
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

    }
}
