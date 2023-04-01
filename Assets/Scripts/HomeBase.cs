using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour, IHealthMechanics
{
    float IHealthMechanics.Health { get; set; }

    void IHealthMechanics.OnDeath()
    {
        Console.WriteLine("It Died...");
    }
}
