using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static MusicManager instance;

    public AudioSource MusicAudioSource;
    public AudioSource SecondaryMusicAudioSource;

    public AudioClip Title, Intro, Ambience, IntenseAmbience;

    public int SoundtrackNumberToPlay = 1;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (SoundtrackNumberToPlay == 1)
        {
            MusicAudioSource.PlayOneShot(Title);
            SoundtrackNumberToPlay = 0;
        }
        
        if (SoundtrackNumberToPlay == 2)
        {
            MusicAudioSource.PlayOneShot(Intro);
            SoundtrackNumberToPlay = 0;
        }
        
        if (SoundtrackNumberToPlay == 3)
        {
            MusicAudioSource.PlayOneShot(Ambience);
            SecondaryMusicAudioSource.PlayOneShot(IntenseAmbience);
            SoundtrackNumberToPlay = 0;
        }
    }

    void PlayDarknessMusic()
    {
        SoundtrackNumberToPlay = 3;
        SecondaryMusicAudioSource.volume = 0;
        MusicAudioSource.volume = 1;
    }
    
    void SwitchToIntenseDarknessMusic()
    {
        SecondaryMusicAudioSource.volume = 1;
        MusicAudioSource.volume = 0;
    }
}
