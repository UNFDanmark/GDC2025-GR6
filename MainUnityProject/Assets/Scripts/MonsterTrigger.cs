using System;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    public Transform spawnPoint;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            SpawnPointManger.instance.SpawnAt(spawnPoint);
        }
    }
}
