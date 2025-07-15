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
    public bool count;

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

    public void SpawnAt(Transform spawnPoint)
    {
        MonsterScript.instance.Unscare(spawnPoint);
        unscared = true;
    }

    void Update()
    {
        t -= Time.deltaTime;
        if (!count)
            BeginRespawnTimer();
        
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
        
        if (t < 0 && furthestPoint != null && !unscared)
        {
            SpawnAt(furthest);
        }
    }
}
