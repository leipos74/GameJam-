using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMovement : MonoBehaviour
{
    public List<Transform> points;
    public int nextPoint = 0;
    public float speed = 5;

    void Start()
    {
        transform.position = points[nextPoint].position;
    }

    void Update()
    {
        Vector3 dir = points[nextPoint].position - transform.position;
        float distance = dir.magnitude;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        if (distance < 0.1f)
        {
            nextPoint++;

            if (nextPoint >= points.Count)
            {
                nextPoint = 0;
            }
        }
    }
}