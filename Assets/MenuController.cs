using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
	[Header("Volume Setting")]	 
	[SerializeField] private TMP_Text MusicSlideLevelText = null;
	[SerializeField] private Slider sliderMusic = null;
	[SerializeField] private int defaultVolume = 100;
	[SerializeField] private TMP_Text EffectsSlideLevelText = null;
	[SerializeField] private Slider sliderEffects = null;
	[SerializeField] private int defaultEffectsVolume = 100;
	//[Header("Confirmation")]	
	//[SerializeField] private GameObject confirmationPrompt = null;

	[Header("Gameplay Settings")]
	[SerializeField] private bool Landscapemode = false;
	[SerializeField] private bool HighFps = false;
	[SerializeField] private bool BatteryMode = false;

	[Header("Dropdown Settings")]
	public TMP_Dropdown Ddlanguages;
	public int language;

	[Header("Toggle Settings")]
	[SerializeField] private Toggle ToggleHighFps = null;
	[SerializeField] private Toggle ToggleBatterySaveMode = null;
	[SerializeField] private Toggle ToggleViewMode = null;

	[Header("Levels To Load")]
	[SerializeField] private GameObject noSavedGameDialog = null;
	public string _newGameLevel;
	private string levelToLoad;
	

	public void Start() {
		Ddlanguages.ClearOptions();
		List<string> languages = new List<string>();
		
		languages.Add("English");
		languages.Add("Korean");
		Ddlanguages.AddOptions(languages);
		Ddlanguages.value = 0;
		Ddlanguages.RefreshShownValue();

		_newGameLevel = "SpriteTest";
	}

	public void SetLanguage(int languagesIndex) {
		language = Ddlanguages.value;
	}

	public void NewGameDialogYes()
	{
		SceneManager.LoadScene(_newGameLevel);
	}
	public void LoadGameDialogYes() {
		if(PlayerPrefs.HasKey("SavedLevel")) 
		{
			levelToLoad = PlayerPrefs.GetString("SavedLevel");
			SceneManager.LoadScene(levelToLoad);
		} else {
			noSavedGameDialog.SetActive(true);
		}
	}

	public void ExitButton() {
		Application.Quit();
	}
	public void SetVolume(int volume){
		AudioListener.volume = volume;
		MusicSlideLevelText.text = volume.ToString("0");
	}
	public void Apply() {
		PlayerPrefs.SetInt("mastervolume", (int)AudioListener.volume);
		if(ToggleBatterySaveMode.isOn){
			PlayerPrefs.SetInt("BatteryMode", 1);
		} else {
			PlayerPrefs.SetInt("BatteryMode", 0);
		}
		if(ToggleHighFps.isOn){
			PlayerPrefs.SetInt("Highfps", 1);
		} else {
			PlayerPrefs.SetInt("Highfps", 0);;
		}
		if(ToggleViewMode.isOn){
			PlayerPrefs.SetInt("Landscapemode", 1);
		} else {
			PlayerPrefs.SetInt("Landscapemode", 0);
		}
		PlayerPrefs.SetInt("Language", Ddlanguages.value);
		
	}
	public void ResetButton(string MenuType){
		if(MenuType =="Audio")
		{
			AudioListener.volume = defaultVolume;
			sliderMusic.value = defaultVolume;
			MusicSlideLevelText.text = defaultVolume.ToString("0");
			Apply();
		}
		if(MenuType =="Language"){
			language = 0;
		}
	}
	/**public IEnumerator ConfirmationBox() {
		confirmationPrompt.SetActive(true);
		yield return new WaitForSeconds(2);
		confirmationPrompt.SetActive(false);
	}*/
}
