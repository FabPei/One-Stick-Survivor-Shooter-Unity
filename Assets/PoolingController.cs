using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
//UnityEngine.Rendering.Pool;

public class PoolingController : MonoBehaviour
{
    //public static ObjectPool SharedInstance;
    //public List<GameObject> pooledEnemies;
    //public List<GameObject> pooledBullets;
    //public GameObject Enemy;
    //public int amountToPoolEnemies;
    // Start is called before the first frame update
    public Enemy enemyPrefab;
    public ObjectPool<Enemy> enemyPool;
    public int amountEnemy;
    public List<Enemy> activeEnemiesList;

    public ExpDroplet expPrefab;
    public ObjectPool<ExpDroplet> expPool;
    public int amountExp;

    public Bullet bulletPrefab;
    public ObjectPool<Bullet> bulletPool;
    public int amountBullet;

    public Tile2 tile2Prefab;
    public ObjectPool<Tile2> tile2Pool;
    public int amountTile2;

    void Awake()
    {
        //SharedInstance = this;
        enemyPool = new ObjectPool<Enemy>(CreatePooledEnemy, OnTakeFromEnemyPool, OnReturnToEnemyPool, OnDestroyEnemy, false, 200, 500);
        expPool = new ObjectPool<ExpDroplet>(CreatePooledExp, OnTakeFromExpPool, OnReturnToExpPool, OnDestroyExp, false, 200, 500);
        bulletPool = new ObjectPool<Bullet>(CreatePooledBullet, OnTakeFromBulletPool, OnReturnToBulletPool, OnDestroyBullet, false, 200, 500);
        //tile2Pool = new ObjectPool<Tile2>(CreatePooledTile2, OnTakeFromTiles2Pool, OnReturnToTiles2Pool, OnDestroyTiles2, false, 2000, 5000);
    }
    void Start()
    {

        // poolObjects(pooledEnemies, Enemy, amountToPoolEnemies);
        for (int i = 0; i < amountEnemy; i++)
        {
            CreatePooledEnemy();
        }
        for (int i = 0; i < amountExp; i++)
        {
            CreatePooledExp();
        }
        for (int i = 0; i < amountBullet; i++)
        {
            CreatePooledBullet();
        }

        for (int i = 0; i < amountTile2; i++)
        {
           // CreatePooledTile2();
        }

    }

    //ENEMY POOL
    Enemy CreatePooledEnemy()
    {
        var instance = Instantiate(enemyPrefab);
        instance.gameObject.SetActive(false);
        return instance;

    }

    private void OnTakeFromEnemyPool(Enemy Instance)
    {
        activeEnemiesList.Add(Instance);
        Instance.gameObject.SetActive(true);
    }

    private void OnReturnToEnemyPool(Enemy Instance)
    {
        foreach(Enemy currentEnemy in activeEnemiesList)
        {
            if (currentEnemy == Instance)
            {
                activeEnemiesList.Remove(currentEnemy);
                break;
            }
        }
        Instance.gameObject.SetActive(false);
    }

    private void OnDestroyEnemy(Enemy Instance)
    {
        //
    }
    //END OF ENEMY POOL

    //Bullet POOL
    Bullet CreatePooledBullet()
    {
        var instance = Instantiate(bulletPrefab);
        instance.gameObject.SetActive(false);
        return instance;

    }

    private void OnTakeFromBulletPool(Bullet Instance)
    {
        Instance.gameObject.SetActive(true);
    }

    private void OnReturnToBulletPool(Bullet Instance)
    {
        Instance.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet Instance)
    {
        //
    }
    //END OF Bullet POOL

    //Exp POOL
    ExpDroplet CreatePooledExp()
    {
        var instance = Instantiate(expPrefab);
        instance.gameObject.SetActive(false);
        return instance;

    }

    private void OnTakeFromExpPool(ExpDroplet Instance)
    {
        Instance.gameObject.SetActive(true);
    }

    private void OnReturnToExpPool(ExpDroplet Instance)
    {
        Instance.gameObject.SetActive(false);
    }

    private void OnDestroyExp(ExpDroplet Instance)
    {
        //
    }
    //END OF Exp POOL


    //Exp POOL
    Tile2 CreatePooledTile2()
    {
        var instance = Instantiate(tile2Prefab);
        instance.gameObject.SetActive(false);
        return instance;

    }

    private void OnTakeFromTiles2Pool(Tile2 Instance)
    {
        Instance.gameObject.SetActive(true);
    }

    private void OnReturnToTiles2Pool(Tile2 Instance)
    {
        Instance.gameObject.SetActive(false);
    }

    private void OnDestroyTiles2(Tile2 Instance)
    {
        //
    }
    //END OF Exp POOL

    public void poolObjects(List<GameObject> list, GameObject GO, int amount)
    {
        list = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amount; i++)
        {
            tmp = Instantiate(GO);
            tmp.SetActive(false);
            list.Add(tmp);
        }
    }

    //public GameObject GetPooledEnemy()
    //{
    //    for (int i = 0; i < amountToPoolEnemies; i++)
    //    {
    //        if (!pooledEnemies[i].activeInHierarchy)
    //        {
    //            return pooledEnemies[i];
    //        }
    //    }
    //    return null;
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}

