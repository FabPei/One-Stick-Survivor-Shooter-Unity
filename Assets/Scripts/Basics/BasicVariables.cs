using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicVariables: MonoBehaviour
{
    
    [Header("Basic Variables")]
    public float currentHealth;
    public float maxHealth;
    public float movementSpeed;
    public float size;
    public bool bStunned = false;
    public float damage;

    public void Awake()
    {
        currentHealth = maxHealth;
    }
}
