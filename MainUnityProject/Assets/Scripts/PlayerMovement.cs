using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    
    public float speed;
    public float fallSpeed;

    public PlayerLook playerLook;
    public InputAction moveInput;
    public bool jumpscared;
    PlayerAudio playerAudio;
    public GameObject cameraObject;
    public CameraBlitz blitz;
    public GameObject screenStatic;
    public Transform spawn;
    public GameObject finalDoor;
    public GameObject finalLights;
    int keysCollected;

    void Awake()
    {
        instance = this;
    }

    CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput.Enable();
        characterController = GetComponent<CharacterController>();
        playerAudio = GetComponent<PlayerAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpscared || !characterController.enabled) return;
        Vector2 moveDirection = moveInput.ReadValue<Vector2>();
        if (moveDirection != Vector2.zero) playerAudio.Moving();
        Vector3 lookDirection = playerLook.lookDirection2D;
        Vector3 sideDirection = Vector3.Cross(lookDirection, Vector3.up);
        characterController.Move(speed * moveDirection.y * Time.deltaTime * lookDirection - speed * moveDirection.x * Time.deltaTime * sideDirection);
        characterController.Move(fallSpeed * Time.deltaTime * Vector3.down);
    }

    public void ScreenStatic()
    {
        screenStatic.SetActive(true);
    }

    public void StopScreenStatic()
    {
        characterController.enabled = false;
        transform.position = spawn.position;
        MonsterScript.instance.UnJumpscare();
        playerLook.horizontalAngle = 90f;
        playerLook.verticalAngle = 0f;
        jumpscared = false;
        cameraObject.SetActive(true);
        screenStatic.SetActive(false);
        characterController.enabled = true;
    }

    public void OpenLastDoorFromKeysWhichIsAFuctionThatShouldBeInPlayerMovement()
    {
        keysCollected++;
        if (keysCollected >= 2)
        {
            Destroy(finalDoor);
            finalLights.SetActive(true);
        }
    }
    
    public void JumpScare()
    {
        cameraObject.SetActive(false);
        jumpscared = true;
    }
}
