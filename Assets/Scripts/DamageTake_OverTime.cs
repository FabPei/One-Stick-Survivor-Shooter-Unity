using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTake_OverTime : MonoBehaviour
{
    //https://stackoverflow.com/questions/44497565/damage-over-time-unity
    public float damage { get; set; }
    public float Seconds { get; set; }
    public float Delay { get; set; }
    public float ApplyDamageNTimes { get; set; }
    public float ApplyEveryNSeconds { get; set; }

    private int appliedTimes = 0;

    void Start()
    {
        StartCoroutine(Dps());
    }

    IEnumerator Dps()
    {
        

        while (true) {
            yield return new WaitForSeconds(Delay);
            //Debug.Log("Did damage");
            this.GetComponent<DamageTaker>().TakeDamage(damage);
        }
        //while (appliedTimes < ApplyDamageNTimes)
        //{
        //    this.GetComponent<DamageTaker>().TakeDamage(damage); //Damage method of the object
        //    yield return new WaitForSeconds(ApplyEveryNSeconds);
        //    appliedTimes++;
        //}

            //Destroy(this);
    }
}
