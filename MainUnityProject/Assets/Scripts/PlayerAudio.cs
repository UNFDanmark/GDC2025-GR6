using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource HardFootStep;
    public AudioClip FootStepClip;
    
    public float Counter;

    public float PitchValue = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Counter <= 0)
        {
            PlayFootSteps();
            Counter = 0.8f;
        } 
        if(Counter > 0)
        {
           Counter -= Time.deltaTime; 
        }
    }
    
    void PlayFootSteps()
    {
        if (FootStepClip is null) return;
        PitchValue = Random.Range(0.7f, 1.7f);
        HardFootStep.pitch = PitchValue; 
        HardFootStep.PlayOneShot(FootStepClip);
    }
}
