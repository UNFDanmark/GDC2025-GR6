using UnityEngine;
using UnityEngine.InputSystem;

public class CameraBlitz : MonoBehaviour
{
    public float maxBlitz;
    public float blitzAnimationDuration;
    public float blitzCooldown;
    public AnimationCurve curve;

    public InputAction blitzInput;
    float blitzAnimationProgress;
    float blitzCooldownProgress;
    bool playingAnimation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blitzCooldownProgress -= Time.deltaTime;
        blitzAnimationProgress -= Time.deltaTime;
        if (blitzInput.WasPressedThisFrame())
        {
            BeginBlitz();
        }
    }

    void BeginBlitz()
    {
        blitzCooldownProgress = blitzCooldown;
        blitzAnimationProgress = blitzAnimationDuration;
        playingAnimation = true;
    }
}
