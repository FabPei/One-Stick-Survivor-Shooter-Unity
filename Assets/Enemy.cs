using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour {


	//public static event Event_Enemy OnTriggerEnter_Enemy;
	//public static event Event_Enemy OnTriggerEnter_Exp;

	public Transform Player;
	public float movementSpeed;
	public float step;

	//public float currentHealth = 2f;
	//public float maxHealth = 3f;
	public Rigidbody2D rb;
	public bool bStunned = false;
	public BasicVariables basicVariables;
    public DamagePopupSpawner dps;
    public PointsAwarder pa;
    public ExpDropSpawner eds;

	public PoolingController pc;
    // Use this for initialization

    private void OnEnable()
    {
 
    }
    private void OnDisable()
    {
        
    }
    void Start () {

		GameObject GOPlayer = GameObject.Find("Player");
		Player = GOPlayer.transform;
		pc = pc.GetComponent<PoolingController>();
		//basicVariables = this.GetComponent<BasicVariables>();
		//dps = this.GetComponent<DamagePopupSpawner>();
		//pa = this.GetComponent<PointsAwarder>();
		//eds = this.GetComponent<ExpDropSpawner>();
		//currentHealth = basicVariables.currentHealth;
		//movementSpeed = basicVariables.movementSpeed;
		// = basicVariables.maxHealth;
		this.transform.localScale *= basicVariables.size;
	}
	

	// Update is called once per frame
	void Update () {
		
		if (basicVariables.bStunned)
		{
			this.transform.position = this.transform.position;
			
		}
		else
		{
			step = basicVariables.movementSpeed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, Player.position, step);

		}

		if (basicVariables.currentHealth <= 0.0f)
		{
			
			dps.spawnPopup();
			pa.AddPoint();
			eds.spawnExpDroplet(basicVariables.maxHealth * 3);

			//pc.enemyPool.Release(this);

            gameObject.SetActive(false);
			//Destroy(gameObject);
		}
	}

	    

        //bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * fireForce, ForceMode2D.Impulse); ->https://gamedev.stackexchange.com/questions/113178/when-should-i-use-velocity-versus-addforce-when-dealing-with-player-objects

}
