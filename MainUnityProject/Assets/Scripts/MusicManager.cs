using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioSource MusicAudioSource;

    public AudioClip Title, Intro, Ambience;

    public int SoundtrackNumberToPlay = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SoundtrackNumberToPlay == 1)
        {
            MusicAudioSource.PlayOneShot(Title);
            SoundtrackNumberToPlay = 0;
        }
    }
}
