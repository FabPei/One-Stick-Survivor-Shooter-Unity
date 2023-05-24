using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
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
   // public int timesUsedRocket;
    //public string timesKilledByENEMY;




    //the values defined in this constructor will be the default values
    //the game starts with when theres no data to load
    public GameData()
    {
        this.totalDeathAmount = 0;
        this.totalDamageAmount = 0;
        this.enemiesKilledAmount = 0;
        this.totalTimePlayed = 0;
        this.mostPlayedLevel = "unknown";
        this.mostUsedHero = "unknown";
        this.mostUsedWeapon = "unknown";
        this.mostUsedPowerUp = "unknown";
        this.timesPickedRocket = 0;
        this.timesPickedGrenade = 0;
        this.timesPickedSwarmRocket = 0;
        this.timesPickedWiredTrap = 0;
        //this.timesPickedRocket = 0;
        this.timesPickedElectricField = 0;

    }
}
