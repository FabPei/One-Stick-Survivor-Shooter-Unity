using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmRocket : MonoBehaviour
{
    private float fireForce = 20f;
    private float size;
    private float level;
    private float damage;
    private float Timer = 0.0f;
    protected float delay = 0.5f;
    [SerializeField] private float movementSpeed = 30.0f;
    private BasicVariables basicVariables;
    public Enemy closestEnemy;
    public float rotationSpeed = 240.0f;
    private float distanceThreshold = 5f;

    public Rigidbody2D rb;
    public List<Enemy> currentTargetedEnemies;

    // Start is called before the first frame update
    void Start()
    {
        basicVariables = this.GetComponent<BasicVariables>();

        rb = this.GetComponent<Rigidbody2D>();

        this.transform.localScale *= basicVariables.size;
        Timer = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer += Time.deltaTime;
        if (delay < Timer)
        {
            if (closestEnemy != null || closestEnemy.gameObject.activeInHierarchy == true)
            {
                RotateRocket();
                //rb.velocity = transform.right * (basicVariables.movementSpeed * 2);
                //rb.velocity = new Vector3(0,0,0);
                this.GetComponent<Rigidbody2D>().AddForce(this.transform.right * (movementSpeed * 1.25f), ForceMode2D.Force);

            } 
            if (closestEnemy == null || closestEnemy.gameObject.activeInHierarchy == false) { 
                FindClosestEnemy();

                Debug.DrawLine(this.transform.position, closestEnemy.transform.position, Color.grey);
                rb.velocity = transform.right * basicVariables.movementSpeed;
            }



        }
        else
        {
            float distance = Vector3.Distance(this.transform.position, closestEnemy.transform.position);
            if (distance > distanceThreshold) { 
                rb.velocity = transform.right * basicVariables.movementSpeed;

            } else
            {
                this.transform.LookAt(closestEnemy.transform);
                rb.velocity = transform.right * basicVariables.movementSpeed;
            }

        }

        //this.transform.position += -closestEnemy.transform.right * basicVariables.movementSpeed * Time.deltaTime;
        //Debug.Log(closestEnemy.transform.position);

        //RotateRocket();
        //Debug.Log(rotationSpeed);
        
        
        
    }

    public void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        
        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        //Debug.Log("Finding new Enemy");
        
        //transform.LookAt(closestEnemy.transform.position);
        //FirePoint.transform.right = closestEnemy.transform.position - FirePoint.transform.position;
        //transform.right = closestEnemy.transform.position - transform.position;
    }

    private void RotateRocket()
    {
        Vector2 direction = (Vector2)closestEnemy.transform.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.right).z;

        rb.angularVelocity = -rotateAmount * rotationSpeed;

        //var rotation = Quaternion.LookRotation(heading);

        //transform.right = closestEnemy.transform.position - transform.position;
        //float angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg;
        //Debug.Log(rotation);
        //rotation.x = this.transform.rotation.x;
        //rotation.y = this.transform.rotation.y;
        //this.transform.rotation = rotation * Time.deltaTime;

        //this.transform.forward = Vector3.RotateTowards(this.transform.forward, heading, rotationSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime));
    }
}
