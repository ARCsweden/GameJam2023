using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthMechanics
{
    protected float Health { get; set; }

    protected void SetHealth(float Health)
    {
        this.Health = Health;
    }

    float GetHealth()
    {
        return Health;
    }

    void DealDamage(float Damage)
    {
        Health -= Damage;

        if (Health <= 0)
            OnDeath();
    }

    void OnDeath();
}
