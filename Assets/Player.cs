using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    public delegate void Event_Player();
    public static event Event_Player OnTriggerEnter_Crate;
    public static event Event_Player OnTriggerEnter_Enemy;
    public static event Event_Player OnTriggerEnter_Exp;


    // Start is called before the first frame update
    public float moveSpeed = 3f; //Movementspeed of player
    public double DelayAmount = 1.0; //Shootingspeed basicFiring
    public int PlayerSize = 1; //Playersize

    public Weapon weapon;
    private PlayerInput playerInput;

    [Header("GameObjects")]
    public GameObject EnemyPrefab;
    public GameObject Crate;
    
    public GameObject PowerupController;
    public GameObject Background_Powerup;
    public GameObject EventManager;
    public Expprogressbar bar;
    protected float Timer;
    public GameObject[] BackgroundTilePrefabs;

    public Animator animator;

    

    [Header("Crate Boni")]

    public Rigidbody2D rb;
    Vector2 movement;

    [Header("DirectionTracking")]
    Vector2 VnewLocation;
    public GameObject inputController;

    [Header("SpriteRender")]
    public SpriteRenderer sr;
    public Sprite sprite_back;
    public Sprite sprite_front;
    public float DelayAmountSpriteChange = 0.4f;
    protected float TimerSpriteChange = 0.0f;

    void OnEnable()
    {
        //do
       
    }
    void OnAwake()
    {

    }
    void Start()
    {
        //Player.OnTriggerEnter_Crate += FindClosestEnemy; think that was a test
        //OnTriggerEnter_Crate();
       //Debug.Log("Screen Width: " + Screen.width);

       //this.transform.position = new Vector3(Screen.width,Screen.height, 0);
       //createEnemys();

        sr = gameObject.GetComponent<SpriteRenderer>();

        BackgroundTilePrefabs = GameObject.FindGameObjectsWithTag("BackgroundTile");
      
       playerInput = GetComponent<PlayerInput>();
        animator = this.GetComponent<Animator>();

        //bar = GameObject.FindGameObjectWithTag("ExpProgressBar");
        //dronePositions.Clear();

        //This is for direction:
        inputController = GameObject.Find("InputController");
    }

    // Update is called once per frame
    void Update()
    {

        TimerSpriteChange += Time.deltaTime;

        if (TimerSpriteChange >= DelayAmountSpriteChange)
        {
            //TimerSpriteChange = 0f;
            if (weapon.transform.localRotation.eulerAngles.z <= 90.0f && weapon.transform.localRotation.eulerAngles.z >= 0.0f)
            {
                //Debug.Log("TR");
                //sr.flipX = false;
                sr.flipX = false;
                //weapon.GetComponent<SpriteRenderer>().flipX = false;
                weapon.transform.position = this.transform.TransformPoint(new Vector2(-0.112f, 0.112f));
                //weapon.transform.position = new Vector3(0.1f, this.transform.position.y, 0);
                sr.sprite = sprite_back;
                weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
                //weapon.GetComponent<SpriteRenderer>().flipX = false;
                weapon.GetComponent<SpriteRenderer>().flipY = false;
            }
            else if (weapon.transform.localRotation.eulerAngles.z <= 180.0f && weapon.transform.localRotation.eulerAngles.z >= 90.0f)
            {
                //Debug.Log("TL");
                //sr.flipX = true;
                sr.flipX = true;
                weapon.transform.position = this.transform.TransformPoint(new Vector2(0.112f, 0.112f));
                //weapon.transform.position = new Vector3(-0.1f, this.transform.position.y, 0);
                //weapon.GetComponent<SpriteRenderer>().flipX = true;
                sr.sprite = sprite_back;
                weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
                weapon.GetComponent<SpriteRenderer>().flipX = false;
                weapon.GetComponent<SpriteRenderer>().flipY = true;
            }
            else if (weapon.transform.localRotation.eulerAngles.z <= 270.0f && weapon.transform.localRotation.eulerAngles.z >= 180.0f)
            {
                //Debug.Log("DL");
                sr.flipX = true;
                //weapon.GetComponent<SpriteRenderer>().flipX = false;
                weapon.transform.position = this.transform.TransformPoint(new Vector2(0.112f, 0.112f));
                //weapon.transform.position = new Vector3(-0.1f, this.transform.position.y, 0);
                sr.sprite = sprite_front;
                weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
                weapon.GetComponent<SpriteRenderer>().flipX = false;
                weapon.GetComponent<SpriteRenderer>().flipY = true;
            }
            else if (weapon.transform.localRotation.eulerAngles.z <= 360.0f && weapon.transform.localRotation.eulerAngles.z >= 270.0f)
            {
                //Debug.Log("DR");
                sr.flipX = false;
                weapon.transform.position = this.transform.TransformPoint(new Vector2(-0.112f, 0.112f));
                //weapon.transform.position = new Vector3(0.1f, this.transform.position.y, 0);
                //weapon.GetComponent<SpriteRenderer>().flipX = true;
                sr.sprite = sprite_front;
                weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
                weapon.GetComponent<SpriteRenderer>().flipY = false;
                //weapon.GetComponent<SpriteRenderer>().flipX = false;

            }

            TimerSpriteChange = 0;
        }


        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            basicFiring();


        }
        //if (weapon.transform.localRotation.eulerAngles.z <= 90.0f && weapon.transform.localRotation.eulerAngles.z >= 0.0f)
        //{
        //    //Debug.Log("TR");
        //    //sr.flipX = false;
        //    sr.flipX = false;
        //    //weapon.GetComponent<SpriteRenderer>().flipX = false;
        //    weapon.transform.position = this.transform.position + this.transform.TransformDirection(new Vector2(0.5f, 0));
        //    sr.sprite = sprite_back;
        //    weapon.GetComponent<SpriteRenderer>().sortingOrder = -1;
        //}
        //else if (weapon.transform.localRotation.eulerAngles.z <= 180.0f && weapon.transform.localRotation.eulerAngles.z >= 90.0f)
        //{
        //    //Debug.Log("TL");
        //    //sr.flipX = true;
        //    sr.flipX = true;
        //    weapon.transform.position = this.transform.position + this.transform.TransformDirection(new Vector2(-0.5f, 0));
        //    //weapon.GetComponent<SpriteRenderer>().flipX = true;
        //    sr.sprite = sprite_back;
        //    weapon.GetComponent<SpriteRenderer>().sortingOrder = -1;
        //}
        //else if (weapon.transform.localRotation.eulerAngles.z <= 270.0f && weapon.transform.localRotation.eulerAngles.z >= 180.0f)
        //{
        //    //Debug.Log("DL");
        //    sr.flipX = true;
        //    //weapon.GetComponent<SpriteRenderer>().flipX = false;
        //    weapon.transform.position = this.transform.position + this.transform.TransformDirection(new Vector2(-0.5f, 0));
        //    sr.sprite = sprite_front;
        //    weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //}
        //else if (weapon.transform.localRotation.eulerAngles.z <= 360.0f && weapon.transform.localRotation.eulerAngles.z >= 270.0f)
        //{
        //    //Debug.Log("DR");
        //    sr.flipX = false;
        //    weapon.transform.position = this.transform.position + this.transform.TransformDirection(new Vector2(0.5f, 0));
        //    //weapon.GetComponent<SpriteRenderer>().flipX = true;
        //    sr.sprite = sprite_front;
        //    weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;

        //}
        //FindClosestEnemy();

        
        VnewLocation = inputController.GetComponent<JoystickInput>().moveDirection;
        if (VnewLocation.x == 0.0f && VnewLocation.y == 0.0f) {
            //Debug.Log(VnewLocation);
            animator.SetBool("IsMoving", false);
        } else
        {
            //Debug.Log(VnewLocation);
            animator.SetBool("IsMoving", true);
        }
        //Debug.Log("VnewLocation: " + VnewLocation);
        //Debug.Log(weapon.transform.localRotation.eulerAngles.z);

        

        //if (Mathf.Sign(VnewLocation.x) == 1 && Mathf.Sign(VnewLocation.y) == 1 && VnewLocation.x != 0.0f && VnewLocation.y != 0.0f)
        //{
        //    //Debug.Log("TR");
        //    //sr.flipX = false;
        //    sr.flipX = false;
        //    weapon.GetComponent<SpriteRenderer>().flipX = false;
        //    weapon.transform.position = this.transform.position + this.transform.TransformDirection(new Vector2(1, 0));
        //    sr.sprite = sprite_back;
        //} else if (Mathf.Sign(VnewLocation.x) == -1 && Mathf.Sign(VnewLocation.y) == -1 && VnewLocation.x != 0.0f && VnewLocation.y != 0.0f)
        //{
        //    //Debug.Log("DL");
        //    sr.flipX = true;
        //    weapon.transform.position = this.transform.position + this.transform.TransformDirection(new Vector2(-1,0));
        //    weapon.GetComponent<SpriteRenderer>().flipX = true;
        //    sr.sprite = sprite_front;
        //} else if (Mathf.Sign(VnewLocation.x) == -1 && Mathf.Sign(VnewLocation.y) == 1 && VnewLocation.x != 0.0f && VnewLocation.y != 0.0f)
        //{
        //    //Debug.Log("TL");
        //    //sr.flipX = true;
        //    sr.flipX = true;
        //    weapon.transform.position = this.transform.position + this.transform.TransformDirection(new Vector2(-1, 0));
        //    weapon.GetComponent<SpriteRenderer>().flipX = true;
        //    sr.sprite = sprite_back;
        //} else if (Mathf.Sign(VnewLocation.x) == 1 && Mathf.Sign(VnewLocation.y) == -1 && VnewLocation.x != 0.0f && VnewLocation.y != 0.0f)
        //{
        //    //Debug.Log("DR");
        //    sr.flipX = false;
        //    weapon.GetComponent<SpriteRenderer>().flipX = false;
        //    weapon.transform.position = this.transform.position + this.transform.TransformDirection(new Vector2(1, 0));
        //    sr.sprite = sprite_front;

        //}




         
    }
    //void Update() {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        //Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        ////Debug.Log(input);
        //Vector3 moveDirectionJ = new Vector3(input.x * moveSpeed, input.y * moveSpeed, 0).normalized;
        //rb.velocity = new Vector2(moveDirectionJ.x * moveSpeed, moveDirectionJ.y * moveSpeed);


        //rb.velocity = new Vector2(input.x * moveSpeed, input.y * moveSpeed);
        
        //Vector3 moveDirection = new Vector3(movement.x,  movement.y, 0).normalized;

        //rb.velocity = new Vector2(moveDirection.x * moveSpeed,moveDirection.y * moveSpeed);


    //}



 	public void FindClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;
		Enemy closestEnemy = null;
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

		foreach (Enemy currentEnemy in allEnemies) {
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}

		Debug.DrawLine (this.transform.position, closestEnemy.transform.position);
       //transform.LookAt(closestEnemy.transform.position);
       //FirePoint.transform.right = closestEnemy.transform.position - FirePoint.transform.position;
       transform.right = closestEnemy.transform.position - transform.position;
	}

    public void basicFiring() {
                weapon.Fire();
            
    }
    public void createEnemys(){
        GameObject Enemy = Instantiate(EnemyPrefab, this.transform.position + new Vector3(this.transform.position.x + 5,this.transform.position.y + 5, 0), this.transform.rotation);
        GameObject Enemy2 = Instantiate(EnemyPrefab, this.transform.position + new Vector3(11,11, 0), this.transform.rotation);
        GameObject Enemy3 = Instantiate(EnemyPrefab, this.transform.position + new Vector3(12,12, 0), this.transform.rotation);
        GameObject Enemy4 = Instantiate(EnemyPrefab, this.transform.position + new Vector3(Screen.width,12, 0), this.transform.rotation);
        GameObject Enemy5 = Instantiate(EnemyPrefab, new Vector3(5,11, 0), this.transform.rotation);
        //Debug.Log(Screen.width + " " + Screen.height);   
        Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0.5f, 10.0f));
        //Debug.Log(v3Pos); 
        GameObject Enemy6 = Instantiate(EnemyPrefab, v3Pos, this.transform.rotation);
        var cubeRenderer = Enemy6.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.blue);

    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.tag)
        {
            case "Item":
                //DelayAmount = DelayAmount * 0.50;
                Destroy(col.gameObject);
                //spawnDrone(dronePositions);
                if (OnTriggerEnter_Crate != null) {
                //Debug.Log("Triggered");
                OnTriggerEnter_Crate();
                }
                //Debug.Log("Test");
                //PowerupController.GetComponent<PowerupController>().PowerupMethod();
                break;
            case "Enemy":

                break;

            case "Exp":
                
                bar.UpdateProgress_new(col.gameObject.GetComponent<ExpDroplet>().exp, 0.4f);
                Destroy(col.gameObject);
                break;

        }
    }



}

