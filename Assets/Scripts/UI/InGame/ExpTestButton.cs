using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
public class ExpTestButton : MonoBehaviour
{   
    [SerializeField]
    Expprogressbar bar;
    //public GameObject bar;
    // Start is called before the first frame update

    public void TestClick() {
        bar.UpdateProgress(0.1f,0.1f);
    }
}
