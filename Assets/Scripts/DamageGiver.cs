using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGiver : MonoBehaviour
{
    public float damage = 1.0f;
    public bool bSustain = false;
    //public var Coll2D;
    // Start is called before the first frame update
    void Start()
    {
        damage = this.GetComponent<BasicVariables>().damage;
        //Coll2D = this.GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
       //Debug.Log(this.name);
        if (col.gameObject.CompareTag("Enemy"))
        {

            if (col.gameObject.TryGetComponent<DamageTaker>(out DamageTaker enemyComponent))
            {
                enemyComponent.TakeDamage(damage);
            }
            //Destroy(col.gameObject);
            if (bSustain == false)
            {
                Destroy(this.gameObject);
                Destroy(gameObject);
            }

            
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(this.name);
        switch (col.tag)
        {
            case "Enemy":
                if (col.gameObject.TryGetComponent<DamageTaker>(out DamageTaker enemyComponent))
                {
                    enemyComponent.TakeDamage(damage);
                }
                //Destroy(col.gameObject);
                if (bSustain == false) { 
                Destroy(this.gameObject);
                Destroy(gameObject);
                }

                
                break;
        }
    }
}