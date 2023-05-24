using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGiver_OverTime : MonoBehaviour
{
    public float damage = 1.0f;
    public bool bSustain = false;
    protected float timer;
    public float cd;
    public float radius;
    //public var Coll2D;
    // Start is called before the first frame update
    void Start()
    {
        damage = this.GetComponent<BasicVariables>().damage;
        //radius = this.GetComponent<CircleCollider2D>().radius;
        //Coll2D = this.GetComponent<Collider2D>();
        //Debug.Log("damage" + damage);
        //InvokeRepeating("Dps", 1.0f, 1.0f);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) { 
            if (col.GetComponent<DamageTake_OverTime>() == null)
        {
            //Debug.Log("attached");
            var dps = col.gameObject.AddComponent<DamageTake_OverTime>();
            dps.damage = damage;
            //dps.ApplyEveryNSeconds = 10f;
            //dps.ApplyDamageNTimes = 10f;
            dps.Delay = cd;
                // and set the rest of the public variables
            }
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (col.GetComponent<DamageTake_OverTime>() != null)
            {
                //Debug.Log("Removed");
                Destroy(col.GetComponent<DamageTake_OverTime>());
                // and set the rest of the public variables
            }
        }

    }
    void Dps()
    {
        //Debug.Log("hello" + this.transform.position + " " + this.GetComponent<CircleCollider2D>().radius);
        // QueryTriggerInteraction.Collide might be needed
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, this.GetComponent<CircleCollider2D>().radius);

        foreach (Collider col in hitColliders)
        {
            //Debug.Log("hello2");
            //Debug.Log(col.tag);
            col.GetComponent<DamageTaker>().TakeDamage(damage);
        }
    }



    //private void OnCollisionStay2D(Collision2D col)
    //{
    //    if (timer > cd)
    //    {


    //        if (col.gameObject.CompareTag("Enemy"))
    //        {

    //            if (col.gameObject.TryGetComponent<DamageTaker>(out DamageTaker enemyComponent))
    //            {
    //                enemyComponent.TakeDamage(damage);
    //            }
    //            //Destroy(col.gameObject);
    //            if (bSustain == false)
    //            {
    //                Destroy(this.gameObject);
    //                Destroy(gameObject);
    //            }


    //        }
    //        timer = 0.0f;
    //    }

    //}
    //private void OnTriggerStay2D(Collider2D col)
    //{
    //    if (timer > cd)
    //    {
    //        switch (col.tag)
    //        {
    //        case "Enemy":
    //            if (col.gameObject.TryGetComponent<DamageTaker>(out DamageTaker enemyComponent))
    //            {
    //                enemyComponent.TakeDamage(damage);
    //            }
    //            //Destroy(col.gameObject);
    //            if (bSustain == false) { 
    //                Destroy(this.gameObject);
    //                Destroy(gameObject);
    //            }
    //            break;
    //        }

    //        timer = 0.0f;
    //    }

    //}

}