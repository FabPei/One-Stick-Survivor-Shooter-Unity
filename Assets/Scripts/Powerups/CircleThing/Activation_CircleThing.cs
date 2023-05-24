using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/CircleThing/Activation")]
public class Activation_CircleThing: Powerup
{

	public override void Apply(GameObject target)
	{

		target.GetComponent<PowerupController>().bCircleThing = true;
		Debug.Log("Activating CircleThing");
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}

}
