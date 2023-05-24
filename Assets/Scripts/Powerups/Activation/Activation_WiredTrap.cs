using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/Activation/WiredTrap")]
public class Activation_WiredTrap: Powerup
{

	public override void Apply(GameObject target)
	{

		target.GetComponent<PowerupController>().bWiredTrap = true;
		Debug.Log("Activating WiredTrap1");
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}

}
