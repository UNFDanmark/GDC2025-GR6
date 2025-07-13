using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class CameraBlitz : MonoBehaviour
{
    public float maxBlitz;
    public float blitzAnimationDuration;
    public float blitzCooldown;
    public AnimationCurve curve;

    public Light light;
    
    public InputAction blitzInput;
    public PlayerDetectVision playerVision;
    public CameraCamera cameraCamera;
    public Animator animator;
    float blitzAnimationProgress;
    float blitzCooldownProgress;
    bool playingAnimation;

    PlayerAudio cameraAudio;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blitzInput.Enable();
        cameraAudio = GameObject.Find("Player").GetComponent<PlayerAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        blitzCooldownProgress -= Time.deltaTime;
        blitzAnimationProgress -= Time.deltaTime;
        if (blitzInput.WasPressedThisFrame() && blitzCooldownProgress <= 0)
        {
            cameraAudio.PlayCameraAudio();
            BeginBlitz();
        }

        if (playingAnimation)
        {
            SetIntensity(curve.Evaluate(1-blitzAnimationProgress / blitzAnimationDuration) * maxBlitz);
            if (blitzAnimationProgress > blitzAnimationDuration)
            {
                playingAnimation = false;
            }
        }
    }

    void SetIntensity(float v)
    {
        light.intensity = v;
    }

    void BeginBlitz()
    {
        blitzCooldownProgress = blitzCooldown;
        blitzAnimationProgress = blitzAnimationDuration;
        playingAnimation = true;
        playerVision.Detect(true);
        cameraCamera.gameObject.SetActive(true);
        StartCoroutine(cameraCamera.TakePicture());
        animator.SetTrigger("Press");
    }
}
