using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class PowerupController : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject EnemyPrefab;
    public GameObject Crate;
    public GameObject DronePrefab;
    public ElectricBarrier ElectricBarrierPreFab;
    public Tank TankPrefab;
    public WiredTrap WiredTrap_Prefab;
    public GameObject PlayerGO;
    public AirAttack AirAttack_Prefab;
    public Camera MainCamera;
    public GameObject Background_Powerup;
    public CircleThing CircleThing_Prefab;
    public SwarmRocket SwarmRocket_Prefab;
    public Weapon weapon;
    public Rocket Rocket_Prefab;
    public Grenade Grenade_Prefab;

    public GameObject rfp;

    /**
     * These booleans track whether one ability was activated
     */
    [Header("Powerup Booleans")]
    public bool bTank = false;
    public bool bElectricBarrier = false;
    public bool bWiredTrap = false;
    public bool bAirAttack = false;
    public bool bDrone = false;
    public bool bCircleThing = false;
    public bool bRiochet = false;
    public bool bSwarmRocket = false;
    public bool bRocket = false;
    public bool bGrenade = false;
    //public bool Tank = false;
    //public bool Tank = false;

    [Header("Powerup levels")]
    public int lvl_Tank = 0;
    public int lvl_AirAttack = 0;
    public int lvl_ElectricBarrier = 0;
    public int lvl_WiredTrap = 0;
    public int lvl_SwarmRocket = 0;
    public int lvl_Rocket = 0;
    public int lvl_Grenade = 0;

    [Header("Powerup position")]
    public Vector3 Tank_Vector3 = new Vector3(30f,15f,1f);
    public List<Vector3> dronePositions;
    public List<Vector3> circlethingPositions;

    [Header("Powerup sizes")]
    public float Tank_size = 1.0f;
    public float AirAttack_size = 1.0f;
    public float WiredTrap_size = 1.0f;
    public float ElectricBarrier_size = 1.0f;

    [Header("Powerup damage")]
    public float Tank_damage = 1;
    public float AirAttack_damage = 1;
    public float WiredTrap_damage = 1;
    public float ElectricBarrier_damage = 0.1f;

    [Header("Powerups")]
    protected float Timer;
    private  float _xAxis;
     private  float _yAxis;
     private Vector3 _randomPosition;
     private float height;
     private float width;
    public int AirAttack_Bullet_Number = 2;
    // Start is called before the first frame update

    public Enemy[] currentTargetedEnemies;

    public int amountOfDrones = 1;
    public int currentAmountOfDrones = 0;

    public int amountOfCircleThings = 1;
    public int currentAmountOfCircleThings = 0;
    public float timer;

    public float amountSwarmRocket = 5;

    public float amountRocket = 1;

    public float amountGrenade = 2;

    [Header("Cooldowns")]
    public double Tank_cd = 5.0; //cooldown tank
    public double Tank_cd_Last; //cooldown tank

    //public double ElectricBarrier_cd = 5.0; //cooldown 
   // public double ElectricBarrier_cd_Last; //cooldown 

    public double WiredTrap_cd = 5.0; //cooldown WT
    public double WiredTrap_cd_Last; //cooldown 

    public double AirAttack_cd = 5.0; //cooldown AA
    public double AirAttack_cd_Last; //cooldown 

    public double SwarmRocket_cd = 5.0; //cooldown AA
    public double SwarmRocket_cd_Last; //cooldown 

    public double Rocket_cd = 5.0; //cooldown AA
    public double Rocket_cd_Last; //cooldown 


    public double Grenade_cd = 5.0; //cooldown AA
    public double Grenade_cd_Last; //cooldown 
    //public double Tank_cd = 5.0; //cooldown 
    //public double Tank_cd_Last; //cooldown 
    void OnEnable()
    {
        Expprogressbar.OnTarget += showAndChange;
        Player.OnTriggerEnter_Crate += showAndChange;
        //ClickEction.OnTriggerEnterCrate += showAndChange;
    }

    void OnDisable()
    {
        Expprogressbar.OnTarget -= showAndChange;
        Player.OnTriggerEnter_Crate += showAndChange;

    }
    void Start()
    {
        //Background_Powerup = GameObject.Find("Background_Powerup");
        height = 2f * MainCamera.orthographicSize;
        width = height * MainCamera.aspect;
        //InvokeRepeating("creatingAbilities", 5.0f, 5.0f);
        InitializeDronePositions(dronePositions);
        InitializeCircleThingPositions(circlethingPositions);

        rfp = GameObject.Find("RocketFirePoint");
        //weapon = GameObject.Find("Weapon");
        //amountOfDrones = 1;
        //Debug.Log("amountOfDrones " + amountOfDrones);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        //Debug.Log(Tank_level);
        creatingAbilities();


    }
    public void showAndChange()
    {
       // Debug.Log("showAndChange starts");
        Background_Powerup.SetActive(true);
        //Debug.Log("showAndChange starts2");
        Background_Powerup.GetComponent<PowerupUIController>().changePUUI();
    }

    private void creatingAbilities()
    {
        if (bTank)
        {
            if (timer >= Tank_cd_Last) { 
            spawnTankAttack(lvl_Tank);
            Tank_cd_Last = timer + Tank_cd;
            }
        }
        if (bElectricBarrier)
        {
            createElectricBarrier(lvl_ElectricBarrier);
            bElectricBarrier = false;
        }
        if (bWiredTrap)
        {
            if (timer >= WiredTrap_cd_Last) { 
            spawnWiredTraps(lvl_WiredTrap);
            WiredTrap_cd_Last = timer + WiredTrap_cd;
            }
        }
        if (bAirAttack)
        {
            if (timer >= AirAttack_cd_Last) {
            spawnAirAttack(lvl_AirAttack);
            AirAttack_cd_Last = timer + AirAttack_cd;
            }
        }
        if (bSwarmRocket)
        {
            if (timer >= SwarmRocket_cd_Last)
            {
                spawnSwarmRocket(lvl_SwarmRocket);
                SwarmRocket_cd_Last = timer + SwarmRocket_cd;
            }
        }
        if (bRocket)
        {
            if (timer >= Rocket_cd_Last)
            {
                spawnRocket(lvl_Rocket);
                Rocket_cd_Last = timer + Rocket_cd;
               // Debug.Log("SpawnRocket");
            }
        }
        if (bGrenade)
        {
            if (timer >= Grenade_cd_Last)
            {
                spawnGrenade(lvl_Grenade);
                Grenade_cd_Last = timer + Grenade_cd;
                // Debug.Log("SpawnRocket");
            }
        }
        if (bDrone)
        {
            //Debug.Log("Drone true");           
            if (amountOfDrones > currentAmountOfDrones)
            {
                //Debug.Log("spawn drone");
                spawnDrone(dronePositions);
            }                    
        }
        if (bCircleThing)
        {           
            if (amountOfCircleThings > currentAmountOfCircleThings)
            {

                spawnCircleThings(circlethingPositions);
                //Debug.Log("bCircleThing true");
            }
        }
    }
    /**
    Spawns a tank driving across the screen above the player damaging/moving alle enemies in its path
    */
    public void spawnTankAttack(int levelTA){
        //Tank TankPreFab = new Tank(1.0f, 1.0f,1.0f);
        TankPrefab.GetComponent<BasicVariables>().size = Tank_size;
        Tank TankFinal = Instantiate(TankPrefab, PlayerGO.transform.position + PlayerGO.transform.TransformDirection(Tank_Vector3), PlayerGO.transform.rotation); 
        TankFinal.Init(1.0f, 1.0f,1.0f);
    }
    public void Upgrade_Tank(){
        //Tank TankPreFab = new Tank(1.0f, 1.0f,1.0f);
        lvl_Tank = lvl_Tank + 1;

    }

    /**
    Method shoots three rockets on the ground, collided should be squares
    */
    public void spawnAirAttack(int lvl_AirAttack = 0){
        AirAttack_Prefab.GetComponent<BasicVariables>().size = AirAttack_size;
        for (int i = 0; i < AirAttack_Bullet_Number; i++) { 
            _xAxis = UnityEngine.Random.Range(PlayerGO.transform.position.x - width / 2, PlayerGO.transform.position.x + width / 2);
            _yAxis = UnityEngine.Random.Range(PlayerGO.transform.position.y - height / 2, PlayerGO.transform.position.y + height / 2);
            _randomPosition = new Vector3(_xAxis, _yAxis, 0f);
//AirAttackFinal = null;
            AirAttack AirAttackFinal = Instantiate(AirAttack_Prefab, _randomPosition, Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(0f, 360f)));
//AirAttackFinal = null;
        }
    }
    public void Upgrade_AirAttack(){
        //Tank TankPreFab = new Tank(1.0f, 1.0f,1.0f);
        lvl_AirAttack = lvl_AirAttack + 1;

    }
    /**This Method should open the upgrade window

    */
    public void PowerupMethod() {
        //Upgrade_Tank();
        lvl_Tank = lvl_Tank + 1;
        Upgrade_AirAttack();
        createElectricBarrier(1);
    }
    
    public void createElectricBarrier(int lvl_ElectricBarrier){
        ElectricBarrier ElectricBarrierFinal = Instantiate(ElectricBarrierPreFab, this.transform.position, this.transform.rotation);

    }
        /**
    shoots a single projectile across the screen damaging every enemy in the way
    */
    public void spawnSniperAttack(){

    }

    
    /**
    Shoots a flash/thunder like querschläger hitting enemys behind the first enemy 
    */
    public void spawnRiochet(int levelTA){

    }

    /**
    Creates Wired traps which stuns surrounding enemyes
    */
    public void spawnWiredTraps(int lvl_WiredTrap){
        _xAxis = UnityEngine.Random.Range(PlayerGO.transform.position.x - width/2, PlayerGO.transform.position.x + width/2);
        _yAxis = UnityEngine.Random.Range(PlayerGO.transform.position.y - height/2, PlayerGO.transform.position.y + height/2);
        _randomPosition = new Vector3(_xAxis, _yAxis, 0f );
        WiredTrap WiredTrapFinal = Instantiate(WiredTrap_Prefab, _randomPosition, Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(0f, 360f)));
    }

    /**
    Calls for sniper assistance which causes random enemies taking damage
    */
    public void spawnSniperAssistance(int leveWT) {

    }
    /**
    Creates a Drone which shoots a shot with its railgun (railgun pierces all enemies)
    */
    public void spawnRailgunDrone(int levelRD){

    }
    /**
    Creates a friendly soldier fighting along side the player, miroring all player's abilities with lvl 1(x)
    */
    public void spawnSoldier(int levelS){

    }

    public void InitializeDronePositions(List<Vector3> dronePositions)
    {

        dronePositions.Add(new Vector3(1, 1, 0)); //right up corner
        dronePositions.Add(new Vector3(1.25f, 0, 0)); //right 
        dronePositions.Add(new Vector3(0, 1.25f, 0)); //top
        dronePositions.Add(new Vector3(1, -1, 0)); //right down corner
        dronePositions.Add(new Vector3(-1, 1, 0)); //left top corner
        dronePositions.Add(new Vector3(-1, -1, 0)); //left down corner
        dronePositions.Add(new Vector3(0, -1.25f, 0)); //down 
        dronePositions.Add(new Vector3(-1.25f, 0, 0)); //left 
    }

    public void spawnDrone(List<Vector3> dronePositions)
    {
        
        GameObject Drone = Instantiate(DronePrefab, dronePositions[amountOfDrones], this.transform.rotation);
        currentAmountOfDrones = currentAmountOfDrones + 1;

        //(dronePositions[amountOfDrones])
    }

    public void InitializeCircleThingPositions(List<Vector3> circlethingPositions)
    {

        circlethingPositions.Add(new Vector3(3, 3, 0)); //right up corner
        circlethingPositions.Add(new Vector3(-3, -3, 0)); //left down corner 
        circlethingPositions.Add(new Vector3(3, -3, 0)); //down
        circlethingPositions.Add(new Vector3(-3, 3, 0)); //left up


    }

    public void spawnCircleThings(List<Vector3> circlethingPositions)
    {

        CircleThing ct = Instantiate(CircleThing_Prefab, circlethingPositions[amountOfCircleThings], this.transform.rotation);
        GameObject playerFollower = GameObject.Find("PlayerFollower");
        ct.transform.parent = playerFollower.transform;
        currentAmountOfCircleThings = currentAmountOfCircleThings + 1;

        //(dronePositions[amountOfDrones])
    }

    /**
    * Spawns a rocket
    */
    public void spawnGrenade(int lvl)
    {
       
        //rocket.GetComponent<Rigidbody2D>().AddForce(weapon.transform.right * 50f, ForceMode2D.Force);

        for (int i = 0; i < amountGrenade; i++)
        {

            Vector3 targetDestination = InstantiateAtRandomAngle(PlayerGO.transform.position);

            Grenade grenade = Instantiate(Grenade_Prefab, PlayerGO.transform.position, weapon.transform.rotation);

            grenade.GetComponent<Grenade>().targetDestination = targetDestination;

            grenade.GetComponent<Rigidbody2D>().AddForce(targetDestination * 10 * Time.deltaTime, ForceMode2D.Impulse);

           
        }
    }

    //returns a Vec3 from a random angle from the original position (given as parameter)
    public Vector3 InstantiateAtRandomAngle(Vector3 position)
    {
        // Generate a random angle in degrees between 0 and 360
        float angle = UnityEngine.Random.Range(0f, 360f);

        // Convert the angle to radians
        float angleInRadians = angle * Mathf.Deg2Rad;

        // Use the angle to create a new Vector3 for the rotation
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        // Calculate the position 50 units away from the original position, using the angle
        Vector3 newPosition = position + new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0f) * 50f;

        // Finally, instantiate the object at the new position, with the random rotation
        //Instantiate(prefab, newPosition, rotation);
        return newPosition;
    }

    /**
     * Spawns a rocket
     */
    public void spawnRocket(int lvl)
    {
        Rocket rocket = Instantiate(Rocket_Prefab, weapon.transform.position, weapon.transform.rotation);
        //rocket.GetComponent<Rigidbody2D>().AddForce(weapon.transform.right * 50f, ForceMode2D.Force);
    }

    /**
 * Spanws a rocket swarm
 */
    public void spawnSwarmRocket(double lvl_SwarmRocket)
    {
        //CircleThing ct = Instantiate(CircleThing_Prefab, circlethingPositions[amountOfCircleThings], this.transform.rotation);
        //Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        //allEnemies = allEnemies.OrderBy((d) => (d.transform.position - rfp.transform.position).sqrMagnitude).ToArray();
        //initializeRocketEnemies(amountSwarmRocket);
        //Debug.Log(currentTargetedEnemies.Length);
        StartCoroutine(swarmRocketDelay());
        //for (int i = 0; i < amountSwarmRocket; i++)
        //{
        //    SwarmRocket SwarmRocketObject = Instantiate(SwarmRocket_Prefab, rfp.transform.position - new Vector3(1.0f, 2.5f,0.0f), PlayerGO.transform.rotation);
        //    SwarmRocketObject.closestEnemy = allEnemies[i];
        //    rocketDelay();


        //}
        //allEnemies = new Enemy[0];

    }

    IEnumerator swarmRocketDelay()
    {

        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        allEnemies = allEnemies.OrderBy((d) => (d.transform.position - rfp.transform.position).sqrMagnitude).ToArray();
        for (int i = 0; i < amountSwarmRocket; i++)
        {
            SwarmRocket SwarmRocketObject = Instantiate(SwarmRocket_Prefab, rfp.transform.position - new Vector3(1.0f, 2.5f, 0.0f), PlayerGO.transform.rotation);
            SwarmRocketObject.closestEnemy = allEnemies[i];
            yield return new WaitForSeconds(0.1f);


        }
        allEnemies = new Enemy[0];

    }


    public void initializeRocketEnemies(float amountSwarmRocket)
    {
        //currentTargetedEnemies

        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        int size = (int)Math.Ceiling(amountSwarmRocket);
        currentTargetedEnemies = new Enemy[size];
        //Debug.Log("Initialize: " + currentTargetedEnemies.Length);

        allEnemies = allEnemies.OrderBy((d) => (d.transform.position - transform.position).sqrMagnitude).ToArray();
        //foreach (Enemy currentEnemy in allEnemies)
        //{


            //for (int i = 0; i < currentTargetedEnemies.Length; i++)
            //{
            //    if (currentTargetedEnemies[i] == currentEnemy)
            //    {
            //        Debug.Log("Same Enemy");
            //        break;
            //    }
            //    if (currentTargetedEnemies[i] == null)
            //    {
            //        Debug.Log("Element is null");
            //        currentTargetedEnemies[i] = currentEnemy;
            //        break;
            //    }

            //    //if (currentTargetedEnemies[i] == currentTargetedEnemies[i])
            //    //{
            //    //    continue;
            //    //}

            //    float distanceToEnemy = (currentEnemy.transform.position - rfp.transform.position).sqrMagnitude;
            //    float ListItemDistance = (currentTargetedEnemies[i].transform.position - rfp.transform.position).sqrMagnitude;

            //    if (distanceToEnemy > ListItemDistance) //
            //    {


            //        //distanceToClosestEnemy = distanceToEnemy;
            //        // closestEnemy = currentEnemy;

            //    } else
            //    {
            //        currentTargetedEnemies[i] = currentEnemy;
            //        break;
            //    }
            //}
        //}
        //Debug.Log("End: " + currentTargetedEnemies.Length);

        //Debug.DrawLine(this.transform.position, closestEnemy.transform.position, Color.grey);
        //transform.LookAt(closestEnemy.transform.position);
        //FirePoint.transform.right = closestEnemy.transform.position - FirePoint.transform.position;
        //transform.right = closestEnemy.transform.position - transform.position;

    }
}
