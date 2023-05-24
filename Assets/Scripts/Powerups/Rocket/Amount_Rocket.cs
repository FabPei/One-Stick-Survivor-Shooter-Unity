using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/Rocket/Amount")]
public class Amount_Rocket : Powerup
{

	public override void Apply(GameObject target)
	{

		target.GetComponent<PowerupController>().amountRocket += this.amount;
		Debug.Log("Increasing Rocket");
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}
	public void Reset()
	{
		type = "Rocket";
		displayName = "RocketSPECIFY";
		displayDescription = "This is the Description of " + displayName;
	}

}
