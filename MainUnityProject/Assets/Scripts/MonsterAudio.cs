using UnityEngine;

public class MonsterAudio : MonoBehaviour
{

        public AudioSource MonsterAudioSource;

        public AudioClip MonsterGrowlFar, MonsterGrowl, MonsterGrowlNear, Jumpscare;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayJumpscareAudio()
        {
                MonsterAudioSource.PlayOneShot(Jumpscare);
        }
        
        public void PlayGrowlFarAudio()
        {
                MonsterAudioSource.PlayOneShot(MonsterGrowlFar);
        }
        
        public void PlayGrowlAudio()
        {
                MonsterAudioSource.PlayOneShot(MonsterGrowl);
        }
        
        public void PlayGrowlNearAudio()
        {
                MonsterAudioSource.PlayOneShot(MonsterGrowlNear);
        }
}
        
        