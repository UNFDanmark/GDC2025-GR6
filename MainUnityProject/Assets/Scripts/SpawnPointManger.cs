using System;
using UnityEngine;
using Random = System.Random;

public class SpawnPointManger : MonoBehaviour
{
    public static SpawnPointManger instance;
    public Transform[] spawnPoints;
    public Transform furthestPoint;
    public float spawnMinTime;
    public float spawnMaxTime;
    public float cameraPenalty;
    public bool unscared;
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

    public void BeginRespawnTimer()
    {
        t = UnityEngine.Random.Range(spawnMinTime, spawnMaxTime);
        unscared = false;
    }

    public void PictureTaken()
    {
        t -= cameraPenalty;
    }

    void Update()
    {
        t -= Time.deltaTime;
        if (t < 0 && furthestPoint != null && !unscared)
        {
            MonsterScript.instance.Unscare();
            unscared = true;
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
