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
    public float closeGrowlDistance;
    public float fixDistance;
    public float jumpscareDistance;
    public GameObject jumpscarePoint;
    public Transform looker;
    public Animator animator;
    public Animator movAnim;
    public GameObject jumpscareLight;
    public bool weakened;
    public bool diedEver;

    public bool scared;
    bool farAwayLastTime;
    bool doneNormalGrowl;
    bool doneCloseGrowl;
    void Start()
    {
        instance = this;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        OnTakePicture();
    }

    void Update()
    {
        if(!scared)
            FollowPlayer();
        looker.LookAt(PlayerMovement.instance.transform);
    }

    void FollowPlayer()
    {
        if (PlayerMovement.instance.jumpscared) return;
        
        agent.SetDestination(PlayerMovement.instance.transform.position);
        if (agent.remainingDistance <= 0.03f)
            return;
        
        if (agent.remainingDistance > nearDistance)
        {
            agent.speed = farAwaySpeed;
            farAwayLastTime = true;
        }
        else if (agent.remainingDistance < jumpscareDistance && agent.remainingDistance != 0 && (agent.transform.position - transform.position).magnitude < jumpscareDistance + 1)
        {
            PlayerMovement.instance.JumpScare();
            GetComponent<MonsterAudio>().PlayJumpscareAudio();
            agent.enabled = false;
            animator.SetTrigger("Jumpscare");
            movAnim.SetTrigger("Jumpscare");
            jumpscareLight.SetActive(true);
            diedEver = true;
            if (weakened)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Credits scene 2");
            }
        }
        else
        {
            if (!doneNormalGrowl)
            {
                doneNormalGrowl = true;
                GetComponent<MonsterAudio>().PlayGrowlAudio();
            }
            agent.speed = nearSpeed;
            if (farAwayLastTime || scared)
                agent.velocity = agent.velocity.normalized * nearSpeed;
            farAwayLastTime = false;
        }

        if (agent.enabled && agent.remainingDistance < closeGrowlDistance && !doneCloseGrowl)
        {
            GetComponent<MonsterAudio>().PlayGrowlNearAudio();
            doneCloseGrowl = true;
        }

        if (agent.enabled && agent.remainingDistance < closeGrowlDistance && !weakened)
        {
            PlayerMovement.instance.blitz.breakProgress = -1f;
        }
    }

    public override void OnTakePicture()
    {
        scared = true;
        agent.enabled = false;
        collider.enabled = false;
        rb.linearVelocity = (transform.position - PlayerMovement.instance.transform.position).normalized * farAwaySpeed;
        SpawnPointManger.instance.BeginRespawnTimer();
    }

    public void Unscare(Transform spawnPoint)
    {
        scared = false;
        agent.enabled = true;
        agent.Warp(spawnPoint.position);
        collider.enabled = true;
        rb.linearVelocity = Vector3.down;
        GetComponent<MonsterAudio>().PlayGrowlFarAudio();
        doneNormalGrowl = false;
        doneCloseGrowl = false;
    }

    public void UnJumpscare()
    {
        OnTakePicture();
    }
}
