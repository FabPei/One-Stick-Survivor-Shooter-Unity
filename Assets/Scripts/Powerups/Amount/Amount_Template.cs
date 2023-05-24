using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/Amount")]
public class Amount_Template: Powerup
{

	public override void Apply(GameObject target)
	{
		target.GetComponent<PowerupController>().amountOfDrones = target.GetComponent<PowerupController>().amountOfDrones + (int)amount;


	}

}
