using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Clock : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public TMP_Text clockText;
    public Time timeText;
    public float timeRemaining = 10;
    float playedTime;
    public int minutes;
    // Start is called before the first frame update
    void Start()
    {
        playedTime = 0.0f;
        textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        playedTime += Time.deltaTime;
        DisplayTime(playedTime);
        //playedTime += Time.deltaTime;
        //if (playedTime >= 60.0f)
        //{
        //    minutes 
        //}
        ////minutes = playedTime / 60;
        //if (playedTime/60.0f >= 1.0f) //over 1 minute
        //{
        //    textMeshPro.text = "0" + Mathf.RoundToInt(playedTime / 60).ToString() + ":" + Mathf.RoundToInt(playedTime).ToString();
        //} else if (playedTime/60 > 9) //over 10 minutes
        //{
        //    textMeshPro.text = Mathf.RoundToInt(playedTime / 60).ToString() + ":" + Mathf.RoundToInt(playedTime).ToString();
        //} else if (playedTime/60.0f < 1)
        //    {
        //    textMeshPro.text = Mathf.RoundToInt(playedTime).ToString();
        //}


    }

    void DisplayTime(float timeToDisplay)
    {
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        textMeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
