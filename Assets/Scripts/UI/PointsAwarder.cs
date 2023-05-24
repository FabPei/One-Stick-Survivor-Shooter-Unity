using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAwarder : MonoBehaviour
{
    public delegate void Event_Points();
    public static event Event_Points Destroy_Event;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddPoint()
    {
        Destroy_Event();
        //Debug.Log("destroyed");
    }
}
