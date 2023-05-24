using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/Activation/Tank")]
public class Activation_Tank: Powerup
{

	public override void Apply(GameObject target)
	{
		target.GetComponent<PowerupController>().bTank = true;
		Debug.Log("Activating bTank");
		//temp = temp * amount;
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}

}
