// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public GameObject goal;
    public bool grabbed = false;

    private NavMeshAgent agent;
    private bool wasReleased = false;

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
        }

        
        if ((transform.position - goal.transform.position).magnitude < 1)
            ReachedGoal();

    }

    public void Grab()
    {
        agent.isStopped = true;
        agent.updatePosition = false;
        Debug.Log("Grabbed");
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
        Destroy(gameObject);
    }

}