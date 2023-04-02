using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;

    public int test;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage(test);
        test = 0;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        GameObject.Find("HP Cube").GetComponent<Bar>().Rezise((float)health /maxHealth);

        if(health <= 0)
        {
            //dead ):
        }
    }

}
