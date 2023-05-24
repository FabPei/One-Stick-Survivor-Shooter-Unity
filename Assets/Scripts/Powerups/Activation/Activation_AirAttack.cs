using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/Activation/AirAttack")]
public class Activation_AirAttack: Powerup
{

	public override void Apply(GameObject target)
	{
		target.GetComponent<PowerupController>().bAirAttack = true;
		Debug.Log("Activating AirAttack1");
		//temp = temp * amount;
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}

}
