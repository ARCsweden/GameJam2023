// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public Transform goal;
    public bool grabbed = false;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
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
    }

    public void Grab()
    {
        agent.isStopped = true;
        agent.updatePosition = false;
    }

    public void Release()
    {
        agent.ResetPath();
        agent.destination = goal.position;
        agent.updatePosition = true;
        agent.isStopped = false;

    }
}