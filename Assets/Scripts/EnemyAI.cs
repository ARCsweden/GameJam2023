// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public GameObject goal;
    public bool grabbed = false;
    public float distanceLeft;

    private NavMeshAgent agent;

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

        distanceLeft = agent.remainingDistance;

        
        if ((transform.position - goal.transform.position).magnitude < 1)
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
        Destroy(gameObject);
    }
}