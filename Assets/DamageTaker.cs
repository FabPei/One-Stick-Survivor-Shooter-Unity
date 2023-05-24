using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DamageTaker : MonoBehaviour
{   
    //public Component RelevantComponent;
    // Start is called before the first frame update
    public void TakeDamage(float damageAmount)
    {
        this.GetComponent<BasicVariables>().currentHealth -= damageAmount;
    }


}
