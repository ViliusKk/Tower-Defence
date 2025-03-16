using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private int targetIndex;
    private bool endPointReached = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (!endPointReached)
        {
            agent.SetDestination(PathScript.instance.waypoints[targetIndex].position);
                    
            var distance = Vector3.Distance(transform.position, PathScript.instance.waypoints[targetIndex].position);

            if (distance < 1.5f)
            {
                targetIndex++;
                if (targetIndex >= PathScript.instance.waypoints.Count)
                {
                    endPointReached = true;
                }
            }
        }
    }
}
