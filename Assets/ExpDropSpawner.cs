using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDropSpawner : MonoBehaviour
{
    public ExpDroplet ed_Prefab;
    public void spawnExpDroplet(float exp)
    {
        ExpDroplet ed = Instantiate(ed_Prefab, this.transform.position, this.transform.rotation);
        ed.exp = exp;
    }
    //public void spawnPopup()
    //{
    //    DamagePopup dp = Instantiate(dp_Prefab, this.transform.position, Quaternion.Euler(0, 0, 0));
    //    dp.Setup(lastHealth - basicVariables.currentHealth);
    //    lastHealth = basicVariables.currentHealth;
    //}
}
