using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class LoadStatistics : MonoBehaviour, IDataPersistence
{
    public TMP_Text TStatistics;

    public List<string> LStatistics;

    public int totalDeathAmount;
    public int totalDamageAmount;
    public int enemiesKilledAmount;
    public int totalTimePlayed;
    public string mostPlayedLevel;
    public string mostUsedHero;
    public string mostUsedWeapon;
    public string mostUsedPowerUp;
    public int timesPickedRocket;
    public int timesPickedGrenade;
    public int timesPickedSwarmRocket;
    //public int timesPickeddRocket;
    public int timesPickedWiredTrap;
    public int timesPickedElectricField;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    
    public void LoadData(GameData data)
    {
       
        this.totalDeathAmount = data.totalDeathAmount;
        LStatistics.Add(totalDeathAmount.ToString());
        this.totalDamageAmount = data.totalDamageAmount;
        LStatistics.Add(totalDamageAmount.ToString());
        this.enemiesKilledAmount = data.enemiesKilledAmount;
        LStatistics.Add(enemiesKilledAmount.ToString());
        this.totalTimePlayed = data.totalTimePlayed;
        LStatistics.Add(totalTimePlayed.ToString());
        this.mostPlayedLevel = data.mostPlayedLevel;
        LStatistics.Add(mostPlayedLevel);
        this.mostUsedHero = data.mostUsedHero;
        LStatistics.Add(mostUsedHero);
        this.mostUsedWeapon = data.mostUsedWeapon;
        LStatistics.Add(mostUsedWeapon);
        this.mostUsedPowerUp = data.mostUsedPowerUp;
        LStatistics.Add(mostUsedPowerUp);
        this.timesPickedRocket = data.timesPickedRocket;
        LStatistics.Add(timesPickedRocket.ToString());
        this.timesPickedGrenade = data.timesPickedGrenade;
        LStatistics.Add(timesPickedGrenade.ToString());
        this.timesPickedSwarmRocket = data.timesPickedSwarmRocket;
        LStatistics.Add(timesPickedSwarmRocket.ToString());
        this.timesPickedWiredTrap = data.timesPickedWiredTrap;
        LStatistics.Add(timesPickedWiredTrap.ToString());
        //this.timesPickedRocket = 0;
        this.timesPickedElectricField = data.timesPickedElectricField;
        LStatistics.Add(timesPickedElectricField.ToString());

        insertText();
    }

    public void SaveData(ref GameData data)
    {
        //
    }

    public void insertText()
    {
        foreach (string element in LStatistics)
        {
            Debug.Log("element: " + element);
            TStatistics.text = TStatistics.text + "\n" + element;
        }
        //


    //    var allVariables = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
    //    for (int i = 0; i < allVariables.Length; i++)
    //    {
    //        Debug.Log(allVariables[i]);
    //    }


        //https://answers.unity.com/questions/1333022/how-to-get-every-public-variables-from-a-script-in.html
        //    Component[] myComponents = GetComponents(typeof(LoadStatistics));
        //    foreach (Component myComp in myComponents)
        //    {
        //        Type myObjectType = myComp.GetType();
        //        foreach (var Variarrr in myComp.GetType().GetProperties())
        //        {
        //            try
        //            {
        //                Debug.Log(Variarrr);
        //            }
        //            catch (Exception e)
        //            {
        //                Debug.LogError(e);
        //            }
        //        }
        //    }
    }
}
