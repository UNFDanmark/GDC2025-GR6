using System;
using UnityEngine;

public class SpawnPointManger : MonoBehaviour
{
    public static SpawnPointManger instance;
    public Transform[] spawnPoints;
    public Transform furthestPoint;

    void Awake()
    {
        instance = this;
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        Transform furthest = null;
        float furthestDist = 0f;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if ((spawnPoints[i].transform.position - PlayerMovement.instance.transform.position).magnitude > furthestDist)
            {
                furthestDist = (spawnPoints[i].transform.position - PlayerMovement.instance.transform.position).magnitude;
                furthest = spawnPoints[i];
            }
        }

        furthestPoint = furthest;
    }
    
}
