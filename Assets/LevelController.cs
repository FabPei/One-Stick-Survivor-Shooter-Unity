using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelController : MonoBehaviour
{


    [Header("GameObjects")]

    public GameObject Player;
    
    public Camera MainCamera;
    

    public GameObject inputController;

    public GameObject PoolingController;

    
    //IENUMERATOR
    private Coroutine IE_enemySpawn_coroutine;



    private float height;
     private float width;

    public float timer = 0.0f;

    [Header("Enemy")]
    public GameObject EnemyPrefab;
    public ObjectPool<Enemy> enemyPool;
    public float enemySpawn_cd_last = 5.0f;
    public float enemySpawn_cd = 77.0f;
    public int amountToSpawn_Enemy = 10; //See inspector for real value

    [Header("Exp")]
    public GameObject ExpDropletPrefab;
    public ObjectPool<ExpDroplet> expPool;
    public float exp_cd_last = 5.0f;
    public float exp_cd = 5.0f;
    public int amountToSpawn_EXP = 5;


    [Header("Crate")]
    public Crate CratePreFab;

    public float crate_cd_last = 0.0f;
    public float crate_cd = 15.0f;
    private float lastCrate = 1f;

    public List<Vector3> spawnPositions;
    Vector3 VnewLocation;
    Vector3 VfinalLocation;


    // Start is called before the first frame update

    void Start()
    {
        height = 2f * MainCamera.orthographicSize;
        width = height * MainCamera.aspect;
        Player = GameObject.Find("Player");
        inputController = GameObject.Find("InputController");
        PoolingController = GameObject.Find("PoolingController");

        enemyPool = PoolingController.GetComponent<PoolingController>().enemyPool;
        expPool = PoolingController.GetComponent<PoolingController>().expPool;
        //enemyPool = PoolingController.GetComponent<PoolingController>().enemyPool;

        //SpawnEnemiesCircle(10);

        //IE_enemySpawn_coroutine = IE_enemySpawn; //needs to be assigned for some reason



        //InvokeRepeating("spawning", 3.0f, 5.0f);
        //SpawnEnemiesCircle(amountToSpawn_Enemy);
        //Debug.Log(amountToSpawn_EXP);
        //spawnEXP(amountToSpawn_EXP);
        //Debug.Log("here" + checkAmount(amountToSpawn_EXP, "Exp"));

    }


    void Update() {

        
        timer += Time.deltaTime;
        spawningObjects();


        VnewLocation = inputController.GetComponent<JoystickInput>().moveDirection;
        Vector3 VnewLocationM = new Vector3(VnewLocation.x * 5.5f, VnewLocation.y * 5.5f, 0);
        
        
        Debug.DrawLine(Vector3.zero, VnewLocationM, Color.white, 0.2f);
        //Debug.DrawLine(Player.transform.position, VnewLocationM, Color.blue, 0.5f);
        Debug.DrawLine(Player.transform.position, Player.transform.position + (VnewLocation * 60f), Color.green, 0.2f);

        VfinalLocation = Player.transform.position + (VnewLocation * 60f);
        //this.transform.position = Player.transform.position + Player.transform.TransformDirection(VPosition);
    }

    void spawningObjects()
    {
        if (timer >= enemySpawn_cd_last)
        {
            SpawnEnemiesCircle(amountToSpawn_Enemy);
            enemySpawn_cd_last = timer + enemySpawn_cd;
            amountToSpawn_Enemy += 2;
        }

        if (timer >= exp_cd_last)
        {
            spawnEXP(checkAmount(amountToSpawn_EXP, "Exp"));
            exp_cd_last = timer + exp_cd;
            //amountToSpawn_Enemy += 5;
        }

        if (timer >= crate_cd_last)
        {
            spawnCrate();
            crate_cd_last = timer + crate_cd;
            //amountToSpawn_Enemy += 5;
        }
    }

    /**
     * The goal of this method is to handle all the enemies to spawn
     */
    void spawning()
    {
        //spawnCrate();
        
        //int temp = amountToSpawn_Enemy - GameObject.FindGameObjectsWithTag("Enemy").Length;
        int temp = amountToSpawn_Enemy; // - GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Debug.Log("amountToSpawn_Enemy " + amountToSpawn_Enemy);
        //Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);

        SpawnEnemiesCircle(temp);

        amountToSpawn_Enemy += 5;

       //spawnEXP(checkAmount(amountToSpawn_EXP, "Exp")); //This spawns our EXP

    }

        /**
         * Spawns the Crates
         */
    void spawnCrate() {
        if(Random.value < lastCrate) { //lastCrate is the probability for spawning the Crate
        float _xAxis = UnityEngine.Random.Range(Player.transform.position.x - width/2, Player.transform.position.x + width/2);
        float _yAxis = UnityEngine.Random.Range(Player.transform.position.y - height/2, Player.transform.position.y + height/2);

        Vector3 _randomPosition = new Vector3(_xAxis, _yAxis, 0f );
        Crate CrateFinal = Instantiate(CratePreFab, _randomPosition, Quaternion.Euler(Vector3.forward));
            
            lastCrate = 0.05f;
        } else {

        lastCrate = lastCrate * 1.05f;
        }
    }

    /**
     * This Method spawns enemies around the player in a circle. Good for cornering the player.
     */
    public void SpawnEnemiesCircle(int amountToSpawn)
    {
        //Debug.Log("LevelController: spawning enemies");

     float radius = 1f; //eine variable für die Radiusberechnung, je höher, desto weiter entfernt
        
     for (int i = 0; i < amountToSpawn; i++)
     {
            var EnemyPrefab = enemyPool.Get();
            if (EnemyPrefab != null)
            {
                float angle = (i * Mathf.PI * 2.5f + Random.Range(-20.0f, 20.0f)) / amountToSpawn; //randomize the float
                Vector3 newPos = new Vector3(Player.transform.position.x + Mathf.Cos(angle) * radius * (40 + Random.Range(1.0f, 10.0f)), Player.transform.position.y + Mathf.Sin(angle) * radius * (40 + Random.Range(1.0f, 10.0f)), 0);
                EnemyPrefab.transform.position = newPos;
                EnemyPrefab.transform.rotation = Quaternion.identity;
                //EnemyPrefab.SetActive(true);
            }

            //    float angle = (i * Mathf.PI*2.5f + Random.Range(-20.0f, 20.0f)) / amountToSpawn; //randomize the float
            // Vector3 newPos = new Vector3(Player.transform.position.x + Mathf.Cos(angle) * radius * (40 + Random.Range(1.0f, 10.0f)), Player.transform.position.y + Mathf.Sin(angle) * radius * (40 + Random.Range(1.0f, 10.0f)), 0);
            // Enemy EnemyPrefabFinal = Instantiate(EnemyPrefab, newPos, Quaternion.identity);
            //Debug.Log("Player.position : " + Player.transform.position);
            //Debug.Log("newPos : " + newPos);
            //Debug.Log(newPos);
        }
    }

    /**
     * This Method spawns enemy at a position in a circle. VfinalLocation is a vector far away from the player. Thus it always spawns a small circle of enemies far away in the direction the player walks.
     */
    public void SpawnEnemiesCircleZ(int amountToSpawn_Enemy)
    {
        //Debug.Log(VfinalLocation.x);
        if (System.Math.Round(VfinalLocation.x) == System.Math.Round(Player.transform.position.x) && System.Math.Round(VfinalLocation.y) == System.Math.Round(Player.transform.position.y) ) {
            //Debug.Log("SpawnEnemiesCircleZ: invalid location" + VfinalLocation.x);
        } else { 
            float radius = 1f;
            for (int i = 0; i < amountToSpawn_Enemy; i++)
            {
                float angle = (i * Mathf.PI * 2.5f + Random.Range(1.0f, 3.0f)) / amountToSpawn_Enemy; //randomize the float
                Vector3 newPos = new Vector3(VfinalLocation.x + Mathf.Cos(angle) * radius * 5, Mathf.Sin(angle) * radius * 5 + VfinalLocation.y, 0);
                //Enemy EnemyPrefabFinal = Instantiate(EnemyPrefab, newPos, Quaternion.identity);
                //Debug.Log(newPos);
            }
        }
    }

    public void spawnEXP(int amountToSpawnEXP) {
     float radius = 1f;

        
        for (int i = 0; i < amountToSpawnEXP; i++)
     {
            var exp = expPool.Get();
            float angle = (i * Mathf.PI*2.5f + Random.Range(1.0f, 8.0f)) / amountToSpawnEXP; //randomize the float
         Vector3 newPos = new Vector3(Player.transform.position.x + Mathf.Cos(angle) * radius * 20 + Random.Range(1.0f, 10.0f), Mathf.Sin(angle) * radius * 20 + this.transform.position.y, 0);
            //GameObject ExpDropletFinal = Instantiate(ExpDropletPrefab, newPos, Quaternion.identity);
            exp.transform.position = newPos;
            exp.transform.rotation = Quaternion.identity;
            exp.GetComponent<ExpDroplet>().exp = 10.0f;
         //Debug.Log(newPos);
     }
    }
    /**
     * Returns the current amount of the objects
     */
    public int checkAmount(int amount, string Tag) {
    return amount - GameObject.FindGameObjectsWithTag(Tag).Length;
    }
    /**
     *Experiment, not used 
     */
    public void InitializeSpawnPositions(List<Vector3> spawnPositions)
    {
        spawnPositions.Add(new Vector3(12.5f, 20, 0)); //right up corner
        spawnPositions.Add(new Vector3(12.5f, 0, 0)); //right 
        spawnPositions.Add(new Vector3(0, 20f, 0)); //top
        spawnPositions.Add(new Vector3(12.5f, -20f, 0)); //right down corner
        spawnPositions.Add(new Vector3(-12.5f, 20f, 0)); //left top corner
        spawnPositions.Add(new Vector3(-12.5f, -20f, 0)); //left down corner
        spawnPositions.Add(new Vector3(0, -20f, 0)); //down 
        spawnPositions.Add(new Vector3(-12.5f, 0, 0)); //left 
    }



}


