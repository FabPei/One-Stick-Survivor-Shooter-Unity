using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/Speed")]
public class Speed_Template: Powerup
{
	public override void Apply(GameObject target)
	{
		float temp = target.GetComponent<BasicVariables>().movementSpeed;
		temp = temp * amount;
		target.GetComponent<BasicVariables>().movementSpeed = temp;
	}
}
