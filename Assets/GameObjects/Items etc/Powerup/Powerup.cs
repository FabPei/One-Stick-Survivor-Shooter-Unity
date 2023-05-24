using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	


public abstract class Powerup : ScriptableObject
{
	[Header("DisplayName")]
	public string displayName;
	[Header("DisplayDescription")]
	public string displayDescription;
	[Header("DisplaySprite")]
	public Sprite displaySprite;
	[Header("DisplayLevel")]
	public int displayLevel;

	[Header("Amount")]
	public float amount;

	[Header("Type")] //For sorting
	public string type;

	[Header("Weight")] //For sorting
	public float weight;

	[Header("ID")] //For sorting
	public int ID;
	public abstract void Apply(GameObject target);

	public string GetDisplayDescription()
	{
		return displayDescription;
	}
	public Sprite GetDisplaySprite()
	{
		return displaySprite;
	}
	public string GetDisplayName()
	{
		return displayName;
	}
	public int GetDisplayLevel()
	{
		return displayLevel;
	}
	public float GetAmount()
	{
		return amount;
	}
	public string Get_Type()
	{
		return type;
	}
	public void SetWeight(int weight)
	{
		this.weight = weight;
	}
	public float GetWeight()
	{
		return weight;
	}
	public float GetID()
	{
		return ID;
	}
	public void SetID(int ID)
	{
		this.ID = ID;
	}
}
