using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public delegate void ClickAction();
    public static event ClickAction OnClicked;
    public static event ClickAction OnCrateContact;

    // Start is called before the first frame update
    void Start()
    {
        if (OnClicked != null)
        {
            OnClicked();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void Temp()
    {
        OnCrateContact();
}
}
