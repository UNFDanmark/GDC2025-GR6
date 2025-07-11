using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public PlayerLook playerLook;
    public InputAction moveInput;

    CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput.Enable();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = moveInput.ReadValue<Vector2>();
        Vector3 lookDirection = playerLook.lookDirection2D;
        Vector3 sideDirection = Vector3.Cross(lookDirection, Vector3.up);
        characterController.Move(speed * moveDirection.y * Time.deltaTime * lookDirection - speed * moveDirection.x * Time.deltaTime * sideDirection);
    }
}
