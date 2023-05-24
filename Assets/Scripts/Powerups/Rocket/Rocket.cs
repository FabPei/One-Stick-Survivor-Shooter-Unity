using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject RocketExplosion_Prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().AddForce(this.transform.right * 20f, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            GameObject re = Instantiate(RocketExplosion_Prefab, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            Destroy(gameObject);
        }
    }
}
