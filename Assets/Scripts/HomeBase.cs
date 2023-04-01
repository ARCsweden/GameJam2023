using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour, IHealthMechanics
{

    [SerializeField]
    float health;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public void DealDamage(float Damage)
    {
        health -= Damage;

        if (health <= 0)
            OnDeath();
    }

    public void OnDeath()
    {
        Console.WriteLine("It Died...");
    }

    private void Start()
    {
        this.health = 100;
    }

    void Update()
    {
        
    }
}
