using System;
using UnityEngine;
using UnityEngine.AI;

public class FindPlayer : CameraListener
{
    NavMeshAgent agent;
    public float farAwaySpeed;
    public float nearSpeed;
    public float nearDistance;

    bool scared;
    bool farAwayLastTime;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(!scared)
            agent.SetDestination(PlayerMovement.instance.transform.position);
       // else
        //    agent.SetDestination(Pla)
        if (agent.remainingDistance > nearDistance)
        {
            agent.speed = farAwaySpeed;
            farAwayLastTime = true;
        }
        else
        {
            agent.speed = nearSpeed;
            if (farAwayLastTime || scared)
                agent.velocity = agent.velocity.normalized * nearSpeed;
            farAwayLastTime = false;
        }
    }

    public override void OnTakePicture()
    {
        scared = true;
    }
}
