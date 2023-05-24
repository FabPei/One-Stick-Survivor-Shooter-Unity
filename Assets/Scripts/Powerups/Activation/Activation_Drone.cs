using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/Activation/Drone")]
public class Activation_Drone: Powerup
{

	public override void Apply(GameObject target)
	{

		target.GetComponent<PowerupController>().bDrone = true;
		Debug.Log("Activating Drone");
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}

}
