using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/ElectricBarrier/Activation")]
public class Activation_ElectricBarrier: Powerup
{

	public override void Apply(GameObject target)
	{

		target.GetComponent<PowerupController>().bElectricBarrier = true;
		Debug.Log("Activating ElectricBarrier");
		//target.GetComponent<BasicVariables>().movementSpeed = temp;

	}

}
