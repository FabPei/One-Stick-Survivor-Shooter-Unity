using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSelection_Button : MonoBehaviour
{
    public GameObject Powerups;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonOneClick()
    {
        Powerups.GetComponent<Powerups>().firstButtonClicked();
    }
    public void OnButtonTwoClick()
    {
        Powerups.GetComponent<Powerups>().secondButtonClicked();
    }
    public void OnButtonThreeClick()
    {
        Powerups.GetComponent<Powerups>().thirdButtonClicked();
    }
}
