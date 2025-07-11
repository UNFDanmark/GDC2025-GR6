using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource HardFootStep;
    
    public float Counter;
    
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
        HardFootStep.pitch = Random.Range(1,3); 
        HardFootStep.Play();
    }
}
