using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Values : MonoBehaviour
{
    public float health;
    public int maxHealth = 100;
    public int TotalScrap;

    private GameObject player;
    private GameObject home_base;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        home_base = GameObject.Find("End");
        health = maxHealth;
        TotalScrap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();
        UNLIMITEDPOWER();
        ScrapHandler();

    }

    public void TakeDamage()
    {
        health = home_base.GetComponent<HomeBase>().Health;

        GameObject.Find("HP Cube").GetComponent<Bar>().Resize((float)health /maxHealth);

    }

    public void UNLIMITEDPOWER()
    {
        float minCharge = player.GetComponent<Telekinesis>().minThrowForce;
        float currCharge = player.GetComponent<Telekinesis>().throwForce;
        float maxCharge = player.GetComponent<Telekinesis>().maxThrowForce;
        currCharge -= minCharge;

        GameObject.Find("Charge Cube").GetComponent<Bar>().Resize(currCharge / maxCharge);
    }


    public void ScrapHandler()
    {
        GameObject.Find("Scrap Cube").GetComponentInChildren<Text>().Change(TotalScrap);
    }
}
