using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/SwarmRocket/Activation")]
public class Activation_SwarmRocket: Powerup
{

	public override void Apply(GameObject target)
	{

		target.GetComponent<PowerupController>().bSwarmRocket = true;
		Debug.Log("Activation_SwarmRocket: Activating ElectricBarrier");
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}

}
