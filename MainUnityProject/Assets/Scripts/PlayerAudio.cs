using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource HardFootStep;
    public AudioClip FootStepClip;
    
    public float Counter;

    private float PitchValue = 1.0f;

    public float PitchRange;
    
    public float StepSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    
    void PlayFootSteps()
    {
        PitchValue = Random.Range(1 - PitchRange, 1 + PitchRange);
        HardFootStep.pitch = PitchValue; 
        HardFootStep.PlayOneShot(FootStepClip);
    }

    public void Moving()
    {
        if(Counter <= 0)
        {
            PlayFootSteps();
            Counter = StepSpeed;
        } 
        if(Counter > 0)
        {
            Counter -= Time.deltaTime; 
        }
    }
}
