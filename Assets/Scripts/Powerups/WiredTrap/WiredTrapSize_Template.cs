using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/WiredTrap/Size")]
public class WiredTrapSize_Template : Powerup
{	
	//private GameObject Player;
	//private Vector3 scaleChange;

	public override void Apply(GameObject target)
	{

		//Vector3 currentScale = target.localScale;
		//scaleChange = new Vector3(currentScale.x * amount, currentScale.y * amount, currentScale.z);
		//target.transform.localScale = scaleChange;
		float temp = target.GetComponent<PowerupController>().WiredTrap_size;
		temp = temp + temp * (amount / 100.0f);
		target.GetComponent<PowerupController>().WiredTrap_size = temp;
	}
	public void Reset()
	{
		type = "WiredTrap";
		displayName = "WiredTrapSPECIFY";
		displayDescription = "This is the Description of " + displayName;
	}
}
