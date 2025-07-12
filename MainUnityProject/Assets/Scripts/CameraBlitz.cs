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
    float blitzAnimationProgress;
    float blitzCooldownProgress;
    bool playingAnimation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blitzInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        blitzCooldownProgress -= Time.deltaTime;
        blitzAnimationProgress -= Time.deltaTime;
        if (blitzInput.WasPressedThisFrame() && blitzCooldownProgress <= 0)
        {
            BeginBlitz();
        }

        if (playingAnimation)
        {
            SetIntensity(curve.Evaluate(1-blitzAnimationProgress / blitzAnimationDuration) * maxBlitz);
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
    }
}
