using System;
using System.Collections.Generic;
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
        Detect(false);
    }

    public void Detect(bool takingPicture)
    {
        Vector3 rightDif = topRight.transform.position - topLeft.transform.position;
        Vector3 downDif = bottomRight.transform.position - topRight.transform.position;
        Vector3 rightStep = rightDif / (horizontalRayCount - 1);
        Vector3 downStep = downDif / (verticalRayCount - 1);
        Vector3 toLeftCorner = topLeft.transform.position - transform.position;
        for (int i = 0; i < CameraListener.listeners.Count; i++)
        {
            CameraListener.listeners[i].OnResetSeen();
        }
        List<CameraListener> thingsSeen = new List<CameraListener>();
        for (int i = 0; i < verticalRayCount; i++)
        {
            for (int j = 0; j < horizontalRayCount; j++)
            {
                bool hitSomething = Physics.Raycast(transform.position, toLeftCorner + (rightStep * j + downStep * i), out RaycastHit hit, 50f, seenLayers);
                if (hitSomething && hit.collider.TryGetComponent<CameraListener>(out CameraListener listener))
                {
                    listener.OnCouldBeSeen();
                    Vector3 dif = listener.transform.position - transform.position;
                    Vector3 dif2D = new Vector3(dif.x, 0, dif.z);
                    
                    if (!thingsSeen.Contains(listener) && dif2D.magnitude < listener.distanceToRegisterPicture)
                    {
                        thingsSeen.Add(listener);
                    }
                }
            }
        }

        float closestVal = 0f;
        CameraListener closestObj = null;
        
        for (int i = 0; i < thingsSeen.Count; i++)
        {
            if (thingsSeen[i].wantsToBeSeen && (transform.position - thingsSeen[i].transform.position).magnitude > closestVal)
            {
                closestVal = (transform.position - thingsSeen[i].transform.position).magnitude;
                closestObj = thingsSeen[i];
            }
        }

        if (closestObj != null)
        {
            PlayerMovement.instance.blitz.detectThinksTheresThingToDo = true;
            if (takingPicture)
                closestObj.OnTakePicture();
            if (closestObj.doingStuff) PlayerMovement.instance.blitz.detectThinksTheresThingToDo = false;
        }
        else PlayerMovement.instance.blitz.detectThinksTheresThingToDo = false;
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
                bool hitSomething = Physics.Raycast(transform.position, toLeftCorner + (rightStep * j + downStep * i), 50f, seenLayers);
                if (!hitSomething)
                {
                    Gizmos.color = Color.crimson;
                }
                else
                {
                    Gizmos.color = Color.chartreuse;
                }
                Gizmos.DrawRay(transform.position, (toLeftCorner + (rightStep * j + downStep * i)).normalized * 50f);
            }
        }
    }
}
