using System;
using UnityEngine;

public class SpawnPointManger : MonoBehaviour
{
    public static SpawnPointManger instance;
    public Transform[] spawnPoints;
    public Transform furthestPoint;
    public float spawnTime;
    float t;

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
        t -= Time.deltaTime;
        if (t < 0 && furthestPoint != null)
        {
            t = spawnTime;
            MonsterScript.instance.Unscare();
        }
        
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
