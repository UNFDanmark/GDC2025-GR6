using System;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    public List<Collider> touching = new List<Collider>();
    void OnTriggerEnter(Collider other)
    {
        touching.Add(other);
    }

    void OnTriggerExit(Collider other)
    {
        touching.Remove(other);
    }
}
