using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource StepSource;
    public AudioClip FootStepClip;

    float PitchValue = 1.0f;

    public float PitchRange;
    
    public float StepSpeed;
    
    public float Counter;
    
    [Space(10)] public AudioSource ShutterSource;
    public AudioClip CameraShutter;

    float CameraPitchValue = 1.0f;
    
    public float CameraPitchRange;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void PlayFootSteps()
    {
        PitchValue = Random.Range(1 - PitchRange, 1 + PitchRange);
        StepSource.pitch = PitchValue; 
        StepSource.PlayOneShot(FootStepClip);
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

    public void PlayCameraAudio()
    {
        CameraPitchValue = Random.Range(1 - CameraPitchRange, 1 + CameraPitchRange);
        ShutterSource.pitch = CameraPitchValue;
        ShutterSource.PlayOneShot(CameraShutter);
    }
}
