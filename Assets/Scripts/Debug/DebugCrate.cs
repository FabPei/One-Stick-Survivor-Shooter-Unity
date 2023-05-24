using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCrate : MonoBehaviour
{

    public WiredTrap WiredTrap_Prefab;
    public GameObject Enemy_Big_Prefab;
    public GameObject Enemy_Fast_Prefab;

    public bool bWiredTrap = false;
    public bool bEnemy_Big = false;
    public bool bEnemy_Fast = false;
    //public bool bWiredTrap = false;
    // Start is called before the first frame update
    void Start()
    {

        if (bWiredTrap) { 
        WiredTrap WiredTrapFinal = Instantiate(WiredTrap_Prefab, this.transform.position, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)));
        }
        if (bEnemy_Big)
        {
            GameObject Enemy_BigFinal = Instantiate(Enemy_Big_Prefab, this.transform.position + new Vector3(5, 5, 0), this.transform.rotation);
        }
        if (bEnemy_Fast)
        {
            GameObject Enemy_FastFinal = Instantiate(Enemy_Fast_Prefab, this.transform.position + new Vector3(7, 7, 0), this.transform.rotation);
        }
        Destroy(this.gameObject);
    }

    // Update is called once per frameAA
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
    
       
    }
}
