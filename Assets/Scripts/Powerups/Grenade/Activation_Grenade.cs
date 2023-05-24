using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/Grenade/Activation")]
public class Activation_Grenade : Powerup
{

	public override void Apply(GameObject target)
	{

		target.GetComponent<PowerupController>().bGrenade = true;
		Debug.Log("Activating Grenade");
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}
	public void Reset()
	{
		type = "Grenade";
		displayName = "GrenadeSPECIFY";
		displayDescription = "This is the Description of " + displayName;
	}

}
