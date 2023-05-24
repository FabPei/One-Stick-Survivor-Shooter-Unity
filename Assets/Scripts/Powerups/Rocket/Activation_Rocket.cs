using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/Rocket/Activation")]
public class Activation_Rocket : Powerup
{

	public override void Apply(GameObject target)
	{

		target.GetComponent<PowerupController>().bRocket = true;
		Debug.Log("ACtivating Rocket");
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}
	public void Reset()
	{
		type = "Rocket";
		displayName = "RocketSPECIFY";
		displayDescription = "This is the Description of " + displayName;
	}

}
