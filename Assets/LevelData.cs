using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [Header("Player Settings")]
    public double player_speed;
    public double player_firerate;
    public double player_health;

    [Header("Enemy Settings")]
    public double e1_health;
    public double e2_health;
    public double e3_health;
    public double e4_health;

    public double e1_speed;
    public double e2_speed;
    public double e3_speed;
    public double e4_speed;

    [Header("Item Settings")]
    public int increasedCrateSpawnRate;
    public int drone_damage;
    public int electricbarrier_damage;
    public int electricbarrier_size;


    void awake() {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
