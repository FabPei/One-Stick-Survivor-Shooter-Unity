using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/Grenade/Amount")]
public class Amount_Grenade : Powerup
{

	public override void Apply(GameObject target)
	{

		target.GetComponent<PowerupController>().amountGrenade += this.amount;
		Debug.Log("Increasing Grenade");
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}
	public void Reset()
	{
		type = "Grenade";
		displayName = "GrenadeSPECIFY";
		displayDescription = "This is the Description of " + displayName;
	}

}
