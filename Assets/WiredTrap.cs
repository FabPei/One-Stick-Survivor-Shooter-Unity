using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiredTrap : MonoBehaviour
{   
    int maxEnemies = 3;
    int currentEnemies = 0;
    float maxTotalStunTime = 5.0f;
    public float timePassed = 0.0f;
    int level;
    bool bActivated = false;
    [SerializeField] private List<GameObject> stunnedObjects = new List<GameObject>();
    List<int> stunnedObjectsID = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        stunnedObjects.Clear();
        switch (level)
        {
            case 1:
                //DelayAmount = DelayAmount9 * 0.50;
                break;
            case 2:
                //
                break;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stunnedObjects.Count > 0 || bActivated == true)
        {
            timePassed += Time.deltaTime;
            
            if (timePassed >= maxTotalStunTime)
            {
                //Debug.Log(stunnedObjects.Count);
                for (int i = stunnedObjects.Count - 1; i > -1; i--)
                {
                    //Debug.Log(stunnedObjects[i]);
                    if (stunnedObjects[i] != null) {
                        stunnedObjects[i].GetComponent<BasicVariables>().bStunned = false;
                        //Debug.Log("released");
                    } else
                    {
                       
                        stunnedObjects.RemoveAt(i);
                    }
                }
                Destroy(this.gameObject);
            }

            bActivated = true;
        }
        /**
                print("List holds " + itemList.Count + " strings");
        foreach (string str in itemList)
            print(str);
    }
        */
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        switch(col.tag)
        {
            case "Item":
                //DelayAmount = DelayAmount9 * 0.50;
                break;
            case "Enemy":
                //Debug.Log("touching Enemy");
                if (maxEnemies > currentEnemies)
                { 
                //col.gameObject.step = 0f;
                    if (stunnedObjects.Contains(col.gameObject))
                    {
                    //Debug.Log("duplicate");
                    } else
                    {
                    col.gameObject.GetComponent<BasicVariables>().bStunned = true;
                    stunnedObjects.Add(col.gameObject);
                    //Debug.Log("stunned");
                    }

                }



                break;

        }
    }
}
