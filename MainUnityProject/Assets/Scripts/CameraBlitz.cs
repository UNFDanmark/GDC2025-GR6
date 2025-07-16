using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class CameraBlitz : MonoBehaviour
{
    public float maxBlitz;
    public float blitzAnimationDuration;
    public float blitzCooldown;
    public float breakDuration;
    public AnimationCurve curve;

    public Light light;
    
    public InputAction blitzInput;
    public PlayerDetectVision playerVision;
    public CameraCamera cameraCamera;
    public Animator animator;
    public GameObject brokenScreen;
    public GameObject blinker;
    public bool detectThinksTheresThingToDo;
    float blitzAnimationProgress;
    float blitzCooldownProgress;
    float breakProgress;
    bool playingAnimation;

    PlayerAudio cameraAudio;
    public WallChecker wallChecker;
    
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
        breakProgress -= Time.deltaTime;

        if (breakProgress > 0)
            brokenScreen.SetActive(true);
        else
            brokenScreen.SetActive(false);

        if (detectThinksTheresThingToDo)
            blinker.SetActive(true);
        else
            blinker.SetActive(false);
        
        if (blitzInput.WasPressedThisFrame() && blitzCooldownProgress <= 0 && wallChecker.touching.Count == 0)
        {
            BeginBlitz();
        }

        if (playingAnimation)
        {
            SetIntensity(curve.Evaluate(1-blitzAnimationProgress / blitzAnimationDuration) * maxBlitz);
            if (blitzAnimationProgress < 0)
            {
                playingAnimation = false;
                SetIntensity(0f);
            }
        }
    }

    public void Break()
    {
        breakProgress = breakDuration;
    }

    void SetIntensity(float v)
    {
        light.intensity = v;
        if (breakProgress > 0)
            light.intensity = v / 120f;
    }

    void BeginBlitz()
    {
        if (breakProgress <= 0)
        {
            playerVision.Detect(true);
            cameraCamera.gameObject.SetActive(true);
            StartCoroutine(cameraCamera.TakePicture());
            cameraAudio.PlayCameraAudio();
            SpawnPointManger.instance.PictureTaken();
        }
        else
        {
            cameraAudio.PlayCameraFail();
        }
        animator.SetTrigger("Press");
        blitzCooldownProgress = blitzCooldown;
        blitzAnimationProgress = blitzAnimationDuration;
        playingAnimation = true;
    }
}
