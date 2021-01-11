using UnityEngine;

public class Testing : MonoBehaviour
{
    MyGrid grid1;
    MyGrid grid2;
    MyGrid grid3;

    void Start()
    {
        grid1 = new MyGrid(10, 10, 10f, Vector3.left * 50);
        grid2 = new MyGrid(2, 2, 5f, Vector3.right * 10);
        grid3 = new MyGrid(6, 5, 4f, Vector3.forward * 20);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, 0f);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 tmp = ray.GetPoint(distance);
                grid1.SetValue(tmp, 1);
                grid2.SetValue(tmp, 2);
                grid3.SetValue(tmp, 3);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Plane plane = new Plane(Vector3.up, 0f);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 tmp = ray.GetPoint(distance);
                Debug.Log(grid1.GetValue(tmp));
                Debug.Log(grid2.GetValue(tmp));
                Debug.Log(grid3.GetValue(tmp));
            }
        }
    }
}
