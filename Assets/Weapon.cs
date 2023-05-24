using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform FirePoint;
    public ObjectPool<Bullet> bulletPool;
    public ObjectPool<Enemy> enemyPool;
    public GameObject PoolingController;
    public PoolingController pc;
    [SerializeField] public float fireForce = 1f;
    public Player player;

    public float timer = 0.0f;
    public float delay = 0.2f;
    
    //public Enemy enemy;
    void Start()
    {
        PoolingController = GameObject.Find("PoolingController");
        pc = PoolingController.GetComponent<PoolingController>();
        bulletPool = pc.bulletPool;
        enemyPool = pc.enemyPool;
    }

    public void Update()
    {
        //player = GameObject.FindWithTag("Player");
        //this.transform.position = player.transform.position;
        timer += Time.deltaTime;
        if (timer > delay)
        {
            FindClosestEnemy();
            timer = 0.0f;
        }
        
    }

    public void Fire()
    {
        //Debug.Log("Fire");
        var bullet = bulletPool.Get();
        //GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, this.transform.rotation);
        bullet.transform.position = FirePoint.position;
        bullet.transform.rotation = this.transform.rotation;
        //Debug.Log(FirePoint.position);
        //Debug.Log(bullet);
        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * fireForce, ForceMode2D.Impulse);
        this.transform.Translate(-0.2f, 0, 0);
        //this.transform.Translate(-1, 0, 0);
    }

    public void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
       //Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        //Debug.Log(enemyPool.CountAll);
        foreach (Enemy currentEnemy in pc.activeEnemiesList)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        //foreach (Enemy currentEnemy in allEnemies)
        //{


        //    float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
        //    if (distanceToEnemy < distanceToClosestEnemy)
        //    {
        //        distanceToClosestEnemy = distanceToEnemy;
        //        closestEnemy = currentEnemy;
        //    } 
        //}
        if (closestEnemy != null) { 
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position, Color.grey);
            //transform.LookAt(closestEnemy.transform.position);
            //FirePoint.transform.right = closestEnemy.transform.position - FirePoint.transform.position;
            transform.right = (closestEnemy.transform.position - transform.position) * Time.deltaTime;
        }
    }
}
