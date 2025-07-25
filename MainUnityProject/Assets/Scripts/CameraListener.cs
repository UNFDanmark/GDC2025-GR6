using System.Collections.Generic;
using UnityEngine;

public class CameraListener : MonoBehaviour
{
    public static List<CameraListener> listeners = new List<CameraListener>();
    public bool seen;
    public float distanceToRegisterPicture = 7f;
    public bool wantsToBeSeen = true;
    public float seeDist = 3.8f;
    public bool doingStuff;
    public bool isMonster;
    bool drawGizmos;

    public virtual void Start()
    {
        listeners.Add(this);
    }
    
    public virtual void OnCouldBeSeen()
    {
        seen = true;
    }

    public virtual void OnResetSeen()
    {
        seen = false;
    }

    public virtual void OnTakePicture()
    {
        
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.chocolate;
        Gizmos.DrawWireSphere(transform.position, distanceToRegisterPicture);
    }
}
