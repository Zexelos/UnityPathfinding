using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Grid grid;

    Pathfinding pathfinding;
    NavMeshAgent agent;
    List<Vector3> path;
    int currentPathIndex;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pathfinding = new Pathfinding(10, 10);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            path = pathfinding.FindPath(transform.position, player.position);

            if (path != null)
            {
                foreach (var item in path)
                {
                    Debug.Log($"Path: {item.x}, z:{item.z}");
                }
            }
        }

        if (path != null)
        {
            currentPathIndex = 0;
            agent.destination = path[currentPathIndex];

            if (Vector3.Distance(transform.position, agent.destination) < 0.5f && currentPathIndex < path.Count)
            {
                currentPathIndex++;
                agent.destination = path[currentPathIndex];
            }
        }
    }
}
