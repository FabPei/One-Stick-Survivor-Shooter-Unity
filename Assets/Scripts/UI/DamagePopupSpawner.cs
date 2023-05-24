using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopupSpawner : MonoBehaviour
{
    public BasicVariables basicVariables;
    public DamagePopup dp_Prefab;
    public float lastHealth;
    // Start is called before the first frame update
    void Start()
    {
        basicVariables = this.GetComponent<BasicVariables>();
        lastHealth = basicVariables.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastHealth > basicVariables.currentHealth) {
            //
            //Debug.Log(this.name + " DamageFound");
            spawnPopup();

        }
    }
    public void spawnPopup()
    {
        DamagePopup dp = Instantiate(dp_Prefab, this.transform.position, Quaternion.Euler(0, 0, 0));
        dp.Setup(lastHealth - basicVariables.currentHealth);
        lastHealth = basicVariables.currentHealth;
    }
}
