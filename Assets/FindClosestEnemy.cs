using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestEnemy : MonoBehaviour
{	
	public GameObject Enemy;

	public GameObject Firepoint;

	void Start()
    {
		Firepoint = this.transform.Find("DroneFirepoint").gameObject;
	}
    public void mFindClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;
		Enemy closestEnemy = null;
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

		foreach (Enemy currentEnemy in allEnemies) {
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}
		if (closestEnemy != null) {  
		Debug.DrawLine (this.transform.position, closestEnemy.transform.position);
			//transform.LookAt(closestEnemy.transform.position);
			//FirePoint.transform.right = closestEnemy.transform.position - FirePoint.transform.position;
			Firepoint.transform.right = closestEnemy.transform.position - transform.position;
		}
	}
}
