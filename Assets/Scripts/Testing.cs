using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    Pathfinding pathfinding;

    void Start()
    {
        pathfinding = new Pathfinding(10, 10);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, 0f);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 clickPosition = ray.GetPoint(distance);

                pathfinding.GetGrid().GetXZ(clickPosition, out int x, out int z);

                List<PathNode> path = pathfinding.FindPath(0, 0, x, z);

                if (path != null)
                {
                    for (int i = 0; i < path.Count - 1; i++)
                        Debug.DrawLine(new Vector3(path[i].x, 0, path[i].z) * 10f + new Vector3(1, 0 , 1) * 5f, new Vector3(path[i + 1].x, 0, path[i + 1].z) * 10f + new Vector3(1, 0, 1) * 5f, Color.green, 100f);

                    for (int i = 0; i < path.Count; i++)
                        Debug.Log($"{path[i].x},{path[i].z}");
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Plane plane = new Plane(Vector3.up, 0f);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 clickPosition = ray.GetPoint(distance);

                pathfinding.GetGrid().GetXZ(clickPosition, out int x, out int z);
                pathfinding.GetNode(x, z).SetIsWalkable(!pathfinding.GetNode(x, z).isWalkable);
            }
        }
    }
}
