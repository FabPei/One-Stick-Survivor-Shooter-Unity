using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAttack : MonoBehaviour
{
    [Header("GameObjects")]
    //public GameObject AirAttack_Bullet_Prefab;
    public Camera MainCamera;
    public GameObject player;

    [Header("Variables")]
    public float level;

    private float width;
    protected float Timer = 0;
    private BasicVariables basicVariables;

    public void Init(float AirAttack_level) {
    level = AirAttack_level;
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        basicVariables = this.GetComponent<BasicVariables>();
        //currentHealth = basicVariables.currentHealth;
        //movementSpeed = basicVariables.movementSpeed;
        //maxHealth = basicVariables.maxHealth;
        this.transform.localScale *= basicVariables.size;
        //Debug.Log("Spawned" + AirAttack_Bullet_Number);
        //Camera cam = Camera.main;
        //Debug.Log(Player.transform.position);
        //Debug.Log("AA " + player.transform.position);

    }

    void FixedUpdate()
    {
        Timer += Time.deltaTime;


        if (Timer >= 2)
        {
            Timer = 0f;
            Destroy(this.gameObject);
        }


        //Debug.Log(Tank_level);
    }
    //public void spawnAirAttacks()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    for (int i = 0; i < AirAttack_Bullet_Number; i++)
    //{
    //        //Debug.Log(i);
    //    Debug.Log("AA " + player.transform.position);
    //    _xAxis = UnityEngine.Random.Range(player.transform.position.x - width / 2, player.transform.position.x + width / 2);
    //    _yAxis = UnityEngine.Random.Range(player.transform.position.y - height / 2, player.transform.position.y + height / 2);
    //    _randomPosition = new Vector3(_xAxis, _yAxis, 0f);
    //    //Debug.Log("randomposition" + _randomPosition);
    //    CheckLevel();
    //    GameObject AirAttack_Bullet_Final = Instantiate(AirAttack_Bullet_Prefab, _randomPosition, this.transform.rotation);
    //}
    ////Tank TankPreFab = new Tank(1.0f, 1.0f,1.0f);
    //Destroy(this.gameObject);

    //}

}
