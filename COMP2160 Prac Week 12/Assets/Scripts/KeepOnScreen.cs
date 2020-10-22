using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnScreen : MonoBehaviour
{
    public Camera camera;
    public Transform target;
    public Rect rectangle;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DrawRect();
    }

    private void DrawRect()
    {
        for (int i = 0; i < 4; i++) {
            Vector3 f = ViewportToWorld(rectangle.Corner(i));
            Vector3 t = ViewportToWorld(rectangle.Corner(i+1));

            Debug.DrawLine(f,t, Color.white, 0.0f, false);
        }
    }

    private Vector3 ViewportToWorld(Vector3 point)
    {
        Ray ray = camera.ViewportPointToRay(point);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float t;
        plane.Raycast(ray, out t);

        return ray.GetPoint(t);
    }
    

}

