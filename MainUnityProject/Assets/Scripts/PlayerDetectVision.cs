using System;
using UnityEngine;

public class PlayerDetectVision : MonoBehaviour
{
    public GameObject topLeft;
    public GameObject topRight;
    public GameObject bottomLeft;
    public GameObject bottomRight;
    public LayerMask seenLayers;

    public int horizontalRayCount;
    public int verticalRayCount;

    public bool gizmos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rightDif = topRight.transform.position - topLeft.transform.position;
        Vector3 downDif = bottomRight.transform.position - topRight.transform.position;
        Vector3 rightStep = rightDif / (horizontalRayCount - 1);
        Vector3 downStep = downDif / (verticalRayCount - 1);
        Vector3 toLeftCorner = topLeft.transform.position - transform.position;
        for (int i = 0; i < verticalRayCount; i++)
        {
            for (int j = 0; j < horizontalRayCount; j++)
            {
                bool hitSomething = Physics.Raycast(transform.position, toLeftCorner + (rightStep * j + downStep * i), 200f, seenLayers);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (!gizmos)
            return;
        Vector3 rightDif = topRight.transform.position - topLeft.transform.position;
        Vector3 downDif = bottomRight.transform.position - topRight.transform.position;
        Vector3 rightStep = rightDif / (horizontalRayCount - 1);
        Vector3 downStep = downDif / (verticalRayCount - 1);
        Vector3 toLeftCorner = topLeft.transform.position - transform.position;
        for (int i = 0; i < verticalRayCount; i++)
        {
            for (int j = 0; j < horizontalRayCount; j++)
            {
                bool hitSomething = Physics.Raycast(transform.position, toLeftCorner + (rightStep * j + downStep * i), 200f, seenLayers);
                if (!hitSomething)
                {
                    Gizmos.color = Color.crimson;
                }
                else
                {
                    Gizmos.color = Color.chartreuse;
                }
                Gizmos.DrawRay(transform.position, (toLeftCorner + (rightStep * j + downStep * i)) * 10f);
            }
        }
    }
}
