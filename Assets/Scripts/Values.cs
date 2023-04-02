using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Values : MonoBehaviour
{
    public float health;
    public int maxHealth = 100;
    public int TotalScrap;
    public int wave;
    public int TotalEnemies;

    private GameObject player;
    private GameObject home_base;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        home_base = GameObject.Find("End");
        health = maxHealth;
        TotalScrap = 0;
        TotalEnemies = 0;
        wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();
        UNLIMITEDPOWER();
        ScrapHandler();
        updateNumEnemies();
        updateWave();


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

    public void updateNumEnemies()
    {
        TotalEnemies = GameObject.Find("Enemies").transform.childCount;
        GameObject.Find("Enemy Cube").GetComponentInChildren<Text>().Change(TotalEnemies);
    }

    public void updateWave()
    {
        //Update wave
        GameObject.Find("Wave Cube").GetComponentInChildren<Text>().Change(wave);
    }
}
