using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerup/Damage")]
public class Damage_Template: Powerup
{
	
	public override void Apply(GameObject target)
	{
		float temp = target.GetComponent<BasicVariables>().damage;
		temp = temp + temp * (amount/100.0f);
		target.GetComponent<BasicVariables>().damage = temp;

	}
	public void Reset()
	{
		type = "Damage";
		displayName = "DamageSPECIFY";
		displayDescription = "This is the Description of " + displayName;
	}

}
