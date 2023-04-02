using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, IHealthMechanics
{

    private GameObject player;

    public GameObject goal;
    float Damage = 1;
    public bool grabbed = false;

    private NavMeshAgent agent;
    private bool wasReleased = false;

    [SerializeField]
    float health;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (grabbed)
        {
            agent.Warp(transform.position);
        }

        
        if ((transform.position - goal.transform.position).magnitude < 1.5)
            ReachedGoal();

    }

    public void Grab()
    {
        //agent.isStopped = true;
        agent.updatePosition = false;
        agent.enabled = false;
        grabbed = true;
    }

    public void Release()
    {
        
        wasReleased = true;
    }

    void OnCollisionEnter(Collision collision){
        if(wasReleased && collision.gameObject.tag == "Ground"){
            wasReleased = false;
            agent.enabled = true;
            agent.ResetPath();
            agent.destination = goal.transform.position;
            agent.updatePosition = true;
            agent.isStopped = false;
            grabbed = false;
        }
    }

    private void ReachedGoal()
    {
        goal.SendMessage("DealDamage", Damage);
        Destroy(gameObject);
    }

    public void DealDamage(float Damage)
    {
        health -= Damage;

        if (health <= 0)
            OnDeath();
    }

    public void OnDeath()
    {
        player.GetComponent<Values>().TotalScrap += 50;
        Destroy(gameObject);
    }
}