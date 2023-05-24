using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    private Powerup firstPowerup;
    private Powerup secondPowerup;
    private Powerup thirdPowerup;
    public GameObject powerupController;
    public List<Powerup> powerupList = new List<Powerup>();

    public List<Powerup> levelZeroList = new List<Powerup>();
    public List<Powerup> levelOneList = new List<Powerup>();
    public List<Powerup> levelTwoList = new List<Powerup>();
    public List<Powerup> levelThreeList = new List<Powerup>();
    public List<Powerup> levelFourList = new List<Powerup>();
    public List<Powerup> levelFiveList = new List<Powerup>();
    public List<Powerup> levelSixList = new List<Powerup>();

    public List<Powerup> unlockedLevelZeroList = new List<Powerup>();
    public List<Powerup> unlockedLevelOneList = new List<Powerup>();
    public List<Powerup> unlockedLevelTwoList = new List<Powerup>();
    public List<Powerup> unlockedLevelThreeList = new List<Powerup>();
    public List<Powerup> unlockedLevelFourList = new List<Powerup>();
    public List<Powerup> unlockedLevelFiveList = new List<Powerup>();
    public List<Powerup> unlockedLevelSixList = new List<Powerup>();

    public int amountOfLevelZero;
    public int amountOfLevelOne;
    public int amountOfLevelTwo;
    public int amountOfLevelThree;
    public int amountOfLevelFour;
    public int amountOfLevelFive;
    public int amountOfLevelSix;

    public float initialLevelZeroWeight;

    public void Start()
    {
        powerupController = GameObject.Find("PowerupController");
        int ID = 0;
        foreach (Powerup pu in powerupList) 
        {
            ID++;
            switch(pu.GetDisplayLevel())
            { 
            case 0:
                pu.SetID(ID);
                levelZeroList.Add(pu);
            break;
            case 1:
                    pu.SetID(ID);
                    levelOneList.Add(pu);
            break;
            case 2:
                    pu.SetID(ID);
                    levelTwoList.Add(pu);
             break;
              case 3:
                    pu.SetID(ID);
                    levelThreeList.Add(pu);
                    break;
                case 4:
                    pu.SetID(ID);
                    levelFourList.Add(pu);
                    break;
            case 5:
                    pu.SetID(ID);
                    levelFiveList.Add(pu);
                    break;
            case 6:
                    pu.SetID(ID);
                    levelSixList.Add(pu);
                    break;
            }
        }
        amountOfLevelOne = levelZeroList.Count;
        amountOfLevelZero = levelOneList.Count;
        amountOfLevelTwo = levelTwoList.Count;
        amountOfLevelThree = levelThreeList.Count;
        amountOfLevelFour = levelFourList.Count;
        amountOfLevelFive = levelFiveList.Count;
        amountOfLevelSix = levelSixList.Count;

        initialLevelZeroWeight = weightLevelZero(levelZeroList); //gets the initial zero level weight (e.g. 20%)

        assignWeightInList(weightLevelZero(levelZeroList), levelZeroList); //assigns weights to level zero
    } 
    // Start is called before the first frame update
    public Powerup GetFirstObject()
    {
        return powerupList[0];
    }



    public List<Powerup> GetThreeRandom(List<Powerup> listname)
    {
        firstPowerup = null;
        secondPowerup = null;
        thirdPowerup = null;
        List<Powerup> listOfWeightedPowerups = new List<Powerup>();
        List<Powerup> threeRandomPowerups = new List<Powerup>();
        foreach (Powerup pu in levelZeroList)
        {
            Debug.Log(pu);
            for (int i = 0; i < (int)Mathf.Round(pu.GetWeight()); i++)
            {
                listOfWeightedPowerups.Add(pu);
            }
        }

        float leveloneWeight;
        float oneLevelMaxWeight = 100.0f - initialLevelZeroWeight * levelZeroList.Count;
        Debug.Log("initialLevelZeroWeight " + initialLevelZeroWeight);
        Debug.Log("oneLevelMaxWeight " + oneLevelMaxWeight);
        if (1 <= unlockedLevelTwoList.Count) //is a level 2 powerup unlocked?
        {
        leveloneWeight = oneLevelMaxWeight / (unlockedLevelOneList.Count - 1); //yes, one lvl 0 slot is assigned to lvl two pu's

        } else {

        leveloneWeight = oneLevelMaxWeight / unlockedLevelOneList.Count;

        }

        assignWeightInList(leveloneWeight, unlockedLevelOneList); //assigns the weight to the

        foreach (Powerup pu in unlockedLevelOneList)
        {
            for (int i = 0; i < (int)Mathf.Round(pu.GetWeight()); i++)
            {
                listOfWeightedPowerups.Add(pu);
            }
        }
        Debug.Log("line 136");
        Debug.Log(listOfWeightedPowerups.Count);
        firstPowerup = listOfWeightedPowerups[Random.Range(0, listOfWeightedPowerups.Count)];
        listOfWeightedPowerups.RemoveAll(r => r.GetDisplayName() == firstPowerup.GetDisplayName());

        secondPowerup = listOfWeightedPowerups[Random.Range(0, listOfWeightedPowerups.Count)];
        thirdPowerup = listOfWeightedPowerups[Random.Range(0, listOfWeightedPowerups.Count)];
        int iOverflowStop = 0;
        while (firstPowerup.GetDisplayName() == secondPowerup.GetDisplayName())
        {
            iOverflowStop++;
            secondPowerup = listOfWeightedPowerups[Random.Range(0, listOfWeightedPowerups.Count)];
            if (iOverflowStop == 100)
            {
                Debug.Log("Found no different Powerup");
                break;
            }
        }
        iOverflowStop = 0;
        while (secondPowerup.GetDisplayName() == thirdPowerup.GetDisplayName() || firstPowerup.GetDisplayName() == thirdPowerup.GetDisplayName())
        {
            thirdPowerup = listOfWeightedPowerups[Random.Range(0, listOfWeightedPowerups.Count)];
            iOverflowStop++;
            if (iOverflowStop == 100)
            {
                Debug.Log("Found no different Powerup");
                break;
            }

        }
        //int size = listname.Count;
        //firstPowerup = Random.Range(0, listname.Count);
        //secondPowerup = Random.Range(0, listname.Count);
        //thirdPowerup = Random.Range(0, listname.Count);
        //while (firstPowerup == secondPowerup)
        //{
        //    secondPowerup = Random.Range(0, listname.Count);
        //}

        //while (secondPowerup == thirdPowerup || firstPowerup == thirdPowerup)
        //{
        //    thirdPowerup = Random.Range(0, listname.Count);
        //}
        threeRandomPowerups.Add(firstPowerup);
        threeRandomPowerups.Add(secondPowerup);
        threeRandomPowerups.Add(thirdPowerup);
        return threeRandomPowerups;
    }

    public float weightLevelZero(List<Powerup> levelzeroList)
    {
        float maxChance = 100.0f;

        return maxChance / amountOfLevelOne;
    }

    public float weightLevelOne(List<Powerup> leveloneList, float levelzeroChance)
    {
        return levelzeroChance / leveloneList.Count;
    }


    public List<int> GetPowerupChances(List<Powerup> leveloneList, float levelzeroChance)
    {
        List<int> listlist = new List<int>();
        //
        return listlist;
    }

    //Assigns weights to elements in List
    public void assignWeightInList(float weight, List<Powerup> templist)
    {
        foreach(Powerup up in templist)
        {
            up.SetWeight((int)weight);
        }
    }
    /**
     * Takes input Powerup and adds to the unlocked list and remvoes it from the normal one
     * 
     * 
     */
    public void unlockAndAddToLists(Powerup puAr)
    {
       
        switch (puAr.GetDisplayLevel())
        {
            case 0:
                for (int i = levelOneList.Count -1; i > -1 ; i--)
                {
                    //Debug.Log("Type " + levelOneList[i].GetDisplayName());
                    //Debug.Log(levelOneList[i].Get_Type());
                    if (levelOneList[i].Get_Type() == puAr.Get_Type())
                    {
                        unlockedLevelOneList.Add(levelOneList[i]);
                      // Debug.Log("Added " + levelOneList[i].GetDisplayName());
                        levelOneList.RemoveAt(i);
                        //Debug.Log("removed " + levelOneList[i].Get_Type());
                    }
                    Debug.Log(i);
                }
                
                break;
            case 1:
                
                    for (int i = levelTwoList.Count - 1; i > -1; i--)
                    {
                    if (levelTwoList[i].Get_Type() == puAr.Get_Type())
                    {
                        unlockedLevelTwoList.Add(levelTwoList[i]);
                        levelTwoList.RemoveAt(i);
                    }
                }
                break;
            case 2:
                    for (int i = levelThreeList.Count - 1; i > -1; i--)
                    {
                    if (levelThreeList[i].Get_Type() == puAr.Get_Type())
                    {
                        unlockedLevelThreeList.Add(levelThreeList[i]);
                        levelThreeList.RemoveAt(i); ;
                    }
                }
                break;
            case 3:
                for (int i = levelFourList.Count - 1; i > -1; i--)
                {
                    if (levelFourList[i].Get_Type() == puAr.Get_Type())
                    {
                        unlockedLevelFourList.Add(levelFourList[i]);
                        levelFourList.RemoveAt(i);
                    }
                }
                break;
            case 4:
                for (int i = levelFiveList.Count - 1; i > -1; i--)
                {
                    if (levelFiveList[i].Get_Type() == puAr.Get_Type())
                    {
                        unlockedLevelFiveList.Add(levelFiveList[i]);
                        levelFourList.RemoveAt(i);
                    }
                }
                break;
            case 5:
                for (int i = levelSixList.Count - 1; i > -1; i--)
                {
                    if (levelSixList[i].Get_Type() == puAr.Get_Type())
                    {
                        unlockedLevelSixList.Add(levelSixList[i]);
                        levelFiveList.RemoveAt(i);
                    }
                }
                break;
        }
    }
    
    /**
     * Takes the given Powerup and removes it from the List
     */
    public void removeFromLists(Powerup puAr)
    {
        Debug.Log("Removing" + puAr.GetDisplayName());
        switch (puAr.GetDisplayLevel())
        {
            case 0:
                foreach(Powerup pu in levelZeroList) {
                    //Debug.Log( " " + pu.GetDisplayName() + " puAR:" + puAr.GetDisplayName());
                    if (pu.GetID() == puAr.GetID())
                    {
                        levelZeroList.Remove(pu);
                        break;
                    }
                    
                }
                break;
            case 1:
                for(int i = unlockedLevelOneList.Count - 1; i > -1; i--)
                {
                    if (unlockedLevelOneList[i].GetID() == puAr.GetID())
                    {
                        unlockedLevelOneList.RemoveAt(i);
                    }
                }
                break;
            case 2:
                foreach (Powerup pu in unlockedLevelTwoList)
                {
                    if (pu.GetID() == puAr.GetID())
                    {
                        unlockedLevelTwoList.Remove(pu);
                    }
                }
                break;
            case 3:
                foreach (Powerup pu in unlockedLevelThreeList)
                {
                    if (pu.GetID() == puAr.GetID())
                    {
                        unlockedLevelThreeList.Remove(pu);
                    }
                }
                break;
            case 4:
                foreach (Powerup pu in levelFourList)
                {
                    if (pu.GetID() == puAr.GetID())
                    {
                        levelFourList.Remove(pu);
                    }
                }
                break;
            case 5:
                foreach (Powerup pu in levelFiveList)
                {
                    if (pu.GetID() == puAr.GetID())
                    {
                        levelFiveList.Remove(pu);
                    }
                }
                break;
        }
    }

    public void firstButtonClicked()
    {
        //Debug.Log("First button pressed");
        unlockAndAddToLists(firstPowerup);
        removeFromLists(firstPowerup);
        //Debug.Log("finished with removing");
        firstPowerup.Apply(powerupController);
    }

    public void secondButtonClicked()
    {
        //Debug.Log("Two button pressed");
        unlockAndAddToLists(secondPowerup);
        removeFromLists(secondPowerup);
        //Debug.Log("finished with removing");
        secondPowerup.Apply(powerupController);
    }

    public void thirdButtonClicked()
    {
       // Debug.Log("Three button pressed");
        unlockAndAddToLists(thirdPowerup);
        //Debug.Log("Unlocked");
        removeFromLists(thirdPowerup);
        //Debug.Log("finished with removing");
        thirdPowerup.Apply(powerupController);
    }
}
