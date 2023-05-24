using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/AirAttack/Size")]
public class AirAttackSize_Template : Powerup
{	
	//private GameObject Player;
	//private Vector3 scaleChange;

	public override void Apply(GameObject target)
	{

		//Vector3 currentScale = target.localScale;
		//scaleChange = new Vector3(currentScale.x * amount, currentScale.y * amount, currentScale.z);
		//target.transform.localScale = scaleChange;
		float temp = target.GetComponent<PowerupController>().AirAttack_size;
		temp = temp + temp * (amount / 100.0f);
		target.GetComponent<PowerupController>().AirAttack_size = temp;
	}
	public void Reset()
	{
		type = "AirAttack";
		displayName = "AirAttackSPECIFY";
		displayDescription = "This is the Description of " + displayName;
	}
}
