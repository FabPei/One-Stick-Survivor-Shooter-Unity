using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public TMP_Text clockText;
    public GameObject HighscoreText;
    public int iKilledEnemies;
    // Start is called before the first frame update
    void Start()
    {
        HighscoreText = GameObject.Find("HighscoreText");
        tmp = HighscoreText.GetComponent<TextMeshProUGUI>();
        PointsAwarder.Destroy_Event += IncreaseHighscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseHighscore()
    {
        //textMeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        iKilledEnemies++;
        tmp.text = iKilledEnemies.ToString();
        //Debug.Log("e");
    }
}
