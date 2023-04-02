using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Values : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;

    public int test;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage(test);
        test = 0;
        UNLIMITEDPOWER();

    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        GameObject.Find("HP Cube").GetComponent<Bar>().Resize((float)health /maxHealth);

        if(health <= 0)
        {
            //dead ):
        }
    }

    public void UNLIMITEDPOWER()
    {
        float minCharge = player.GetComponent<Telekinesis>().minThrowForce;
        float currCharge = player.GetComponent<Telekinesis>().throwForce;
        float maxCharge = player.GetComponent<Telekinesis>().maxThrowForce;
        currCharge -= minCharge;

        GameObject.Find("Charge Cube").GetComponent<Bar>().Resize(currCharge / maxCharge);
    }

}
