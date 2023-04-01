using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, IHealthMechanics
{

    public GameObject goal;
    public bool grabbed = false;

    private NavMeshAgent agent;

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
    }

    private void Update()
    {
        if (grabbed)
        {
            agent.Warp(transform.position);
            if (agent.isStopped == false)
                Grab();
        }
        else
        {
            if (agent.isStopped == true)
                Release();
        }

        
        if ((transform.position - goal.transform.position).magnitude < 1.5)
            ReachedGoal();

    }

    public void Grab()
    {
        agent.isStopped = true;
        agent.updatePosition = false;
    }

    public void Release()
    {
        agent.ResetPath();
        agent.destination = goal.transform.position;
        agent.updatePosition = true;
        agent.isStopped = false;
    }

    private void ReachedGoal()
    {
        goal.SendMessage("DealDamage", 10);
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
        Console.WriteLine("It Died...");
    }
}