using System;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    public Transform spawnPoint;
    public bool dontDisable;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            SpawnPointManger.instance.SpawnAt(spawnPoint);
            if (!dontDisable)
                gameObject.SetActive(false);
        }
    }
}
