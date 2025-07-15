using UnityEngine;

public class KeyAudio : MonoBehaviour
{
    public AudioSource KeyAudioSource;

    public AudioClip KeyPickup, KeyPassive;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayKeyPickupAudio()
    {
        KeyAudioSource.PlayOneShot(KeyPickup);
    }
    
    public void PlayKeyPassiveAudio()
    {
        KeyAudioSource.PlayOneShot(KeyPassive);
    }
}
