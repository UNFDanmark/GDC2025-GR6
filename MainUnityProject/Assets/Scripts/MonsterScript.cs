using System;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : CameraListener
{
    public static MonsterScript instance;
    NavMeshAgent agent;
    Rigidbody rb;
    public Collider collider;
    public float farAwaySpeed;
    public float nearSpeed;
    public float nearDistance;

    public bool scared;
    bool farAwayLastTime;
    void Start()
    {
        instance = this;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(!scared)
            FollowPlayer();
    }

    void FollowPlayer()
    {
        agent.SetDestination(PlayerMovement.instance.transform.position);
        
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
        agent.enabled = false;
        collider.enabled = false;
        rb.linearVelocity = (transform.position - PlayerMovement.instance.transform.position).normalized * farAwaySpeed;
    }

    public void Unscare()
    {
        scared = false;
        agent.enabled = true;
        agent.Warp(SpawnPointManger.instance.furthestPoint.position);
        collider.enabled = true;
        rb.linearVelocity = Vector3.down;
    }
}
