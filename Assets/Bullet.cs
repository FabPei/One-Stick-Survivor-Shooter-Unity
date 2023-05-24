using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public bool bPenetrate = false;
	public float damage;
	public int iMaxHits = 0;
	public int iHits = 0;
    public Bullet bullet_prefab;
	Collider2D m_ObjectCollider;

	void Start()
    {
        //Debug.Log("Start");
		damage = this.GetComponent<BasicVariables>().damage;

		m_ObjectCollider = GetComponent<CircleCollider2D>();
		//Debug.Log("iMaxPenetrations: " + iMaxHits);
		if (bPenetrate)
        {

            m_ObjectCollider.isTrigger = true;
        } else
        {
            m_ObjectCollider.isTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Enemy"))
        {

            if (col.gameObject.TryGetComponent<DamageTaker>(out DamageTaker enemyComponent))
            {
                enemyComponent.TakeDamage(damage);
            }

            iHits++;
            if (iMaxHits <= iHits)
            {
                m_ObjectCollider = GetComponent<Collider2D>();
                m_ObjectCollider.isTrigger = false;
                bPenetrate = false;
                //Destroy(this.gameObject);
                //Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (iMaxHits < iHits)
            {
                Destroy(this.gameObject);
                Destroy(gameObject);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {

            if (col.gameObject.TryGetComponent<DamageTaker>(out DamageTaker enemyComponent))
            {
                enemyComponent.TakeDamage(damage);
            }
            //Destroy(col.gameObject);

            //Debug.Log(newPos);         

            Destroy(this.gameObject);
            Destroy(gameObject);
        }

        
    }

    //private void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.gameObject.CompareTag("Enemy"))
    //    {

    //        float newRotation = Random.Range(this.transform.rotation.z - 45.0f, this.transform.rotation.z + 45.0f);

    //        Bullet bullet = Instantiate(bullet_prefab, this.transform.position, Quaternion.LookRotation(new Vector3(0, 0, newRotation)));

    //        //Debug.Log(newPos);         

    //        Destroy(this.gameObject);
    //        Destroy(gameObject);
    //    }


    //}


}
//private void OnTriggerExit2D(Collider2D col)
//{
//	if (col.gameObject.CompareTag("Enemy"))
//	{

//		if (col.gameObject.TryGetComponent<DamageTaker>(out DamageTaker enemyComponent))
//		{
//			enemyComponent.TakeDamage(damage);
//		}
//		//if (bPenetrate == false)
//		//{
//		//    Destroy(this.gameObject);
//		//    Destroy(gameObject);
//		//}

//		iHits++;
//           if (iMaxHits - 1 < iHits)
//           {
//			m_ObjectCollider = GetComponent<Collider2D>();
//			m_ObjectCollider.isTrigger = false;
//			bPenetrate = false;
//			//Destroy(this.gameObject);
//               //Destroy(gameObject);
//           }




//       }

//}

