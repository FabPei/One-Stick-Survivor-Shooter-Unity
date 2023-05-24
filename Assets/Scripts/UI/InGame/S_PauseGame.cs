using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PauseGame : MonoBehaviour
{
    public bool bPause;
    public GameObject Img_PauseMenu;
    public void Start()
    {
        Img_PauseMenu = GameObject.Find("Img_PauseMenu");
        bPause = false;
    }

    public void PauseGame()
    {
        if (bPause == false) {
            Time.timeScale = 0;
            bPause = true;
        } else
        {
            Time.timeScale = 1;
            bPause = false;
            //Debug.Log(Img_PauseMenu.SetActive(false));
            //Img_PauseMenu.SetActive(false);
        }
        //Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        bPause = false;
    }
}
