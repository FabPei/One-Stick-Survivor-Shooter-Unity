using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
	[Header("General Setting")]	 
	[SerializeField] private bool canUse = false;
	[SerializeField] private MenuController menuController;

	[Header("Volume Setting")]	 
	[SerializeField] private TMP_Text MusicSlideLevelText = null;
	[SerializeField] private Slider sliderMusic = null; 

	[Header("Gameplay Settings")]
	[SerializeField] private bool Landscapemode = false;
	[SerializeField] private bool HighFps = false;
	[SerializeField] private bool BatteryMode = false;

	[Header("Toggle Settings")]
	[SerializeField] private Toggle ToggleHighFps = null;
	[SerializeField] private Toggle ToggleBatterySaveMode = null;
	[SerializeField] private Toggle ToggleViewMode = null;
	
	[Header("Dropdown Settings")]
	public TMP_Dropdown Ddlanguages;
	public int language;
	private void Awake()
	{
		if (canUse)
		{
			if(PlayerPrefs.HasKey("masterVolume"))
			{
				int localMusic = PlayerPrefs.GetInt("masterVolume");
				MusicSlideLevelText.text = localMusic.ToString("0");
				sliderMusic.value = localMusic;
				AudioListener.volume = localMusic;
			} else {
				menuController.ResetButton("Audio");
			}

			if (PlayerPrefs.HasKey("Language"))
			{
				//Ddlanguages.value = PlayerPrefs.GetInt("Language");
			} else {
				//Ddlanguages.value = 0; //default language is 0 thus english
			}
			if (PlayerPrefs.HasKey("BatteryMode"))
			{
				if (PlayerPrefs.GetInt("BatteryMode") == 1){
					ToggleBatterySaveMode.isOn = true;
				}
			
			} else {
				ToggleBatterySaveMode.isOn = false;
			}

			if (PlayerPrefs.HasKey("Highfps"))
			{
				if (PlayerPrefs.GetInt("Highfps") == 1){
					ToggleHighFps.isOn = true;
				}
			
			} else {
				ToggleHighFps.isOn = false;
			}

			if (PlayerPrefs.HasKey("Landscapemode"))
			{
				if (PlayerPrefs.GetInt("Landscapemode") == 1){
					ToggleViewMode.isOn = true;
				}
			} else {
				ToggleViewMode.isOn = false;
			}
		}
	}
}
