using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{   public GameObject Player;
    public GameObject bulletPrefab;
    public GameObject Firepoint;
    public float fireForce = 20f;
    private Vector3 VPosition;
    public GameObject[] playerl;
    public double DelayAmount = 1.0; //Shootingspeed basicFiring
    protected float Timer;
    // Start is called before the first frame update
    void Start()
    {
       VPosition = this.transform.position;
       //Debug.Log(VPosition);
       Player = GameObject.FindGameObjectWithTag("Player");
        Firepoint = this.transform.Find("DroneFirepoint").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<FindClosestEnemy>().mFindClosestEnemy();



        //following sticks to the Player
        //this.transform.position = Player.transform.position + new Vector3(1,1,0);
         this.transform.position = Player.transform.position + Player.transform.TransformDirection(VPosition);
        //Fire();
        
        Timer += Time.deltaTime;
      
         if (Timer >= DelayAmount)
         {
             Timer = 0f;
             Fire();
             

         }
    }
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, Firepoint.transform.position, Firepoint.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(Firepoint.transform.right * fireForce, ForceMode2D.Impulse);
        
    }
}
