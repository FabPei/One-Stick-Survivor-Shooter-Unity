using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{   
    private float fireForce = 20f;
    private float size;
    private float level;
    private float damage;
    private float Tank_time = 7f;
    protected float Timer;
    private float movementSpeed = 5.0f;
    private BasicVariables basicVariables;

    public void Init(float Tank_size, float Tank_level, float Tank_damage) {
    size = Tank_size;
    level = Tank_level;
    damage = Tank_damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        basicVariables = this.GetComponent<BasicVariables>();
        //currentHealth = basicVariables.currentHealth;
        //movementSpeed = basicVariables.movementSpeed;
        //maxHealth = basicVariables.maxHealth;
        this.transform.localScale *= basicVariables.size;
        //this.GetComponent<Rigidbody2D>().AddForce(this.transform.right * fireForce, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += -transform.right * movementSpeed * Time.deltaTime;
        Timer += Time.deltaTime;
        
        if (Timer >= Tank_time)
        {
            //Debug.Log(Timer);
            Timer = 0f;
            Destroy(this.gameObject);
            
        }
        
        //this.transform.Translate(1,0,0);
    }
}
