using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public List<Transform> waypoints;
    
    public static PathScript instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void OnDrawGizmos()
    {
        if (waypoints.Count < 2) return;
        
        Gizmos.color = Color.yellow;
        for (int i = 0; i < waypoints.Count-1; i++)
        {
            if (waypoints[i] != null && waypoints[i + 1] != null)
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }
    }
}
