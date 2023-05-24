using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/SwarmRocket/Amount")]
public class Amount_SwarmRocket : Powerup
{

	public override void Apply(GameObject target)
	{

		target.GetComponent<PowerupController>().amountSwarmRocket += this.amount;
		Debug.Log("Increasing SwarmRocket");
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}
	public void Reset()
	{
		type = "SwarmRocket";
		displayName = "SwarmRocketSPECIFY";
		displayDescription = "This is the Description of " + displayName;
	}

}
