using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public int charge;
    public int maxCharge;
    public int perCharge = 10;
    int chargeFraction;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        charge = 100;
    }

    // Update is called once per frame
    void Update()
    {
        chargeFraction++;

        if (chargeFraction >= perCharge && charge < maxCharge)
        {
            charge++;
            chargeFraction = 0;
        }

        if(charge > maxCharge)
        {
            charge = maxCharge;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            //dead ):
        }
    }

    public void UseCharge(int amount)
    {
        charge -= amount;
    }
}
