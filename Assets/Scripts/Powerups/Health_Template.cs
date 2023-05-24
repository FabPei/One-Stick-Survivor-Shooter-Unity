using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/Health")]
public class Health_Template: Powerup
{

	public override void Apply(GameObject target)
	{
		float temp = target.GetComponent<BasicVariables>().maxHealth;
		temp = temp * amount;
		target.GetComponent<BasicVariables>().maxHealth = temp;

	}

}
